using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReservAR.Presentation.Controllers;

[Route("api/users")]
public class UserController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

}
