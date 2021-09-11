using CondominioApp.Core.Data;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.ValueObjects;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Infra.DataQuery
{
    public class PortariaQueryContextDB : DbContext, IUnitOfWorks
    {     

        public DbSet<VisitanteFlat> VisitantesFlat { get; set; }

        public DbSet<VisitaFlat> VisitasFlat { get; set; }      

        public PortariaQueryContextDB(DbContextOptions<PortariaQueryContextDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortariaQueryContextDB).Assembly);

            modelBuilder.Ignore<Visitante>();
            modelBuilder.Ignore<Visita>();
            modelBuilder.Ignore<Cpf>();
            modelBuilder.Ignore<Rg>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Foto>();
            modelBuilder.Ignore<Veiculo>();
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
