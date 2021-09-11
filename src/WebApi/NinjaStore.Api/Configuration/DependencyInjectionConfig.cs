using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace NinjaStore.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();            
            

            #region Cliente -Contexto

            //Cliente
            //services.AddScoped<IRequestHandler<AdicionarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();            
            //services.AddScoped<INotificationHandler<RegistraHistoricoEvent>, HistoricoEventHandler>();            
            #endregion

            #region Produto -Contexto
            //Produto
            
            #endregion

            #region Pedido -Contexto

            //Pedido            
            
            #endregion



            #region Querys            
            //services.AddScoped<ICorrespondenciaQuery, CorrespondenciaQuery>();            
            //services.AddScoped<IOcorrenciaQuery, OcorrenciaQuery>();            
            //services.AddScoped<IPrincipalQuery, PrincipalQuery>();
            #endregion

            #region Repositórios                        
            //services.AddScoped<ICorrespondenciaRepository, CorrespondenciaRepository>();            
            //services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();            
            //services.AddScoped<IPrincipalRepository, PrincipalRepository>();            
            
            #endregion

            #region Repositórios Query                           
            //services.AddScoped<IPrincipalQueryRepository, PrincipalQueryRepository>();                                    
            #endregion
            
        }
    }
}
