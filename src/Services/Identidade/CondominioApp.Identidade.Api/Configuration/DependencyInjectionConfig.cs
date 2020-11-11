using CondominioApp.Core.Mediator;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Aplication.Event;
using CondominioApp.Usuarios.App.Data.Repository;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioApp.Identidade.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();            

            services.AddScoped<IRequestHandler<CadastrarMoradorCommand, ValidationResult>, UsuarioCommandHandler>();

            services.AddScoped<INotificationHandler<MoradorCadastradoEvent>, UsuarioEventHandler>();
                       
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
    }
}