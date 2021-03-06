using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Middleware;
using Api.Middleware.Swagger;
using API.Extensions;
using API.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public IConfiguration _config { get; set; }
        public Startup(IConfiguration config)
        {
            _config = config;
       
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddApplicationServices(_config);
            services.AddControllers();
            services.ConfigureCorsService();
            services.ConfigureApiVersioningService();
           services.ConfigureSwaggerServices();
            services.AddIdentityServices(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IApiVersionDescriptionProvider provider)
        {
             
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("ApiCorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
             app.ConfigureSwagger(provider);
        }
    }
}
