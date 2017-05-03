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
using PackageDefaultCustom.Repositorys;
using PackageDefaultCustom.Services;
using Package.Models;


namespace PackageDefaultCustom.Extentions
{
    /// <summary>
    /// デフォルトカスタマイズ版（ここの実装が標準）
    /// </summary>
    public class Extention : IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Extension PackageDefaultCustom";
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
                        routeBuilder.MapRoute(name: "Extension PackageDefaultCustom", template: "{controller=Home}/{action=Index}/{id?}");
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
            services.AddScoped<IService<Item>, ItemDefaultCustomService>();
            services.AddScoped<IRepository<Item>, ItemDefaultCustomRepository>();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
        }
    }
}