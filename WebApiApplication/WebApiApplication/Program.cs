using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;
using System;

namespace WebApiApplication
{
    /// <summary>
    /// In ASP.NET Core, the Program class is used to setup the IWebHost.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This method run web host.
        /// </summary>
        /// <param name="args">The command line args.</param>
        public static void Main(string[] args)
        {
            // NLog: setup the logger first to catch all errors
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                // NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebHost"/> class with pre-configured defaults.
        /// </summary>
        /// <param name="args">The command line args.</param>
        /// <returns>The initialized <see cref="IWebHost"/>.</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog() // NLog: setup NLog for Dependency injection
                .Build();
    }
}
