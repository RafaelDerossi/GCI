using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Correspondencias.App.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Correspondencias.App.Data.Mapping
{
    public class CorrespondenciaMapping : IEntityTypeConfiguration<Correspondencia>
    {
        public void Configure(EntityTypeBuilder<Correspondencia> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Correspondencias");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.NumeroUnidade).IsRequired().HasColumnType($"varchar({Correspondencia.Max})");
           
            builder.Property(u => u.Bloco).IsRequired().HasColumnType($"varchar({Correspondencia.Max})");

            builder.Property(u => u.Visto).IsRequired();

            builder.Property(u => u.NomeRetirante).HasColumnType($"varchar({Correspondencia.Max})");

            builder.Property(u => u.Observacao).HasColumnType($"varchar({Correspondencia.Max})");

            builder.Property(u => u.FuncionarioId).IsRequired();

            builder.Property(u => u.NomeFuncionario).HasColumnType($"varchar({Correspondencia.Max})");

            builder.OwnsOne(u => u.FotoCorrespondencia, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeDoArquivoFoto")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginalFoto")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

            builder.Property(u => u.NumeroRastreamentoCorreio).HasColumnType($"varchar({Correspondencia.Max})");

            builder.Property(u => u.QuantidadeDeAlertasFeitos).IsRequired();

            builder.Property(u => u.TipoDeCorrespondencia).HasColumnType($"varchar({Correspondencia.Max})");

            builder.OwnsOne(u => u.FotoRetirante, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeArquivoFotoRetirante")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginalFotoRetirante")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

            builder.Property(u => u.ObservacaoDaRetirada).HasColumnType($"varchar({Correspondencia.Max})");

        }
    }
}