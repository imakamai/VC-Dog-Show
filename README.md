# Dog Show - Backend

This is the server-side (Backend) of the **Dog Show** application, developed in **ASP.NET Core**. The application serves to manage dog shows, user/dog registration, and competition organization.

## Technologies

*   **.NET 8** (ASP.NET Core Web API)
*   **Entity Framework Core** (ORM for database access)
*   **SQL Server** (Database)
*   **JWT** (JSON Web Token) for authentication
*   **BCrypt** for password hashing
*   **Stripe** (optional, for payments)

## Project Structure

*   `Controllers`: API endpoints (`UserController`, `DogController`, etc.)
*   `Modules`: Database models (`Classes`), DTO objects, Data Context.
*   `Repository`: Data access logic.
*   `Services`: Business logic.

## Getting Started

### 1. Prerequisites
*   Install [.NET 8 SDK](https://dotnet.microsoft.com/download)
*   SQL Server (or LocalDB)
*   Set up Connection String in `appsettings.json`

### 2. Configuration
In `appsettings.json`, configure the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=...;Database=DogShowDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Migrations and Database
Before the first run, create the database using migrations:
```bash
dotnet ef database update
```

### 4. Running the Application
Navigate to the project folder and run:
```bash
dotnet run
```
The server will default to `http://localhost:5000` (or `https://localhost:7001`).

## Authors
This project was developed as part of a student thesis.
