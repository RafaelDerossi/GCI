using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GCI.Core.DomainObjects;
using GCI.Core.Mediator;
using Microsoft.EntityFrameworkCore;
using Rebus.Bus;

namespace GCI.Core.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventosDeDominio<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventosDeDominio());


            foreach (var item in domainEvents)
            {
                await mediator.PublicarEvento(item);
                Thread.Sleep(500);
            }
            //var tasks = domainEvents
            //    .Select(async (domainEvent) =>
            //    {
            //        await mediator.PublicarEvento(domainEvent);                    
            //    });

            //await Task.WhenAll(tasks);
        }
    }

    public static class RebusExtension
    {
        public static async Task EnfileirarEventos<T>(this IBus bus, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Mensagens != null && x.Entity.Mensagens.Any());

            var events = domainEntities
                .SelectMany(x => x.Entity.Mensagens)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());


            foreach (var item in events)
            {
                await bus.Publish(item);                
            }        
        }
    }

}
