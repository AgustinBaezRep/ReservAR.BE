using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservAR.Contracts.User;
using ReservAR.Application.Mappings;

namespace ReservAR.Presentation.Controllers;

[Route("api/users")]
public class UserController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = request.ToCreateUserCommand();

        var getAccessTokenResult = await _mediator.Send(command, cancellationToken);

        return getAccessTokenResult.Match(
            user => Created("getById", user),
            Problem);
    }
}
