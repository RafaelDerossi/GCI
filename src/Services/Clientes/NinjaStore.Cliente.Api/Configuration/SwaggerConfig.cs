﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GCI.Acoes.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "GCI - Gestor de Carteira de Investimentos API 1.0",
                    Description = "Esta api expõe os recursos do sistema GCI relacionados a Ações para diversas interfaces (web/mobile).",
                    Contact = new OpenApiContact() { Name = "Rafael Derossi - Developer", Email = "rafaelsderossi@gmail.com"},
                    License = new OpenApiLicense() { Name = "GCI", Url = new Uri("https://www.linkedin.com/in/rafael-derossi") }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../../swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}