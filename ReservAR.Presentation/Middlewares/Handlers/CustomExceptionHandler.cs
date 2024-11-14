using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

internal sealed class CustomExceptionHandler(IProblemDetailsService problemDetailsService,
    IOptions<ApiBehaviorOptions> options) : IExceptionHandler
{
    private readonly ApiBehaviorOptions _apiBehaviorOptions = options?.Value ?? throw new ArgumentNullException(nameof(options));

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        int statusCode = exception switch
        {
            ArgumentNullException => StatusCodes.Status400BadRequest,
            ArgumentException => StatusCodes.Status400BadRequest,
            InvalidOperationException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Detail = exception.Message
        };

        if (_apiBehaviorOptions.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        AddProblemDetailExtensions(problemDetails, httpContext);

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            Exception = exception,
            HttpContext = httpContext,
            ProblemDetails = problemDetails
        });
    }

    private static void AddProblemDetailExtensions(ProblemDetails problemDetails, HttpContext httpContext)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        if (traceId != null)
            problemDetails.Extensions["traceId"] = traceId;

        problemDetails.Extensions.Add("errorType", "ExceptionType");
    }
}