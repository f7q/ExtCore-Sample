using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger.Model;


namespace WebApplication.Swagger
{
    public class Swagger : IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Extension Swagger";
            }
        }

        public IDictionary<int, Action<IRouteBuilder>> RouteRegistrarsByPriorities
        {
            get
            {
                Dictionary<int, Action<IRouteBuilder>> routeRegistrarsByPriorities = new Dictionary<int, Action<IRouteBuilder>>();

                routeRegistrarsByPriorities.Add(
                    9000,
                    routeBuilder =>
                    {
                        routeBuilder.MapRoute(name: "Extension Swagger", template: "{controller=Home}/{action=Index}/{id?}");
                    }
                );

                return routeRegistrarsByPriorities;
            }
        }

        public int ConfigureServicesPriorities
        {
            get
            {
                return 300;
            }
        }
        public int ConfigurePriorities
        {
            get
            {
                return 9000;
            }
        }
        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //var pathToDoc = this.configurationRoot["Swagger:Path"];
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Geo Search API",
                    Description = "A simple api to search using geo location in Elasticsearch",
                    TermsOfService = "None"
                });
                //options.IncludeXmlComments(pathToDoc);
                options.DescribeAllEnumsAsStrings();
            });
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUi();
        }
    }
}