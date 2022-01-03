using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GCI.Acoes.Domain;
using GCI.Core.ValueObjects;

namespace GCI.Acoes.Infra.Data.Mapping
{
   public class OperacaoMapping : IEntityTypeConfiguration<Operacao>
    {
        public void Configure(EntityTypeBuilder<Operacao> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Operacoes");

            builder.Property(u => u.CodigoDaAcao).IsRequired().HasColumnType($"varchar(50)");

            builder.Property(u => u.Preco).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Quantidade).IsRequired();

            builder.Property(u => u.DataDaOperacao).IsRequired();

            builder.Property(u => u.CustoDaOperacao).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.ValorTotal).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Tipo).IsRequired();
        }
    }
}
