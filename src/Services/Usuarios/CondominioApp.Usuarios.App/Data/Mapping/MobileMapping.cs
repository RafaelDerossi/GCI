using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Usuarios.App.Data.Mapping
{
    public class MobileMapping : IEntityTypeConfiguration<Mobile>
    {
        public void Configure(EntityTypeBuilder<Mobile> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Mobiles");

            builder.Property(u => u.DeviceKey).IsRequired().HasColumnType($"varchar({Mobile.Max})");

            builder.Property(u => u.MobileId).IsRequired().HasColumnType($"varchar({Mobile.Max})");

            builder.Property(u => u.Modelo).HasColumnType($"varchar({Mobile.Max})");

            builder.Property(u => u.Plataforma).HasColumnType($"varchar({Mobile.Max})");

            builder.Property(u => u.Versao).HasColumnType($"varchar({Mobile.Max})");

            builder.Property(u => u.MoradorIdFuncionadioId).IsRequired();

        }
    }
}