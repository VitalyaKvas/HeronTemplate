# HeronTemplate
Heron this is the basic web api template. Powered by Asp.net Core 2.

Using dependency:
 * EntityFrameworkCore.Design
 * Npgsql Entity Framework Core provider for PostgreSQL
 * NLog on ASP.NET Core
 * Swashbuckle (Swagger tools for documenting API's built on ASP.NET Core)
 * AutoMapper

Swagger:
  To familiarize yourself with api, you need to use the documentation that is created in Swagger.
  Swagger UI will be exposed at "/swagger". If necessary, you can alter this when enabling the SwaggerUI middleware.
  Swagger schema will be exposed at "/swagger/v1/swagger.json".

To run the project, need:
 * Instal Asp.net Core 2
 * `dotnet restore` - Restores the dependencies and tools of a project.
 * `dotnet ef database update` - Updates the database to a specified migration.(Before executing this command, check the connection string.)
 * `dotnet run` - Runs source code without any explicit compile or launch commands.
 
This project wraps all the response in a beautiful strongly typed JSON. This is done with used filters, the project contains several filters:
 * ApiActionFilter - Filter to catch all Action and wrap this.
 * ApiExceptionFilter - Filter to catch all exceptions and wrap this.
