using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReservAR.Authentication.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReservAR.Authentication.Services;

public class TokenGeneratorService(IOptions<JwtOptions> options) : ITokenGeneratorService
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public string GenerateJwtTokenWithCredentials()
    {
        var claims = new Claim[] {
            new(JwtRegisteredClaimNames.Sub, "id"),
            new(JwtRegisteredClaimNames.Email, "email"),
            new("Role", "RoleEnum.XXX")
        };

        var signinCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signinCredentials);

        string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
