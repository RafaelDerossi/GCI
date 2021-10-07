using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NinjaStore.Clientes.Aplication.Commands;
using NinjaStore.Clientes.Aplication.Events;
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
                        .MapAssemblyOf<Message>(nomeFila)
                        .MapAssemblyOf<ClienteCommand>(nomeFila)
                        .MapAssemblyOf<ClienteEvent>(nomeFila);
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
            services.AutoRegisterHandlersFromAssemblyOf<ClienteCommandHandler>();
            services.AutoRegisterHandlersFromAssemblyOf<ClienteEventHandler>();

            return services;
        }

        public static IApplicationBuilder UseRebusConfiguration(this IApplicationBuilder app)
        {           
            app.UseRebus(c =>
            {
                c.Subscribe<ClienteAdicionadoEvent>().Wait();                
            });

            return app;
        }
    }
}