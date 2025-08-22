namespace expense_tracker_api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using expense_tracker_api.Data;
using expense_tracker_api.Services.Interfaces;
using expense_tracker_api.Entities;
using expense_tracker_api.Dtos;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        var authGroup = app.MapGroup("/users");

        app.MapGet("/", async (ExpensesDbContext dbContext) =>
        {
            var dbTest = await dbContext.ExpensesCategories.ToListAsync();
            return Results.Json(dbTest);
        });

        authGroup.MapPost("/register",
            async ([FromBody] UserDto user,
            IJWTService myJwtService,
            IPasswordHasher<User> passwordHasher,
            HttpContext context,
            ExpensesDbContext dbContext) =>
        {
            var newUser = new User();
            // Hash password
            newUser.UserName = user.UserName;
            newUser.HashedPassword = passwordHasher.HashPassword(newUser, user.Password);
            // Add to database
            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
            // Generate token
            context.Response.Headers["Authorization"] = myJwtService.GenerateToken(newUser.UserName, newUser.Id);
            // Send token
            return Results.Ok();
        });

        authGroup.MapPost("/login", (IJWTService myJwtService, HttpContext context) =>
        {
            // var username = user.Username;
            // var role = user.Role;

            // if (!(username == "Yasen" && role == "Admin")) return Results.Unauthorized();

            // context.Response.Headers["Authorization"] = jwtServiceTest4e.GenerateToken(username, role);
            // return Results.Ok("Jwt Token Created!");
        });
    }
}
