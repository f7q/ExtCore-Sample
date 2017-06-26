// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Autofac;
using Autofac.Core;
using System;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApplication
{
  public class Startup : ExtCore.WebApplication.Startup
  {
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IHostingEnvironment hostingEnvironment)
          : base(hostingEnvironment)
        {
              IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

              this.configurationRoot = configurationBuilder.Build();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            /*var builder = new ContainerBuilder();
            //builder.RegisterModule(new AutofacModule());
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();*/
            base.ConfigureServices(services);
            //return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public override void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseDatabaseErrorPage();
                applicationBuilder.UseBrowserLink();
            }

            else
            {

            }

            base.Configure(applicationBuilder, hostingEnvironment);
        }
  }
}