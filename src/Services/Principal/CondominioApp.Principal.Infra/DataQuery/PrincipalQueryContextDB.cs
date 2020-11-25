using CondominioApp.Core.Data;
using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
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
            return await SaveChangesAsync() > 0; 

        }
    }
}
