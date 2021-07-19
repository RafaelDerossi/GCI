using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Principal.Infra.DataQuery.Mapping
{
   public class VisitaFlatMapping : IEntityTypeConfiguration<VisitaFlat>
    {
        public void Configure(EntityTypeBuilder<VisitaFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("VisitasFlat");          

            builder.Property(u => u.Observacao).IsRequired().HasColumnType($"varchar(250)");

            builder.Property(u => u.Status).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})"); ;

            builder.Property(u => u.VisitanteId).IsRequired();

            builder.Property(u => u.NomeVisitante).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})");

            builder.Property(u => u.TipoDeDocumentoVisitante).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})"); ;

            builder.Property(u => u.DocumentoVisitante)
                    .HasMaxLength(20)
                    .HasColumnName("Documento")
                    .HasColumnType($"varchar(20)");           

            builder.Property(u => u.EmailVisitante).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");

            builder.Property(u => u.FotoVisitante)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("Foto")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

            builder.Property(u => u.TipoDeVisitante).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})"); ;

            builder.Property(u => u.NomeEmpresaVisitante).HasColumnType($"varchar({VisitaFlat.Max})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.NomeCondominio).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.NumeroUnidade).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})");

            builder.Property(u => u.AndarUnidade).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})");

            builder.Property(u => u.GrupoUnidade).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})");

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


            builder.Property(u => u.UsuarioId).IsRequired();
            builder.Property(u => u.NomeUsuario).IsRequired().HasColumnType($"varchar({VisitaFlat.Max})");
        }
    }
}
