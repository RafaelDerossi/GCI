using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using NinjaStore.Clientes.Aplication.Commands;
using NinjaStore.Clientes.Aplication.Query;
using NinjaStore.Clientes.Domain.Interfaces;
using NinjaStore.Clientes.Infra.Data.Repository;
using NinjaStore.Core.Data;

namespace NinjaStore.Clientes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            //Cliente
            services.AddScoped<IRequestHandler<AdicionarClienteCommand, ValidationResult>, ClienteCommandHandler>();            
                        
            //Query
            services.AddScoped<IClienteQuery, ClienteQuery>();
            
            //Repositório            
            services.AddScoped<IClienteRepository, ClienteRepository>();                                    


            

        }
    }
}
