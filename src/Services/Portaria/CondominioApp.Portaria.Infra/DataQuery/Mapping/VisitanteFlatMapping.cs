using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.ValueObjects;
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

            builder.Property(u => u.TipoDeDocumento).IsRequired();

            builder.Property(u => u.Rg)
                    .HasMaxLength(Rg.Maxlength)
                    .HasColumnName("Rg")
                    .HasColumnType($"varchar({Rg.Maxlength})");

            builder.Property(u => u.Cpf)
                    .HasMaxLength(Cpf.Maxlength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.Maxlength})");

            builder.Property(u => u.Email).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");

            builder.Property(u => u.Foto)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("Foto")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.NomeCondominio).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.NumeroUnidade).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.AndarUnidade).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.GrupoUnidade).IsRequired().HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.VisitantePermanente).IsRequired();

            builder.Property(u => u.QrCode).HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.TipoDeVisitante).IsRequired();

            builder.Property(u => u.NomeEmpresa).HasColumnType($"varchar({VisitanteFlat.Max})");

            builder.Property(u => u.TemVeiculo).IsRequired();

            builder.Property(u => u.PlacaVeiculo)
                   .HasMaxLength(Veiculo.PlacaMaxlength)
                   .HasColumnName("Placa")
                   .HasColumnType($"varchar({Veiculo.PlacaMaxlength})");          

            builder.Property(u => u.ModeloVeiculo)
                    .HasMaxLength(Veiculo.ModeloMaxlength)
                    .HasColumnName("Modelo")
                    .HasColumnType($"varchar({Veiculo.ModeloMaxlength})");

            builder.Property(u => u.CorVeiculo)
                    .HasMaxLength(Veiculo.CorMaxlength)
                    .HasColumnName("Cor")
                    .HasColumnType($"varchar({Veiculo.CorMaxlength})");

        }
    }
}
