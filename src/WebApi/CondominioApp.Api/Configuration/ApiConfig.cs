﻿using CondominioApp.WebApi.Core.Identidade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CondominioApp.Api.Configuration
{
    public static class ApiConfig
    {
        private const string PermissoesEspecificasDeOrigem = "_permissoesEspecificasDeOrigem";

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            //Contexts
            //services.AddDbContext<UsuarioContextDB>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("UsuariosConnection")));

            //services.AddDbContext<PrincipalContextDB>(options =>
            //   options.UseSqlServer(configuration.GetConnectionString("PrincipalConnection")));

            //services.AddDbContext<PreCadastroContextDB>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("PreCadastroConnection")));
          


            //Query Contexts
            //services.AddDbContext<UsuarioQueryContextDB>(options =>
            //  options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));
            
            //services.AddDbContext<PrincipalQueryContextDB>(options =>
            //  options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));

            //services.AddDbContext<ReservaAreaComumQueryContextDB>(options =>
            //  options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));

        

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy(PermissoesEspecificasDeOrigem,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(PermissoesEspecificasDeOrigem);

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}