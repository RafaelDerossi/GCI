using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppMarketplace.Infra.Mapping
{
    public class CampanhaMap : IEntityTypeConfiguration<Campanha>
    {
        public void Configure(EntityTypeBuilder<Campanha> builder)
        {
            builder.ToTable("Campanha");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Banner).HasMaxLength(Campanha.BannerMaximo);

            builder.Property(x => x.Titulo).HasMaxLength(Campanha.TituloMaximo);

            builder.Property(x => x.Descricao).HasMaxLength(Campanha.DescricaoMaximo);
        }
    }
}
