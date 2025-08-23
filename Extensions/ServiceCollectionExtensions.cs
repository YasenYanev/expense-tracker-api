namespace expense_tracker_api.Extensions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using expense_tracker_api.Services.Interfaces;
using expense_tracker_api.Services.Implementations;
using expense_tracker_api.Data;
using expense_tracker_api.Entities;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, string connectionString, string secretKey)
    {
        services.AddDbContext<ExpensesDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddSingleton<IJWTService>(new JWTService(secretKey));

        services.AddAuthentication()
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
        {
            jwtOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:5226/",
                ValidAudience = "http://localhost:5226/",
                IssuerSigningKey = new SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(secretKey))
            };
        });

        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
    }
}
