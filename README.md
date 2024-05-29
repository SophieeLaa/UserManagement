# UserManagement
User Management API with Clean Architecture
This project is an ASP.NET Core Web API implementing user management functionality using Clean Architecture principles.

Functionality
User Registration: Allows users to register with a username, email, and password.
User Login: Provides JWT authorization for user authentication.
User Profile Operations: Enables users to retrieve and update their profile information.
Role-Based Authorization: Implements role-based access control with Admin and User roles.

Technologies Used
.NET 8, C# 12, ASP.NET Core Web API
Entity Framework Core: Code First approach
SQL Server 
Swagger (Swashbuckle.AspNetCore): API documentation and testing
bcrypt 
JWT Tokens: Authentication and authorization

Instructions for Launching
Clone Repository
Database Configuration: Set connection string in appsettings.json.
Launch Application: Build and run the solution.
Access Swagger UI: Navigate to https://localhost:{port}/swagger/index.html for API documentation and testing.
