using ReservAR.Contracts.Login;

namespace ReservAR.Application.Common.Interfaces.IThirdPartyServices.Authentication;

public interface IAuthenticationService
{
    string GetAccessTokenAsync(LoginRequest loginRequest);
    string GetRefreshTokenAsync(LoginRequest loginRequest);
    void RevokeRefreshTokenAsync(LoginRequest loginRequest);
}
