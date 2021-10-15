using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Aplication.Events;
using NinjaStore.Core.Messages;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using NinjaStore.Core.Messages.IntegrationEvents.Pedidos;
using Rebus.Transport.InMem;

namespace NinjaStore.Pedidos.Api.Configuration
{
    public static class RebusConfig
    {
        public static IServiceCollection AddRebusConfiguration(this IServiceCollection services)
        {
            // Configure and register Rebus

            var nomeFila = "fila_pedido";

            services.AddRebus(configure => configure
                //.Transport(t => t.UseInMemoryTransport(new InMemNetwork(), nomeFila))
                //.Subscriptions(s => s.StoreInMemory())
                .Transport(t => t.UseRabbitMq("amqp://localhost", nomeFila))                
                .Routing(r =>
                {
                    r.TypeBased()
                        .MapAssemblyOf<Message>(nomeFila)                        
                        .MapAssemblyOf<AprovarPedidoCommand>(nomeFila)
                        .MapAssemblyOf<CancelarPedidoCommand>(nomeFila);                    
                })
                .Sagas(s => s.StoreInMemory())                
                .Options(o =>
                {
                    o.SetNumberOfWorkers(1);
                    o.SetMaxParallelism(1);
                    o.SetBusName("Demo Rebus");                    
                })
                
            );

            // Register handlers             
            services.AutoRegisterHandlersFromAssemblyOf<PedidoCommandHandler>();
            services.AutoRegisterHandlersFromAssemblyOf<PedidoEventHandler>();

            return services;
        }

        public static IApplicationBuilder UseRebusConfiguration(this IApplicationBuilder app)
        {
            app.ApplicationServices.UseRebus(c =>
            {
                c.Subscribe<PedidoAdicionadoEvent>().Wait();
                c.Subscribe<EstoqueDoPedidoDebitadoEvent>().Wait();
                c.Subscribe<EstoqueDoPedidoInsuficienteEvent>().Wait();
                c.Subscribe<PedidoAprovadoEvent>().Wait();
                c.Subscribe<PedidoCanceladoEvent>().Wait();
            });

            return app;
        }
    }
}