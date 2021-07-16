using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.ReservaAreaComum.Infra.DataQuery.Mapping
{
   public class AreaComumFlatMapping : IEntityTypeConfiguration<AreaComumFlat>
    {
        public void Configure(EntityTypeBuilder<AreaComumFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("AreasComunsFlat");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({AreaComumFlat.Max})");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({AreaComumFlat.Max})");

            builder.Property(u => u.TermoDeUso).HasColumnType($"varchar({500})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.NomeCondominio).IsRequired().HasColumnType($"varchar({AreaComumFlat.Max})");           

            builder.Property(u => u.DiasPermitidos).IsRequired().HasColumnType($"varchar({AreaComumFlat.Max})");

            builder.Property(u => u.AntecedenciaMaximaEmMeses).IsRequired();

            builder.Property(u => u.AntecedenciaMaximaEmDias).IsRequired();

            builder.Property(u => u.AntecedenciaMinimaEmDias).IsRequired();

            builder.Property(u => u.AntecedenciaMinimaParaCancelamentoEmDias).IsRequired();

            builder.Property(u => u.RequerAprovacaoDeReserva).IsRequired();

            builder.Property(u => u.TemHorariosEspecificos).IsRequired();

            builder.Property(u => u.TempoDeIntervaloEntreReservas).HasColumnType($"varchar({AreaComumFlat.Max})");

            builder.Property(u => u.Ativa).IsRequired();

            builder.Property(u => u.NumeroLimiteDeReservaPorUnidade).IsRequired();

            builder.Property(u => u.PermiteReservaSobreposta).IsRequired();

            builder.Property(u => u.NomeOriginalArquivoAnexo).HasColumnType($"varchar({NomeArquivo.NomeArquivoMaximo})");

            builder.Property(u => u.NomeArquivoAnexo).HasColumnType($"varchar({NomeArquivo.NomeArquivoMaximo})");
        }
    }
}
