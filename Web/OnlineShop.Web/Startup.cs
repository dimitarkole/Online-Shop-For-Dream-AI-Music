namespace OnlineShop.Web
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using OnlineShop.Data;
    using OnlineShop.Data.Common;
    using OnlineShop.Data.Common.Repositories;
    using OnlineShop.Data.Models;
    using OnlineShop.Data.Repositories;
    using OnlineShop.Data.Seeding;
    using OnlineShop.Services;
    using OnlineShop.Services.Data;
    using OnlineShop.Services.Interfaces;
    using OnlineShop.Services.Mapping;
    using OnlineShop.Services.Messaging;
    using OnlineShop.Web.Infrastucture.Extensions;
    using OnlineShop.Web.Infrastucture.Filters;
    using OnlineShop.Web.ViewModels;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; protected set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
              .AddDatabase(this.Configuration)
              .AddIdentity()
              .AddJwtAuthentication(services.GetAppSettings(this.Configuration))
              .AddApplicationServices()
              .AddCors(options => options.AddPolicy("AllowWebApp", builder => builder
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithOrigins("http://localhost:4200", "http://localhost:5000", "https://localhost:4200", "https://localhost:5000")))
              .AddSwagger(this.Configuration)
              .AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidateModelStateActionFilter>();
                options.Filters.Add<ExceptionFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            /* using (var serviceScope = app.ApplicationServices.CreateScope())
             {
                 var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                 dbContext.Database.Migrate();
                 new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
             }*/

            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app
                 .UseSwagger()
                 .UseSwaggerUI(options =>
                 {
                     options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                     options.RoutePrefix = string.Empty;
                 })
                .UseRouting()
                .UseCors("AllowWebApp")
                .UseCors(options => options
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200"))
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
