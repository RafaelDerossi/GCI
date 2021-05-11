using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Usuarios.App.Data.Mapping
{
    public class VeiculoCondominioMapping : IEntityTypeConfiguration<VeiculoCondominio>
    {
        public void Configure(EntityTypeBuilder<VeiculoCondominio> builder)
        {
            builder.HasKey(u => u.Id);            

            builder.Property(u => u.Tag).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Observacao).HasColumnType($"varchar(250)");

        }
    }
}