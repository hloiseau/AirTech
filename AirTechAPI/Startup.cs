using AirTech.Server.DAO;
using AirTech.Server.Models;
using AirTech.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace AirTechAPI
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
            services.AddDbContext<AirTechContext>(options =>
                options.UseSqlServer(Configuration["SqlCoString"]));

            ConfigureAdditionalServices(services);

            services.AddSwaggerGen(o =>
            {
                o.CustomSchemaIds(t => t.ToString());
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                o.IncludeXmlComments(xmlPath);
            });
        }

        protected virtual void ConfigureAdditionalServices(IServiceCollection services)
        {
            services.AddTransient<TravelDAO>();
            services.AddTransient<ClientDAO>();
            services.AddTransient<AirportDAO>();
            services.AddTransient<BilletDAO>();
            services.AddTransient<OrderDAO>();
            services.AddTransient<VoyagerDAO>();
            services.AddTransient<HttpClient>();
            services.AddSingleton<IntechAirFranceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
