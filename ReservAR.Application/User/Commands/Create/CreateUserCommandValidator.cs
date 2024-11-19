using FluentValidation;

namespace ReservAR.Application.User.Commands.Create;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(r => r.firstName).NotEmpty();
        RuleFor(r => r.lastName).NotEmpty();
        RuleFor(r => r.email).NotEmpty();
        RuleFor(r => r.password).NotEmpty();
    }
}