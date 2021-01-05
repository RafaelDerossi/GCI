using CondominioApp.Core.Data;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Infra.DataQuery
{
    public class ReservaAreaComumQueryContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<AreaComumFlat> AreasComunsFlat { get; set; }
        public DbSet<PeriodoFlat> PeriodosFlat { get; set; }
        public DbSet<ReservaFlat> ReservasFlat { get; set; }
      
        public ReservaAreaComumQueryContextDB(DbContextOptions<ReservaAreaComumQueryContextDB> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReservaAreaComumQueryContextDB).Assembly);

            modelBuilder.Ignore<AreaComum>();
            modelBuilder.Ignore<Periodo>();
            modelBuilder.Ignore<Reserva>();           
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

            return await SaveChangesAsync() > 0;
        }
    }
}
