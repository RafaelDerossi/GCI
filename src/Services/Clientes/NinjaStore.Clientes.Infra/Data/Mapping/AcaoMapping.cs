using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GCI.Acoes.Domain;
using GCI.Core.ValueObjects;

namespace GCI.Acoes.Infra.Data.Mapping
{
   public class AcaoMapping : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Acoes");

            builder.Property(u => u.Codigo).IsRequired().HasColumnType($"varchar(50)");            

            builder.Property(u => u.RazaoSocial).IsRequired().HasColumnType($"varchar(300)");

        }
    }
}
