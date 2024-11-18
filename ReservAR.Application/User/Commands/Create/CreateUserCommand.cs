using ErrorOr;
using MediatR;

namespace ReservAR.Application.User.Commands.Create;

public record CreateUserCommand(string firstName,
    string lastName,
    string email,
    string password) : IRequest<ErrorOr<Created>>;