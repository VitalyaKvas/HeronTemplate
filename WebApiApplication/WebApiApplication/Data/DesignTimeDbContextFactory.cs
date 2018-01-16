using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApiApplication.Data
{
    /// <summary>
    /// Design-time DbContext Creation.
    /// Some of the EF Core Tools commands (for example, the Migrations commands)
    /// require a derived DbContext instance to be created at design time in order 
    /// to gather details about the application's entity types and how they map to
    /// a database schema. 
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// Create context for the Entity Framework.
        /// </summary>
        /// <param name="args">The command line args.</param>
        /// <returns>Identity context</returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));

            return new ApplicationDbContext(builder.Options);
        }
    }
}
