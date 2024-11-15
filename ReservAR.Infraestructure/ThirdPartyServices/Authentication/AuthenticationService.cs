using ReservAR.Application.Common.Interfaces.IThirdPartyServices.Authentication;
using ReservAR.Authentication.Services;
using ReservAR.Contracts.Login;

namespace ReservAR.Infraestructure.ThirdPartyServices.Authentication;

internal sealed class AuthenticationService(ITokenGeneratorService tokenGeneratorService) : IAuthenticationService
{
    private readonly ITokenGeneratorService _tokenGeneratorService = tokenGeneratorService;

    public string GetAccessTokenAsync(LoginRequest loginRequest)
    {
        return _tokenGeneratorService.GenerateJwtTokenWithCredentials();
    }

    public string GetRefreshTokenAsync(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public void RevokeRefreshTokenAsync(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }
}
