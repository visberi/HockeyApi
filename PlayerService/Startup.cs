using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PlayerService.Controllers;
using PlayerService.Data;
using PlayerService.DataModel;
using PlayerService.Properties;

namespace PlayerService
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
            services.AddControllers();

            services.AddMvc();

            services.AddSwaggerGen();

            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // This is a demo application, disabled https
            //app.UseHttpsRedirection();

            // Enable Swagger api documentation service
            app.UseSwagger();

            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hockey Player API V1");
                    c.RoutePrefix = string.Empty; // This makes the server server Swagger in app root
                });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Initialize the data here. Would not be correct place in production app...
            PlayerRepository.InitializePlayerDataFromCsv(Resources.DefaultPlayerData);
        }
    }
}
