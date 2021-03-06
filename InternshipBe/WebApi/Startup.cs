using AutoMapper;
using BL.Interfaces;
using BL.Mapping;
using BL.Services;
using BL.EmailService;
using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.Infrastructure.Filters;
using Shared.Middleware.Localization;
using System;
using System.Text;
using System.Text.Json;
using BL.Models;
using Hangfire;
using Shared.ExceptionHandling;
using Shared.Middleware.RequestResponceLogger;
using System.IO;
using DAL.DapperRepositories;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();

            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
            services.AddSingleton(emailConfig);

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScoped<IMessageBuilder, MessageBuilder>();

            services.AddScoped<IEmailBodyGenerator, EmailBodyGenerator>();

            services.AddScoped<IReplacerService, ReplacerService>();

            services.AddScoped<IArchiveExpiredRepository, ArchiveExpiredRepository>();

            services.AddControllers()
                    .AddJsonOptions(options =>
                    { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });

            services.AddCors();

            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "JWT Token Authentication API",
                    Description = "Web API"
                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                    }
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "WebApi.xml");
                swagger.IncludeXmlComments(xmlPath);
            });

            services.AddHangfire(options =>
            {
                options.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddHangfireServer();

            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               t => t.UseNetTopologySuite()));

            services.AddIdentity<User, IdentityRole<int>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITownService, TownService>();
            services.AddScoped<IRepository<Town>, Repository<Town>>();

            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IVendorRepository, VendorRepository>();

            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IConfigRepository, ConfigRepository>();

            services.AddScoped<IPointOfSaleService, PointOfSaleService>();
            services.AddScoped<IPointOfSaleRepository, PointOfSaleRepository>();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddScoped<IHangfireService, HangfireService>();

            services.AddScoped<IValidator<Discount>, DiscountValidator>();

            services.AddScoped<ValidateModelFilterAttribute>();

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IArchiveExpiredRepository archiveExpiredRepository)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API"));
            }
            app.UseRequestResponseLogging();

            app.UseGlobalExceptionMiddleware();

            app.UseCulture();

            app.UseRouting();

            app.UseCors(builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHangfireServer();
            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate(() => archiveExpiredRepository.ArchiveExpiredDiscountAsync(), Cron.Daily());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}