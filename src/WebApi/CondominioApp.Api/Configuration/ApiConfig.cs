using CondominioApp.ArquivoDigital.App.Data;
using CondominioApp.Automacao.App.Models;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Correspondencias.App.Data;
using CondominioApp.Enquetes.App.Data;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Portaria.Infra.Data;
using CondominioApp.Portaria.Infra.DataQuery;
using CondominioApp.Principal.Infra.Data;
using CondominioApp.Principal.Infra.DataQuery;
using CondominioApp.ReservaAreaComum.Infra.Data;
using CondominioApp.Usuarios.App.Data;
using CondominioApp.WebApi.Core.Identidade;
using CondominioAppMarketplace.Infra.Data;
using CondominioAppPreCadastro.App.Data;
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
            services.AddDbContext<UsuarioContextDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UsuariosConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddDbContext<PrincipalContextDB>(options =>
               options.UseSqlServer(configuration.GetConnectionString("PrincipalConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddDbContext<PreCadastroContextDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PreCadastroConnection")));

            services.AddDbContext<MarketplaceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MarketplaceConnection")));          

            services.AddDbContext<EnqueteContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("EnqueteConnection")));

            services.AddDbContext<CorrespondenciaContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("CorrespondenciaConnection")));

            services.AddDbContext<ComunicadoContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("ComunicadoConnection")));                       

            services.AddDbContext<ReservaAreaComumContextDB>(options =>
             options.UseSqlServer(configuration.GetConnectionString("ReservaAreaComumConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddDbContext<PortariaContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("PortariaConnection")));          

            services.AddDbContext<AutomacaoContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("AutomacaoConnection")));

            services.AddDbContext<ArquivoDigitalContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("ArquivoDigitalConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddDbContext<OcorrenciaContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("OcorrenciaConnection")));


            //Query Contexts
            services.AddDbContext<UsuarioQueryContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("QueryConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);
            
            services.AddDbContext<PrincipalQueryContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("QueryConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddDbContext<ReservaAreaComumQueryContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("QueryConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddDbContext<PortariaQueryContextDB>(options =>
              options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));



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