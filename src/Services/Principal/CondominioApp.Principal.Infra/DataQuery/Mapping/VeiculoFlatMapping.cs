using CondominioApp.Principal.Domain.FlatModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Principal.Infra.DataQuery.Mapping
{
    public class VeiculoFlatMapping : IEntityTypeConfiguration<VeiculoFlat>
    {
        public void Configure(EntityTypeBuilder<VeiculoFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("VeiculosFlat");

            builder.Property(u => u.Placa).IsRequired().HasColumnType($"varchar(7)");

            builder.Property(u => u.Modelo).HasColumnType($"varchar({VeiculoFlat.Max})");

            builder.Property(u => u.Cor).HasColumnType($"varchar(30)");            

        }
    }
}