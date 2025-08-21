using Microsoft.EntityFrameworkCore;
using expense_tracker_api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ExpensesDB");
var secretKey = builder.Configuration["Jwt:Key"];

builder.Services.AddServices(connectionString!, secretKey!);

var app = builder.Build();
app.MapEndpoints();
app.Run();