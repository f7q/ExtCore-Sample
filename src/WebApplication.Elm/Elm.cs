using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApplication.Elm
{
    public class Elm : IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Extension Elm";
            }
        }

        public IDictionary<int, Action<IRouteBuilder>> RouteRegistrarsByPriorities
        {
            get
            {
                return null;
            }
        }


        public int ConfigureServicesPriorities
        {
            get
            {
                return 100;
            }
        }
        public int ConfigurePriorities
        {
            get
            {
                return 100;
            }
        }
        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddElm(options =>
            {
                options.Path = new PathString("/Elm");  // defaults to "/Elm"
                options.Filter = (name, level) => level >= LogLevel.Information;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseElmPage(); // Shows the logs at the specified path
            app.UseElmCapture(); // Adds the ElmLoggerProvider
            var factory = app.ApplicationServices.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<Elm>();
            using (logger.BeginScope("startup"))
            {
                logger.LogWarning("Starting up");
            }

            /*app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello world");
                using (logger.BeginScope("world"))
                {
                    logger.LogInformation("Hello world!");
                    logger.LogError("Mort");
                }
                // This will not get logged because the filter has been set to LogLevel.Information and above
                using (logger.BeginScope("debug"))
                {
                    logger.LogDebug("some debug stuff");
                }
            });*/
            logger.LogInformation("This message is not in a scope");
        }
    }
}