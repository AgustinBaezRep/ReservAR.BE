namespace ReservAR.Authentication.Services;

public interface ITokenGeneratorService
{
    string GenerateJwtTokenWithCredentials();
}
