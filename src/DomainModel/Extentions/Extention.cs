using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DomainModel.Infrastracture.Repositorys;
using DomainModel.Infrastracture.Services;
using DomainModel.Repositorys;
using DomainModel.Services;
using DomainModel.Models;
using DomainModel.Controllers;

namespace DomainModel.Extentions
{
    public class Extention : IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Extension DomainModel";
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
                        routeBuilder.MapRoute(name: "Extension DomainModel", template: "{controller=Home}/{action=Index}/{id?}");
                    }
                );

                return routeRegistrarsByPriorities;
            }
        }


        public int ConfigureServicesPriorities
        {
            get
            {
                return 2001;
            }
        }
        public int ConfigurePriorities
        {
            get
            {
                return 2001;
            }
        }
        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite();
            services.AddDbContext<ItemDbContext>(options =>
            {
                options.UseSqlite(this.configurationRoot["Data:DefaultConnection:ConnectionString"]);
            });
            services.AddScoped<IService<Item>, ItemService>();
            services.AddScoped<IRepository<Item>, ItemRepository>();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
        }
    }
}