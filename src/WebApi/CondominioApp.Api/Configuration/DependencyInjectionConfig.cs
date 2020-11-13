using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Infra.Data.Repository;
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

            services.AddScoped<IRequestHandler<CadastrarCondominioCommand, ValidationResult>, CondominioCommandHandler>();

            //services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            services.AddScoped<IRequestHandler<CadastrarGrupoCommand, ValidationResult>, GrupoCommandHandler>();

            //services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            services.AddScoped<IRequestHandler<CadastrarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();

            //services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            services.AddScoped<IRequestHandler<AlterarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();

            //services.AddScoped<IUsuarioQuery, UsuarioQuery>();
            // services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped(typeof(ICondominioRepository), typeof(CondominioRepository));

            //services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
    }
}