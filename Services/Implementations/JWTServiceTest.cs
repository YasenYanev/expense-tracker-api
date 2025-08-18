namespace expense_tracker_api.Services.Implementations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using expense_tracker_api.Services.Interfaces;

public class JWTServiceTest : IJWTServiceTest
{
    private readonly string _secretKey;
    public JWTServiceTest(string secretKey)
    {
        _secretKey = secretKey;
    }
    public string GenerateToken(string username, string role)
    {
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Unique ID for token
        };

        var token = new JwtSecurityToken(
            issuer: "http://localhost:5226/",
            audience: "http://localhost:5226/",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
