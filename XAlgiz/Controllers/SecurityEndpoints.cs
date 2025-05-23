using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using XAlgiz.Dtos;
using XAlgiz.Security;

namespace XAlgiz.Controllers;

public static class SecurityEndpoints
{
    public static void MapSecurityEndpoints(this WebApplication app)
    {
        app.MapPost("/login", (LoginRequest login) =>
            {
                if (login.User != "admin" || login.Password != "123456") return Results.Unauthorized();

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtSettings.Key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Results.Ok(new LoginResponse(tokenString));
            })
            .WithName("Login")
            .WithTags("Segurança")
            .Produces<LoginResponse>()
            .Produces(StatusCodes.Status401Unauthorized);
    }
}