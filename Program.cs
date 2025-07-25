using MinimalApis.Extensions.Binding;
using expense_tracker_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ExpensesDB");

builder.Services.AddDbContext<ExpensesDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.MapGet("/", (ExpensesDbContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Json(dbContext.ExpensesCategories.ToList());
});

app.Run();