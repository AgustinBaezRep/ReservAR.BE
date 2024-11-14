using ErrorOr;
using MediatR;
using ReservAR.Application.Common;
using ReservAR.Application.Common.Interfaces;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Application.Common.Interfaces.IThirdPartyServices.Authentication;
using ReservAR.Application.Mappings;
using ReservAR.Domain.Common.DomainErrors;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Application.Login.Commands;

sealed class LoginCommandHandler(IUserRepository userRepository,
    IAggregateLoader aggregateLoader,
    IAuthenticationService authenticationService) : CommandHandlerBase<User, UserId>(aggregateLoader), 
    IRequestHandler<LoginCommand, ErrorOr<string>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public async Task<ErrorOr<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request, cancellationToken);
        
        if (user is null)
            return Errors.User.IncorrectCredentials();

        var loginRequest = request.ToLoginRequest();

        string token = _authenticationService.GetAccessTokenAsync(loginRequest);


        return token;
    }
}
