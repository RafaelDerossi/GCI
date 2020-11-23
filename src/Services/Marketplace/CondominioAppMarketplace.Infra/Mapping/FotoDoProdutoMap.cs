using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppMarketplace.Infra.Mapping
{
    public class FotoDoProdutoMap : IEntityTypeConfiguration<FotoDoProduto>
    {
        public void Configure(EntityTypeBuilder<FotoDoProduto> builder)
        {
            builder.ToTable("FotoDoProduto");

            builder.HasKey(x => x.Id);
         
            builder.Property(x => x.NomeArquivo).HasMaxLength(FotoDoProduto.NomeArquivoMaximo);

            builder.Property(x => x.NomeOriginal).HasMaxLength(FotoDoProduto.NomeOriginalMaximo);

            builder.Property(x => x.Extensao).HasMaxLength(FotoDoProduto.ExtensaoMaximo);
        }
    }
}
