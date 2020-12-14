using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.ReservaAreaComum.Domain;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class AreaComumMapping : IEntityTypeConfiguration<AreaComum>
    {
        public void Configure(EntityTypeBuilder<AreaComum> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("AreasComuns");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.TermoDeUso).HasColumnType($"varchar({500})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.NomeCondominio).IsRequired().HasColumnType($"varchar({AreaComum.Max})");           

            builder.Property(u => u.DiasPermitidos).IsRequired().HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.AntecedenciaMaximaEmMeses).IsRequired();

            builder.Property(u => u.AntecedenciaMaximaEmDias).IsRequired();

            builder.Property(u => u.AntecedenciaMinimaEmDias).IsRequired();

            builder.Property(u => u.AntecedenciaMinimaParaCancelamentoEmDias).IsRequired();

            builder.Property(u => u.RequerAprovacaoDeReserva).IsRequired();

            builder.Property(u => u.TemHorariosEspecificos).IsRequired();

            builder.Property(u => u.TemIntervaloFixoEntreReservas).IsRequired();           

            builder.Property(u => u.TempoDeIntervaloEntreReservas).HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.Ativa).IsRequired();

            builder.Property(u => u.NumeroLimiteDeReservaPorUnidade).IsRequired();

            builder.Property(u => u.PermiteReservaSobreposta).IsRequired();

        }
    }
}
