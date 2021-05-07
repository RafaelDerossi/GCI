using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.ArquivoDigital.App.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.ArquivoDigital.App.Data.Mapping
{
    public class ArquivoMapping : IEntityTypeConfiguration<Arquivo>
    {
        public const int Max = 200;

        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Arquivos");

            builder.OwnsOne(u => u.Nome, ft =>
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
            

            builder.Property(u => u.Tamanho).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.PastaId).IsRequired();

            builder.Property(u => u.Publico).IsRequired();

            builder.Property(u => u.FuncionarioId).IsRequired();

            builder.Property(u => u.NomeFuncionario).IsRequired().HasColumnType($"varchar({Arquivo.Max})");

            builder.Property(u => u.Titulo).HasColumnType($"varchar(50)");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({Arquivo.Max})");

        }
    }
}