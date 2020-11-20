using CondominioApp.Core.ValueObjects;
using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppMarketplace.Infra.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
           
            builder.Property(x => x.Nome).HasMaxLength(Produto.NomeMaximo);

            builder.Property(x => x.Descricao).HasMaxLength(Produto.DescricaoMaximo);

            builder.Property(x => x.Chamada).HasMaxLength(Produto.ChamadaMaximo);

            builder.OwnsOne(x => x.Url, endereco =>
            {
                endereco.Property(x => x.Endereco).HasColumnName("Link").HasMaxLength(Url.TamanhoMaximo);
            });
        }
    }
}
