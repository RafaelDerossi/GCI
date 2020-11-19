using CondominioAppPreCadastro.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppPreCadastro.App.Data.Mapping
{
    public class ArquivoMapping : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.ToTable("Arquivo");

            builder.HasKey(a => a.Id);

            builder.Property(i => i.NomeOriginalDoArquivo).IsRequired().HasColumnType($"varchar({Arquivo.Max})");

            builder.Property(i => i.Nome).IsRequired().HasColumnType($"varchar({Arquivo.Max})");
        }
    }
}