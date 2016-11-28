using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp;
using ExtCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Script
{
    public class Script : IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Extension Script";
            }
        }

        public IDictionary<int, Action<IRouteBuilder>> RouteRegistrarsByPriorities
        {
            get
            {
                Dictionary<int, Action<IRouteBuilder>> routeRegistrarsByPriorities = new Dictionary<int, Action<IRouteBuilder>>();

                routeRegistrarsByPriorities.Add(
                    2000,
                    routeBuilder =>
                    {
                        routeBuilder.MapRoute(name: "Extension Script", template: "{controller=Home}/{action=Index}/{id?}");
                    }
                );

                return routeRegistrarsByPriorities;
            }
        }

        public int ConfigureServicesPriorities
        {
            get
            {
                return 2000;
            }
        }
        public int ConfigurePriorities
        {
            get
            {
                return 2002;
            }
        }
        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }


        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
        }
    }
}