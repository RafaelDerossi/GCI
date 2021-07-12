using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Correspondencias.App.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Correspondencias.App.Data.Mapping
{
    public class HistoricoCorrespondenciaMapping : IEntityTypeConfiguration<HistoricoCorrespondencia>
    {
        public void Configure(EntityTypeBuilder<HistoricoCorrespondencia> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Historico");

            builder.Property(u => u.CorrespondenciaId).IsRequired();

            builder.Property(u => u.Acao).IsRequired();            

            builder.Property(u => u.FuncionarioId).IsRequired();

            builder.Property(u => u.NomeFuncionario).HasColumnType($"varchar({Correspondencia.Max})");
        }
    }
}