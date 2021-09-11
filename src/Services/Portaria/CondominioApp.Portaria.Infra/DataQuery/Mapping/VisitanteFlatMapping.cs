using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Principal.Infra.DataQuery.Mapping
{
   public class VisitanteFlatMapping : IEntityTypeConfiguration<VisitanteFlat>
    {
        public void Configure(EntityTypeBuilder<VisitanteFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("VisitantesFlat");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.TipoDeDocumento).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.Documento)
                    .HasMaxLength(20)
                    .HasColumnName("Documento")
                    .HasColumnType($"varchar(20)");            

            builder.Property(u => u.Email)
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.NomeCondominio).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.NumeroUnidade).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.AndarUnidade).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.GrupoUnidade).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.VisitantePermanente).IsRequired();                     

            builder.Property(u => u.TipoDeVisitante).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.NomeEmpresa).HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.TemVeiculo).IsRequired();
        }
    }
}
