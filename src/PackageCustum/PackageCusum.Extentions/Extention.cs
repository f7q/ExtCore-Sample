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
using Package.Infrastracture.Repositorys;
using Package.Infrastracture.Services;
using PackageCustum.Repositorys;
using PackageCustum.Services;
using PackageCustum.Models;


namespace PackageCusutm.Extentions
{
    /// <summary>
    /// 実装しない。 カスタマイズ版で提供
    /// </summary>
    public class Extention : IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Extension PackageCusutm";
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
                        routeBuilder.MapRoute(name: "Extension PackageCusutm", template: "{controller=Home}/{action=Index}/{id?}");
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
            services.AddDbContext<Item2DbContext>(options =>
            {
                options.UseSqlite(this.configurationRoot["Data:DefaultConnection:ConnectionString"]);
            });
            services.AddScoped<IService<Item>, ItemCustumService>();
            services.AddScoped<IRepository<Item>, ItemCustumRepository>();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
        }
    }
}