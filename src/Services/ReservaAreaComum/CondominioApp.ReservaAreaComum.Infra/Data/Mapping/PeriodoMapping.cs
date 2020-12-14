using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.ReservaAreaComum.Domain;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class PeriodoMapping : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Periodos");

            builder.Property(u => u.HoraInicio).IsRequired().HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.HoraFim).IsRequired().HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.AreaComumId).IsRequired();

            builder.Property(u => u.Valor).IsRequired().HasColumnType($"varchar({AreaComum.Max})"); 

            builder.Property(u => u.Ativo).IsRequired();

        }
    }
}
