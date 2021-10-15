using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Aplication.Events;
using NinjaStore.Core.Messages;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using NinjaStore.Core.Messages.IntegrationEvents.Pedidos;
using Rebus.Transport.InMem;

namespace NinjaStore.Produtos.Api.Configuration
{
    public static class RebusConfig
    {
        public static IServiceCollection AddRebusConfiguration(this IServiceCollection services)
        {
            // Configure and register Rebus

            var nomeFila = "fila_produto";

            services.AddRebus(configure => configure
                //.Transport(t => t.UseInMemoryTransport(new InMemNetwork(), nomeFila))
                //.Subscriptions(s => s.StoreInMemory())
                .Transport(t => t.UseRabbitMq("amqp://localhost", nomeFila))                
                .Routing(r =>
                {
                    r.TypeBased()
                        .MapAssemblyOf<Message>(nomeFila)
                        .MapAssemblyOf<DebitarEstoqueCommand>(nomeFila);
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
            services.AutoRegisterHandlersFromAssemblyOf<ProdutoCommandHandler>();
            services.AutoRegisterHandlersFromAssemblyOf<ProdutoEventHandler>();

            return services;
        }

        public static IApplicationBuilder UseRebusConfiguration(this IApplicationBuilder app)
        {
            app.ApplicationServices.UseRebus(c =>
            {
                c.Subscribe<ProdutoAdicionadoEvent>().Wait();
                c.Subscribe<PedidoAdicionadoEvent>().Wait();
                c.Subscribe<EstoqueDoProdutoDebitadoEvent>().Wait();
            });

            return app;
        }
    }
}