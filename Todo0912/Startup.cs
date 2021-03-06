﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Todo0912.Data;

namespace Todo0912
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "ZEIN";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBuser"] ?? "sa";
            var password = Configuration["DBPassword"] ?? "Manuver!888";
            var database = Configuration["Database"] ?? "DbTask";


            //var connection = @"server=ZEIN;database=DbTask;integrated security=true";
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}")); ;
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            PrepDB.PrepPopulation(app);
        }
    }
}
