using ErrorOr;
using MediatR;

namespace ReservAR.Application.Login.Commands;

public record LoginCommand(string email, string password) : IRequest<ErrorOr<string>>;
