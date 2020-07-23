using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.Use(async (context, next) =>
        //    {
        //        //await context.Response.WriteAsync("Hello World!");
        //        //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
        //        //await context.Response.WriteAsync(_config["mykey"]);
        //        await context.Response.WriteAsync("one");
        //        await next();
        //    });

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("two");
        //    });
        //}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILogger<Startup> logger) 
        {

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");
                await next();
                logger.LogInformation("MW1: Outgoing Response");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next();
                logger.LogInformation("MW2: Outgoing Response");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3: Request Handled and Response produced");
                logger.LogInformation("MW3: Request Handled and Response produced");
            });
        }
    }
}
