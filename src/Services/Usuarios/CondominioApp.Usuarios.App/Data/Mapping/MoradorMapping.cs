using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Usuarios.App.Data.Mapping
{
    public class MoradorMapping : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Moradores");
           
            builder.Property(u => u.UsuarioId).IsRequired();

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.Proprietario).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Principal).IsRequired().HasDefaultValueSql("0");

        }
    }
}