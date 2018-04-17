using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using WebApiApplication.Data;
using WebApiApplication.Infrastructure.Filter;
using WebApiApplication.Models.Entity;
using WebApiApplication.Services.AutoMapperProfile;
using WebApiApplication.Services.EmailSender;

namespace WebApiApplication
{
    /// <summary>
    /// The Startup class configures services and the app's request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This property stores all configuration settings as a set of key-value pairs.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method set configuration
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure settings
            services.Configure<EmailSettings>(options => Configuration.GetSection("EmailSettings").Bind(options));

            // Automapper profile
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            // Configure connection string
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

            // Configurate IdentityRole
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, FakeEmailSender>();

            // Configure Mvc and filters
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ApiExceptionFilter));
                options.Filters.Add(typeof(ApiActionFilter));
            });

            // Configure logging
            services.AddLogging();
            
            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen(c =>
            {
                // Set base information for documents
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Web API",
                    Description = "A simple example ASP.NET Core Web API",
                });

                // Determine base path for the application.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                // Set the comments path for the swagger json and ui.
                var xmlPath = Path.Combine(basePath, PlatformServices.Default.Application.ApplicationName + ".xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IHostingEnvironment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable use static files
            app.UseStaticFiles();

            // Enable midlleware for check http status code.
            app.Use(async (context, next) =>
            {
                await next();

                // If page not found do redirect to "/Home/UrlNotFound" 
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/UrlNotFound";
                    await next();
                }
            });

            // Adds MVC to request execution pipeline.
            app.UseMvc();
            
            // For development mode.
            if (env.IsDevelopment())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint
                app.UseSwagger(c =>
                {
                    c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
                });

                // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
        }
    }
}
