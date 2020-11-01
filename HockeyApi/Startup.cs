using HockeyApi.Data;
using HockeyApi.Properties;
using HockeyApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HockeyApi
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

            services.AddSingleton<IPlayerService>(new PlayerService());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");


            // This is a demo application, disabled https to avoid certificate hassle
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
