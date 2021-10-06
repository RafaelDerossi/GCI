using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NinjaStore.Core.Messages;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;

namespace NinjaStore.Clientes.Api.Configuration
{
    public static class RebusConfig
    {
        public static IServiceCollection AddRebusConfiguration(this IServiceCollection services)
        {
            // Configure and register Rebus

            var nomeFila = "fila_rebus";

            services.AddRebus(configure => configure
                //.Transport(t => t.UseInMemoryTransport(new InMemNetwork(), nomeFila))
                .Transport(t => t.UseRabbitMq("amqp://localhost", nomeFila))
                //.Subscriptions(s => s.StoreInMemory())
                .Routing(r =>
                {
                    r.TypeBased()
                        .MapAssemblyOf<Message>(nomeFila);
                        //.MapAssemblyOf<RealizarPedidoCommand>(nomeFila)
                        //.MapAssemblyOf<RealizarPagamentoCommand>(nomeFila);
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
            //services.AutoRegisterHandlersFromAssemblyOf<PagamentoCommandHandler>();
            //services.AutoRegisterHandlersFromAssemblyOf<PedidoSaga>();

            return services;
        }

        public static IApplicationBuilder UseRebusConfiguration(this IApplicationBuilder app)
        {           
            app.UseRebus(c =>
            {
                c.Subscribe<PedidoRealizadoEvent>().Wait();
                c.Subscribe<PagamentoRealizadoEvent>().Wait();
                c.Subscribe<PedidoFinalizadoEvent>().Wait();
                c.Subscribe<PagamentoRecusadoEvent>().Wait();
                c.Subscribe<PedidoCanceladoEvent>().Wait();
            });

            return app;
        }
    }
}