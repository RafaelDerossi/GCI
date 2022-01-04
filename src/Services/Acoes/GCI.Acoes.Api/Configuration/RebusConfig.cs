using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using GCI.Acoes.Aplication.Commands;
using GCI.Acoes.Aplication.Events;
using GCI.Core.Messages;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;

namespace GCI.Acoes.Api.Configuration
{
    public static class RebusConfig
    {
        public static IServiceCollection AddRebusConfiguration(this IServiceCollection services)
        {
            // Configure and register Rebus

            var nomeFila = "fila_acao";

            services.AddRebus(configure => configure
                //.Transport(t => t.UseInMemoryTransport(new InMemNetwork(), nomeFila))
                //.Subscriptions(s => s.StoreInMemory())
                .Transport(t => t.UseRabbitMq("amqp://localhost", nomeFila))                
                .Routing(r =>
                {
                    r.TypeBased()
                        .MapAssemblyOf<Message>(nomeFila);
                        
                })
                .Sagas(s => s.StoreInMemory())
                .Options(o =>
                {
                    o.SetNumberOfWorkers(1);
                    o.SetMaxParallelism(1);                    
                    o.SetBusName("Bus Acao");
                })
            );

            // Register handlers             
            services.AutoRegisterHandlersFromAssemblyOf<AcaoEventHandler>();

            return services;
        }

        public static IApplicationBuilder UseRebusConfiguration(this IApplicationBuilder app)
        {
            app.ApplicationServices.UseRebus(c =>
            {
                c.Subscribe<AcaoAdicionadaEvent>().Wait();
                c.Subscribe<OperacaoAdicionadaEvent>().Wait();
            });

            return app;
        }
    }
}