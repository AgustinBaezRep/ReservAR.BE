using ReservAR.Application.Common.Interfaces.IThirdPartyServices.Authentication;
using ReservAR.Authentication.Services;

namespace ReservAR.Infraestructure.ThirdPartyServices.Authentication;

internal sealed class AuthenticationService(ITokenGeneratorService tokenGeneratorService) : IAuthenticationService
{
    private readonly ITokenGeneratorService _tokenGeneratorService = tokenGeneratorService;

    public string GetAccessTokenAsync(Contracts.Login.LoginRequest loginRequest)
    {
        return _tokenGeneratorService.GenerateJwtTokenWithCredentials();
    }

    public string GetRefreshTokenAsync(Contracts.Login.LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public void RevokeRefreshTokenAsync(Contracts.Login.LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }
}
