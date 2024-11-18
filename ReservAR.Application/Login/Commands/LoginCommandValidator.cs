using FluentValidation;

namespace ReservAR.Application.Login.Commands;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(r => r.email).NotEmpty();
        RuleFor(r => r.password).NotEmpty();
    }
}
