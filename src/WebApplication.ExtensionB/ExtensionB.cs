﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using ExtCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApplication.ExtensionB.Models;

namespace WebApplication.ExtensionB
{
    public class ExtensionB : IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Extension B";
            }
        }

        public IDictionary<int, Action<IRouteBuilder>> RouteRegistrarsByPriorities
        {
            get
            {
                Dictionary<int, Action<IRouteBuilder>> routeRegistrarsByPriorities = new Dictionary<int, Action<IRouteBuilder>>();

                routeRegistrarsByPriorities.Add(
                    3000,
                    routeBuilder =>
                    {
                        routeBuilder.MapRoute(name: "Extension B", template: "extension-b", defaults: new { controller = "ExtensionB", action = "Index" });
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
                return 2000;
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
            services.AddScoped<IItemRepository, ItemRepository>();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
        }
    }
}