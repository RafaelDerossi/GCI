using CondominioApp.Enquetes.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Enquetes.App.Data.Mapping
{
    public class EnqueteMapping : IEntityTypeConfiguration<Enquete>
    {
        public void Configure(EntityTypeBuilder<Enquete> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Enquetes");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Enquete.Max})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.CondominioNome).HasColumnType($"varchar({Enquete.Max})");

            builder.Property(u => u.ApenasProprietarios).IsRequired();

            builder.Property(u => u.UsuarioId).IsRequired();

            builder.Property(u => u.UsuarioNome).HasColumnType($"varchar({Enquete.Max})");
           
        }
    }
}