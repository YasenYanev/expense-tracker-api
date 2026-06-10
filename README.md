# Expense Tracker API

This is a .NET 9 minimal API for tracking personal expenses. It uses Entity Framework Core with SQL Server, JWT authentication, and a small set of REST endpoints for user auth and expense management.

## What it does

- Register and log in users with hashed passwords
- Issue JWTs for authenticated requests
- Create, read, update, and delete expenses
- Store expense categories in the database

## Main endpoints

- `POST /auth/register` - create a user and return a JWT in the `Authorization` response header
- `POST /auth/login` - verify credentials and return a JWT in the `Authorization` response header
- `POST /expenses/add` - add a new expense for the authenticated user
- `GET /expenses/all` - list the current user's expenses
- `PUT /expenses/{id}` - update an expense
- `DELETE /expenses/{id}` - delete an expense

There is also a simple `GET /` endpoint that returns the seeded expense categories.

## Local setup

1. Make sure SQL Server is running locally.
2. Update the connection string in [appsettings.json](appsettings.json) if needed.
3. Ensure the JWT key in [appsettings.Development.json](appsettings.Development.json) matches your local environment.
4. Run the app with `dotnet run`.

## Project structure

- `Data/` - DbContext and migrations
- `Entities/` - database models
- `Dtos/` - request payloads
- `Extensions/` - endpoint and service registration helpers
- `Services/` - JWT token generation

