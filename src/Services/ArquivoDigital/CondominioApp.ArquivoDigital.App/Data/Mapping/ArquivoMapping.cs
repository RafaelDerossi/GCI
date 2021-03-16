using CondominioApp.ArquivoDigital.App.Models;
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

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({Arquivo.Max})");

            builder.Property(u => u.NomeOriginal).IsRequired().HasColumnType($"varchar({Arquivo.Max})");

            builder.Property(u => u.Extensao).IsRequired().HasColumnType($"varchar({Arquivo.Max})");

            builder.Property(u => u.Tamanho).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.PastaId).IsRequired();

            builder.Property(u => u.Publico).IsRequired();

        }
    }
}