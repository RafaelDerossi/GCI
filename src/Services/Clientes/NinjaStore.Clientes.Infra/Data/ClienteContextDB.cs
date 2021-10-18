using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NinjaStore.Clientes.Domain;
using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Core.Data;
using NinjaStore.Core.Extensions;
using NinjaStore.Core.Helpers;
using NinjaStore.Core.Mediator;
using NinjaStore.Core.Messages.CommonMessages;
using Rebus.Bus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Infra.Data
{
    public class ClienteContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        private readonly IBus _bus;

        public DbSet<Cliente> Clientes { get; set; }


        public ClienteContextDB(DbContextOptions<ClienteContextDB> options,
                   IMediatorHandler mediatorHandler, IBus bus)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
            _bus = bus;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteContextDB).Assembly);

            modelBuilder.Ignore<ClienteFlat>();
        }

        public async Task<bool> Commit()
        {
            var cetZone = ZonaDeTempo.ObterZonaDeTempo();

            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCadastro").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                    entry.Property("DataDeAlteracao").CurrentValue =
                        entry.Property("DataDeCadastro").CurrentValue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }

            var sucesso = await SaveChangesAsync() > 0;
            if (sucesso)
            {
                await _mediatorHandler.PublicarEventosDeDominio(this);
                await _bus.EnfileirarEventos(this);
            }

            return sucesso;
          
        }
    }
}
