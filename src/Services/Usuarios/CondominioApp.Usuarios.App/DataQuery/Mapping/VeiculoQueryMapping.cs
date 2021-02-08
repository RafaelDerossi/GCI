using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Usuarios.App.Data.Mapping
{
    public class VeiculoQueryMapping : IEntityTypeConfiguration<VeiculoFlat>
    {
        public void Configure(EntityTypeBuilder<VeiculoFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("VeiculosFlat");

            builder.Property(u => u.Placa).IsRequired().HasColumnType($"varchar(7)");

            builder.Property(u => u.Modelo).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Cor).HasColumnType($"varchar(30)");            

        }
    }
}