using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppMarketplace.Infra.Mapping
{
    public class ItemDeVendaMap : IEntityTypeConfiguration<ItemDeVenda>
    {
        public void Configure(EntityTypeBuilder<ItemDeVenda> builder)
        {
            builder.ToTable("ItemDeVenda");

            builder.HasKey(x => x.Id);
          
        }
    }
}
