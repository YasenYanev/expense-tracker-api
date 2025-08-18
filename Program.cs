using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using expense_tracker_api.Data;
using expense_tracker_api.Services.Interfaces;
using expense_tracker_api.Extensions;
using expense_tracker_api.Dtos;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ExpensesDB");
var secretKey = builder.Configuration["Jwt:Key"];

builder.Services.AddServices(connectionString!, secretKey!);

var app = builder.Build();

app.MapGet("/", async (ExpensesDbContext dbContext) =>
{
    var dbTest = await dbContext.ExpensesCategories.ToListAsync();
    return Results.Json(dbTest);
});


app.MapPost("/login", ([FromServices] IJWTServiceTest jwtServiceTest4e, HttpContext context, UserDto user) =>
{
    var username = user.Username;
    var role = user.Role;

    if (!(username == "Yasen" && role == "Admin")) return Results.Unauthorized();

    context.Response.Headers["Authorization"] = jwtServiceTest4e.GenerateToken(username, role);
    return Results.Ok("Jwt Token Created!");
});


app.Run();