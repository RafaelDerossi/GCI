using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CondominioApp.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "CondominioApp API 2.0",
                    Description = "Esta api expõe os recursos do sistema condominioapp para diversas interfaces (web/mobile) e serviços auxiliares como Marketplace, integrações com administradoras e features de tempo real.",
                    Contact = new OpenApiContact() { Name = "CondominioApp Developer", Email = "contato@condominioapp.com"},
                    License = new OpenApiLicense() { Name = "CondominioApp", Url = new Uri("https://www.condominioapp.com")}
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