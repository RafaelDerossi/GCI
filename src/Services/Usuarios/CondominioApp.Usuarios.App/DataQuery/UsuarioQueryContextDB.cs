using System;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.ValueObjects;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Usuarios.App.Data
{
    public class UsuarioQueryContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<VeiculoFlat> VeiculosFlat { get; set; }
        public DbSet<MoradorFlat> MoradoresFlat { get; set; }


        public UsuarioQueryContextDB(DbContextOptions<UsuarioQueryContextDB> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioQueryContextDB).Assembly);

            modelBuilder.Ignore<Usuario>();
            modelBuilder.Ignore<Morador>();
            modelBuilder.Ignore<Funcionario>();
            modelBuilder.Ignore<Veiculo>();
            modelBuilder.Ignore<VeiculoCondominio>();
            modelBuilder.Ignore<Cpf>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Endereco>();
            modelBuilder.Ignore<Foto>();

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

            return await SaveChangesAsync() > 0;            
        }
    }
}
