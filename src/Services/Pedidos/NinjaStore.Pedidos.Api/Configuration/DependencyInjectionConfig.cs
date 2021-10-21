using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Domain.Interfaces;
using NinjaStore.Pedidos.Infra.Data.Repository;
using NinjaStore.Pedidos.Aplication.Events;
using NinjaStore.Pedidos.Aplication.Query;
using NinjaStore.Core.Data;

namespace NinjaStore.Pedidos.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            //Pedido            
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            //Query            
            services.AddScoped<IPedidoQuery, PedidoQuery>();
            services.AddScoped<IClienteQuery, ClienteQuery>();

            //Repositório            
            services.AddScoped<IPedidoRepository, PedidoRepository>();            
        }
    }
}
