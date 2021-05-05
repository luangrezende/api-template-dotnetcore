using Template.Project.CrossCutting.AutoMapping;
using Template.Project.Infrastructure.DBContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Template.Project.CrossCutting.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace Template.Project
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
            services.AddControllers()
                .AddFluentValidation();

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
                    //    Url = new Uri("https://google.com"),
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

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ConnectionName")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddServices();
            services.AddRepositories();
            services.AddValidations();
            services.AddAutoMapping();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
