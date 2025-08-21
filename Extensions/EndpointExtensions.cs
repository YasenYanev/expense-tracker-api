namespace expense_tracker_api.Extensions;
using Microsoft.EntityFrameworkCore;
using expense_tracker_api.Data;
using expense_tracker_api.Services.Interfaces;
using expense_tracker_api.Dtos;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", async (ExpensesDbContext dbContext) =>
        {
            var dbTest = await dbContext.ExpensesCategories.ToListAsync();
            return Results.Json(dbTest);
        });

        app.MapPut("/register", () =>
        {
            // TODO: Store users in database and authenticate them
        });

        app.MapPost("/login", (IJWTServiceTest jwtServiceTest4e, HttpContext context, UserDto user) =>
        {
            // var username = user.Username;
            // var role = user.Role;

            // if (!(username == "Yasen" && role == "Admin")) return Results.Unauthorized();

            // context.Response.Headers["Authorization"] = jwtServiceTest4e.GenerateToken(username, role);
            // return Results.Ok("Jwt Token Created!");
        });
    }
}
