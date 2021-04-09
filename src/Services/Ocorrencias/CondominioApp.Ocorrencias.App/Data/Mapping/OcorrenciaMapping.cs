using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Ocorrencias.App.Data.Mapping
{
    public class OcorrenciaMapping : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Ocorrencias");           

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Ocorrencia.Max})");

            builder.OwnsOne(u => u.Foto, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .IsRequired()
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeDoArquivo")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .IsRequired()
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginal")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

            builder.Property(u => u.Publica).IsRequired();

            builder.Property(u => u.Status).IsRequired();                        

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.MoradorId).IsRequired();

            builder.Property(u => u.NomeMorador).IsRequired().HasColumnType($"varchar({Ocorrencia.Max})");

            builder.Property(u => u.Panico).IsRequired();
            
        }
    }
}