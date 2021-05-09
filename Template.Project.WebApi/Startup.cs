using Microsoft.AspNetCore.Authentication.JwtBearer;
using Template.Project.CrossCutting.AutoMapping;
using Template.Project.Infrastructure.DBContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Template.Project.CrossCutting.DI;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.IO;
using System;

namespace Template.Project
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation();

            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<DBContext>(options => options.UseNpgsql(_configuration.GetConnectionString("NoSQL")));

            services.AddServices();
            services.AddRepositories();
            services.AddProxies();
            services.AddValidations();
            services.AddAutoMapping();
            services.AddCors();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Template.Project.WebApi",
                    Description = "API Template",
                    TermsOfService = new Uri("https://example.com/terms"),
                        //Contact = new OpenApiContact
                        //{
                        //    Name = "Contact Name",
                        //    Email = string.Empty,
                        //    Url = new Uri("https://example.com"),
                        //},
                        //License = new OpenApiLicense
                        //{
                        //    Name = "License",
                        //    Url = new Uri("https://example.com/license"),
                        //}
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Secret"]))
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/template/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/template/swagger/v1/swagger.json", "Template API v1");
                c.RoutePrefix = "api/template/swagger";
                c.DocumentTitle = "Template API - v1";
            });
        }
    }
}
