using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Infra.Data.Repository;
using CondominioAppPreCadastro.App.Aplication.Commands;
using CondominioAppPreCadastro.App.Data.Repository;
using CondominioAppPreCadastro.App.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioApp.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<InserirNovoLeadCommand, ValidationResult>, LeadCommandHandler>();

            services.AddScoped<IRequestHandler<CadastrarCondominioCommand, ValidationResult>, CondominioCommandHandler>();

            services.AddScoped<IRequestHandler<AlterarCondominioCommand, ValidationResult>, CondominioCommandHandler>();

            services.AddScoped<IRequestHandler<AlterarConfiguracaoCondominioCommand, ValidationResult>, CondominioCommandHandler>();

            //services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            services.AddScoped<IRequestHandler<CadastrarGrupoCommand, ValidationResult>, GrupoCommandHandler>();

            //services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            services.AddScoped<IRequestHandler<CadastrarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();

            //services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            services.AddScoped<IRequestHandler<AlterarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();

            services.AddScoped<IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();

            services.AddScoped<IRequestHandler<AlterarGrupoCommand, ValidationResult>, GrupoCommandHandler>();

            //services.AddScoped<IUsuarioQuery, UsuarioQuery>();
            // services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICondominioRepository, CondominioRepository>();

            services.AddScoped<ILeadRepository, LeadRepository>();

            //services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
    }
}