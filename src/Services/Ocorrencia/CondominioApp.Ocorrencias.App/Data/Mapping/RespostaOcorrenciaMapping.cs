using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Ocorrencias.App.Data.Mapping
{
    public class RespostaOcorrenciaMapping : IEntityTypeConfiguration<RespostaOcorrencia>
    {
        public void Configure(EntityTypeBuilder<RespostaOcorrencia> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("RespostasOcorrencias");           

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Ocorrencia.Max})");
            
            builder.Property(u => u.TipoAutor).IsRequired();

            builder.Property(u => u.MoradorIdFuncionarioId).IsRequired();

            builder.Property(u => u.NomeUsuario).HasColumnType($"varchar({Ocorrencia.Max})");

            builder.Property(u => u.Visto).IsRequired();

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


        }
    }
}