using CondominioApp.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioApp.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //services.AddScoped<IRequestHandler<RegistrarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();

            //services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            //services.AddScoped<IUsuarioQuery, UsuarioQuery>();
           // services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
    }
}