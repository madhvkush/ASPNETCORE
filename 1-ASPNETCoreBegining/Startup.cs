using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ASPNETCoreBegining
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
            // Middleware :-  is a piece of software that can handle an HTTP request or response.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("MW1: Incoming Request \n" );
                await next();
                await context.Response.WriteAsync("MW1: Outgoing Response \n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("MW2: Incoming Request \n");
                await next();
                await context.Response.WriteAsync("MW2: Outgoing Response \n");
            });


            // Run() --> This would be terminal middleware, it will not allow to invoke further any middleware
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3: Request handled and response produced \n");
            });


            // Tip :- for adding .gitignore simply run this command on console/cmd  ->> dotnet new gitignore

        }
    }
}
