using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using NinjaStore.Clientes.Aplication.Commands;
using NinjaStore.Clientes.Aplication.Events;
using NinjaStore.Clientes.Aplication.Query;
using NinjaStore.Clientes.Domain.Interfaces;
using NinjaStore.Clientes.Infra.Data.Repository;

namespace NinjaStore.Clientes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();

                        
            //Cliente
            services.AddScoped<IRequestHandler<AdicionarClienteCommand, ValidationResult>, ClienteCommandHandler>();            
            services.AddScoped<INotificationHandler<ClienteAdicionadoEvent>, ClienteEventHandler>();
            
            //Query
            services.AddScoped<IClienteQuery, ClienteQuery>();
            
            //Repositório            
            services.AddScoped<IClienteRepository, ClienteRepository>();                        

            //Repositório Query
            services.AddScoped<IClienteQueryRepository, ClienteQueryRepository>();

            
        }
    }
}
