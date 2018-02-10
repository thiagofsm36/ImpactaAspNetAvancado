﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Empresa.Repositorios.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Empresa.Mvc
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //services.AddDbContext<EmpresaDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EmpresaConnectionString")));

            services.AddDbContext<EmpresaDbContext>(TESTE_THIAGO_SetConnectionString);
            services.AddSingleton<IConfiguration>(Configuration);

        }

        private void TESTE_THIAGO_SetConnectionString(DbContextOptionsBuilder obj)
        {
            obj.UseSqlServer(Configuration.GetConnectionString("EmpresaConnectionString"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationScheme = Configuration.GetSection("TipoAutenticacao").Value,
                LoginPath = new PathString("/Login/Index"),
                AccessDeniedPath= new PathString("/Login/AcessoNegado"),
                AutomaticChallenge = true,
                AutomaticAuthenticate = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(20)
                
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
