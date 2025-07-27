using ErrorOr;
using MediatR;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Application.Common.Interfaces.IThirdPartyServices.Authentication;
using ReservAR.Application.Mappings;
using ReservAR.Domain.Common.DomainErrors;

namespace ReservAR.Application.Login.Commands;

public sealed class LoginCommandHandler(IUserRepository userRepository,
    IAuthenticationService authenticationService) : 
        IRequestHandler<LoginCommand, ErrorOr<string>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public async Task<ErrorOr<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request, cancellationToken);

        if (user is null)
            return Errors.Login.IncorrectCredentials();

        var loginRequest = request.ToLoginRequest();

        string token = _authenticationService.GetAccessTokenAsync(loginRequest);

        return token;
    }
}
