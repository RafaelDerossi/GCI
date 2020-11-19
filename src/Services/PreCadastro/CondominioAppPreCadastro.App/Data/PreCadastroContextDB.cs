using System;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Core.Extensions;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages;
using CondominioAppPreCadastro.App.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace CondominioAppPreCadastro.App.Data
{
    public class PreCadastroContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<Lead> Leads { get; set; }

        public DbSet<Condominio> Condominios { get; set; }

        public DbSet<Arquivo> Arquivos { get; set; }

        public PreCadastroContextDB(DbContextOptions<PreCadastroContextDB> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PreCadastroContextDB).Assembly);
        }

        public async Task<bool> Commit()
        {
            var cetZone = ZonaDeTempo.ObterZonaDeTempo();

            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataDeCadastro").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }

            var sucesso = await SaveChangesAsync() > 0;
            if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}