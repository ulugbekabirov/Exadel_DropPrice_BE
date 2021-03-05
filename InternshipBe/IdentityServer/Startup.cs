using DAL.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL.Entities;
using System.Text.Json;
using Shared.ExceptionHandling;
using Microsoft.OpenApi.Models;
using Shared.Middleware.RequestResponceLogger;
using System.IO;
using System;

namespace IdentityServer
{
    /// <summary>
    /// Class that is the entry point to the application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup constructor  
        /// </summary>
        /// <param name="configuration">Object containing basic application settings</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Property containing basic application settings
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Method that registers services
        /// </summary>
        /// <param name="services">Represents a collection of services in an application</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                    { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Identity Server" });

                //Set the comments path for the swagger json and ui.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "IdentityServer.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                t => t.UseNetTopologySuite()));

            services.AddIdentity<User, IdentityRole<int>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
        }

        /// <summary>
        /// The method sets how the application will process the request.
        /// </summary>
        /// <param name="app">Object for configuring the application request pipeline</param>
        /// <param name="env">Object containing information about the environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API"));
            }

            app.UseGlobalExceptionMiddleware();

            app.UseRequestResponseLogging();

            app.UseRouting();

            app.UseCors(builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
