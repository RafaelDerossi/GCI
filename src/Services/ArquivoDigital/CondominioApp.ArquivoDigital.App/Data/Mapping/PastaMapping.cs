using CondominioApp.ArquivoDigital.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.ArquivoDigital.App.Data.Mapping
{
    public class PastaMapping : IEntityTypeConfiguration<Pasta>
    {
        public void Configure(EntityTypeBuilder<Pasta> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Pastas");

            builder.Property(u => u.Titulo).IsRequired().HasColumnType($"varchar(50)");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Pasta.Max})");

            builder.Property(u => u.CondominioId).IsRequired();            

            builder.Property(u => u.Publica).IsRequired();

            builder
               .HasIndex(x => new { x.Titulo, x.CondominioId })
               .IsUnique();

        }
    }
}