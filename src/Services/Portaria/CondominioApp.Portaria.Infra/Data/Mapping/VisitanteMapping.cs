using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class VisitanteMapping : IEntityTypeConfiguration<Visitante>
    {
        public void Configure(EntityTypeBuilder<Visitante> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Visitantes");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({Visitante.Max})");

            builder.Property(u => u.TipoDeDocumento).IsRequired();

            builder.Property(u => u.Documento)
                    .HasMaxLength(20)
                    .HasColumnName("Documento")
                    .HasColumnType($"varchar(20)");            
            

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(u => u.Endereco).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            });

            builder.OwnsOne(u => u.Foto, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeDoArquivo")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginal")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

            builder.Property(u => u.CondominioId).IsRequired();           

            builder.Property(u => u.UnidadeId).IsRequired();           

            builder.Property(u => u.VisitantePermanente).IsRequired();

            builder.Property(u => u.QrCode).HasColumnType($"varchar({Visitante.Max})");

            builder.Property(u => u.TipoDeVisitante).IsRequired();

            builder.Property(u => u.NomeEmpresa).HasColumnType($"varchar({Visitante.Max})");
           
        }
    }
}
