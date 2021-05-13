using CondominioApp.Core.Data;
using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.Core.Extensions;
using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages;
using FluentValidation.Results;

namespace CondominioAppMarketplace.Infra.Data
{
    public class MarketplaceContext : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;
        public DbSet<Parceiro> Parceiros { get; set; }

        public DbSet<Campanha> Campanhas { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<FotoDoProduto> FotosDosProdutos { get; set; }

        public DbSet<Lead> Leads { get; set; }

        public DbSet<ItemDeVenda> ItensDeVenda { get; set; }

        public DbSet<Vendedor> Vendedores { get; set; }

        

        public MarketplaceContext(DbContextOptions<MarketplaceContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketplaceContext).Assembly);

            ////Configuração de relacionamento evitando conflito em cascata                       
            modelBuilder.Entity<Campanha>()
                .HasOne(x => x.ItemDeVenda)
                .WithMany(x => x.Campanhas)
                .HasForeignKey(x => x.ItemDeVendaId)
                .OnDelete(DeleteBehavior.Restrict);

            ////Configuração de relacionamento evitando conflito em cascata   
            modelBuilder.Entity<ItemDeVenda>()
                .HasOne(x => x.Vendedor)
                .WithMany(x => x.ItensDeVenda)
                .HasForeignKey(x => x.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public async Task<bool> Commit()
        {
            var cetZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataDeCadastro").CurrentValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }

            var sucesso = await SaveChangesAsync() > 0;
            if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}