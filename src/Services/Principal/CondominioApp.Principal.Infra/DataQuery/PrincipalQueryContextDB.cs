using CondominioApp.Core.Data;
using CondominioApp.Core.Extensions;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
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
        }

        public async Task<bool> Commit()
        {
            try
            {
                var sucesso = await SaveChangesAsync() > 0;
                if (sucesso) await _mediatorHandler.PublicarEventos(this);

                return sucesso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
