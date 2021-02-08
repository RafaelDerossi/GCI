using CondominioApp.Core.Data;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Infra.DataQuery
{
    public class PrincipalQueryContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<CondominioFlat> CondominiosFlat { get; set; }

        public DbSet<GrupoFlat> GruposFlat { get; set; }

        public DbSet<UnidadeFlat> UnidadesFlat { get; set; }
        

        public PrincipalQueryContextDB(DbContextOptions<PrincipalQueryContextDB> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrincipalQueryContextDB).Assembly);

            modelBuilder.Ignore<Condominio>();
            modelBuilder.Ignore<Grupo>();
            modelBuilder.Ignore<Unidade>();
            modelBuilder.Ignore<Cnpj>();
            modelBuilder.Ignore<Cpf>();
            modelBuilder.Ignore<Foto>();
            modelBuilder.Ignore<Endereco>();
            modelBuilder.Ignore<Url>();
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
