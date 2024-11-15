using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservAR.Application.Mappings;
using ReservAR.Contracts.Login;

namespace ReservAR.Presentation.Controllers;

[Route("api/login")]
public class LoginController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> GetAccessToken([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = request.ToLoginCommand();

        var getAccessTokenResult = await _mediator.Send(command, cancellationToken);

        return getAccessTokenResult.Match(
            Ok,
            Problem);
    }
}
