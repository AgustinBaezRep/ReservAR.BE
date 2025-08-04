using ErrorOr;
using MediatR;
using ReservAR.Application.Common;
using ReservAR.Application.Common.Interfaces;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Domain.UserAggregate.ValueObjects;
using ReservAR.Application.Mappings;
using ReservAR.Domain.Common.DomainErrors;

namespace ReservAR.Application.User.Commands.Create;

public sealed class CreateUserCommandHandler(IUserRepository userRepository,
    IAggregateLoader aggregateLoader) :
        CommandHandlerBase<Domain.UserAggregate.Usuario, UsuarioId>(aggregateLoader),
        IRequestHandler<CreateUserCommand, ErrorOr<Created>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<Created>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var loginCommand = request.ToLoginCommand();

        var existingUser = await _userRepository.GetUserByEmailAsync(loginCommand, cancellationToken);

        if (existingUser is not null)
        {
            return Errors.User.AlreadyExistingUser();
        }

        Aggregate!.Create(request.firstName, request.lastName, request.email, request.password);

        await _userRepository.AddAsync(Aggregate, cancellationToken);

        return Result.Created;
    }
}