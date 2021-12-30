using GCI.WebApi.Core.Identidade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GCI.Acoes.Infra.Data;
using GCI.Core.Data;
using Microsoft.Extensions.Options;

namespace GCI.Acoes.Api.Configuration
{
    public static class ApiConfig
    {
        private const string PermissoesEspecificasDeOrigem = "_permissoesEspecificasDeOrigem";

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));            

            services.AddScoped<IMongoDbSettings>(serviceProvider =>
               serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddDbContext<ClienteContextDB>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ClienteConnection")));



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