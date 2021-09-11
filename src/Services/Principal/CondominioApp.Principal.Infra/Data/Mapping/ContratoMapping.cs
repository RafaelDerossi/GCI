using CondominioApp.Principal.Domain.ValueObjects;
using CondominioApp.Principal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class ContratoMapping : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Contratos");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.Tipo).IsRequired();

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Grupo.Max})");

            builder.OwnsOne(u => u.ArquivoContrato, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .IsRequired()
                    .HasMaxLength(NomeArquivo.NomeArquivoMaximo)
                    .HasColumnName("NomeDoArquivo")
                    .HasColumnType($"varchar({NomeArquivo.NomeArquivoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .IsRequired()
                    .HasMaxLength(NomeArquivo.NomeArquivoMaximo)
                    .HasColumnName("NomeOriginal")
                    .HasColumnType($"varchar({NomeArquivo.NomeArquivoMaximo})");

                ft.Property(u => u.ExtensaoDoArquivo)
                    .IsRequired()
                    .HasMaxLength(NomeArquivo.NomeArquivoMaximo)
                    .HasColumnName("ExtensaoDoArquivo")
                    .HasColumnType($"varchar({NomeArquivo.NomeArquivoMaximo})");
            });
        }
    }
}
