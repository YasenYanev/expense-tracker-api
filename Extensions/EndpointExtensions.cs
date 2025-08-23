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
            var newUser = new User()
            {
                UserName = user.UserName,
                HashedPassword = passwordHasher.HashPassword(null, user.Password)
            };
            // Add to database
            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
            // Generate token
            context.Response.Headers["Authorization"] = myJwtService.GenerateToken(newUser.UserName, newUser.Id);
            // Send token
            return Results.Ok();
        });

        authGroup.MapPost("/login",
            async ([FromBody] UserDto user,
            IJWTService myJwtService,
            IPasswordHasher<User> passwordHasher,
            HttpContext context,
            ExpensesDbContext dbContext) =>
        {
            User? myUser = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (myUser == null) return Results.NotFound();

            var passwordIsCorrect = passwordHasher.VerifyHashedPassword(null, myUser.HashedPassword, user.Password);
            if (passwordIsCorrect != PasswordVerificationResult.Success) return Results.NotFound();

            context.Response.Headers["Authorization"] = myJwtService.GenerateToken(myUser.UserName, myUser.Id);

            return Results.Ok();
        });
    }
}
