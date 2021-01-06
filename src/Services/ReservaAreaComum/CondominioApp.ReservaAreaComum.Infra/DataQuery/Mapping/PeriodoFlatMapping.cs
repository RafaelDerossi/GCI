using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Principal.Infra.DataQuery.Mapping
{
   public class PeriodoFlatMapping : IEntityTypeConfiguration<PeriodoFlat>
    {
        public void Configure(EntityTypeBuilder<PeriodoFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("PeriodosFlat");

            builder.Property(u => u.HoraInicio).IsRequired().HasColumnType($"varchar({AreaComumFlat.Max})");

            builder.Property(u => u.HoraFim).IsRequired().HasColumnType($"varchar({AreaComumFlat.Max})");

            builder.Property(u => u.AreaComumFlatId).IsRequired();

            builder.Property(u => u.Valor).IsRequired().HasColumnType($"decimal(14,2)"); 

            builder.Property(u => u.Ativo).IsRequired();

        }
    }
}
