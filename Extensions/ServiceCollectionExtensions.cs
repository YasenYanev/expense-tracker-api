namespace expense_tracker_api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using expense_tracker_api.Services.Interfaces;
using expense_tracker_api.Services.Implementations;
using expense_tracker_api.Data;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, string connectionString, string secretKey)
    {
        services.AddDbContext<ExpensesDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddSingleton<IJWTServiceTest>(new JWTServiceTest(secretKey));

        services.AddAuthentication()
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
        {
            jwtOptions.Authority = "http://localhost:5226/";
            jwtOptions.Audience = "http://localhost:5226/";
            jwtOptions.RequireHttpsMetadata = false;
        });
    }
}
