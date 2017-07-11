using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

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
                .AddMvcOptions(o => o.OutputFormatters.Add(
                   new XmlDataContractSerializerOutputFormatter()));
            // UK - Default contract resolver for casted resolver
            // UK - Contract resolver is used to determine what is avaliable in the contract resolver.
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

            // Scoped lifetime services are created once per request
            // Singleton lifetime servers are created the first time they are requested.

            //UK - Transient life time services are created each time they are requested
            // We are using Transient since the the service is light weight
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // UK - Configure is used to specify how an ASP.NET application will respond to individual HTTP requests
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            loggerFactory.AddNLog();


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
