using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_HostingProcess_Launchsettings
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Process :- " + System.Diagnostics.Process.GetCurrentProcess().ProcessName + "\n" + "Environment :- " + env.EnvironmentName);
            });

            // Note:- environment-name can be changed form launchSettings.json (for local purpose)
            // If you forget to set environment then default environment ->> Production

            // for chaning hosting type (Inprocess/OutOfProcess) --> change from Project-Properties --> Debug section
        }
    }
}
