using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class HistoricoReservaFlatMapping : IEntityTypeConfiguration<HistoricoReservaFlat>
    {
        public void Configure(EntityTypeBuilder<HistoricoReservaFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("HistoricoReservaFlat");

            builder.Property(u => u.ReservaId).IsRequired();

            builder.Property(u => u.Acao).IsRequired();

            builder.Property(u => u.NomeAutorAcao).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.TipoDoAutor).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.Origem).HasColumnType($"varchar({ReservaFlat.Max})");

        }
    }
}
