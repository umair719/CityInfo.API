using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // UK - ConfigureServices is used to add services to the container, and to configure those services
            // UK - Adding MCV framework services (does not show up by default)
            services.AddMvc()
                // UK - Default contract resolver for casted resolver
                //.AddJsonOptions(o =>
                //{
                //    if (o.SerializerSettings.ContractResolver != null)
                //    {
                //        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                //        // UK - This will make the names returned in JSON to be exactly the same as specified in the application.
                //        // UK - Without this, the names specified in the JSON object will be uisng camel case
                //        // UK - This will be usefull when working with legacy apps.
                //        castedResolver.NamingStrategy = null;
                //    }
                //})
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // UK - Configure is used to specify how an ASP.NET application will respond to individual HTTP requests
            loggerFactory.AddConsole();
            // UK - Enviroment can be specifed
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            // UK - use built in status code page. This is going to return text based string.
            app.UseStatusCodePages();

            // UK - reference of MVC service
            app.UseMvc();

            // UK - Example of middleware
            //app.Run((context) =>
            //{
            //    throw new Exception("Example exception");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
