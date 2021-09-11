using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;

namespace CondominioApp.ReservaAreaComum.Infra.Data.Mapping
{
   public class FotoDaAreaComumMapping : IEntityTypeConfiguration<FotoDaAreaComum>
    {
        public void Configure(EntityTypeBuilder<FotoDaAreaComum> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("FotoDaAreaComum");

            builder.Property(u => u.AreaComumId).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();

            builder.OwnsOne(u => u.Foto, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .IsRequired()
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeDoArquivo")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginal")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

        }
    }
}
