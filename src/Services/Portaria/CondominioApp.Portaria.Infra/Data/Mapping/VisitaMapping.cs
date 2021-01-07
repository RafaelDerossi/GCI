using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class VisitaMapping : IEntityTypeConfiguration<Visita>
    {
        public void Configure(EntityTypeBuilder<Visita> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Visitas");

            builder.Property(u => u.Terminada).IsRequired();

            builder.Property(u => u.NomeCondomino).IsRequired().HasColumnType($"varchar({Visita.Max})");

            builder.Property(u => u.Observacao).IsRequired().HasColumnType($"varchar(250)");

            builder.Property(u => u.Status).IsRequired();

            builder.Property(u => u.VisitanteId).IsRequired();

            builder.Property(u => u.NomeVisitante).IsRequired().HasColumnType($"varchar({Visita.Max})");

            builder.Property(u => u.TipoDeDocumentoVisitante).HasColumnType($"varchar({Visita.Max})");

            builder.OwnsOne(u => u.RgVisitante, rg =>
            {
                rg.Property(u => u.Numero)                    
                    .HasMaxLength(Rg.Maxlength)
                    .HasColumnName("Rg")
                    .HasColumnType($"varchar({Rg.Maxlength})");
            });

            builder.OwnsOne(u => u.CpfVisitante, cpf =>
            {
                cpf.Property(u => u.Numero)                    
                    .HasMaxLength(Cpf.Maxlength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.Maxlength})");
            });

            builder.OwnsOne(u => u.EmailVisitante, email =>
            {
                email.Property(u => u.Endereco).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            });

            builder.OwnsOne(u => u.FotoVisitante, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeDoArquivo")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginal")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

            builder.Property(u => u.NomeEmpresaVisitante).HasColumnType($"varchar({Visita.Max})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.NomeCondominio).IsRequired().HasColumnType($"varchar({Visita.Max})");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.NumeroUnidade).IsRequired().HasColumnType($"varchar({Visita.Max})");

            builder.Property(u => u.AndarUnidade).IsRequired().HasColumnType($"varchar({Visita.Max})");

            builder.Property(u => u.DescricaoGrupoUnidade).IsRequired().HasColumnType($"varchar({Visita.Max})");

                     

            builder.OwnsOne(u => u.Veiculo, ft =>
            {
                ft.Property(u => u.Placa)
                    .HasMaxLength(Veiculo.PlacaMaxlength)
                    .HasColumnName("Placa")
                    .HasColumnType($"varchar({Veiculo.PlacaMaxlength})");

                ft.Property(u => u.Modelo)
                    .HasMaxLength(Veiculo.ModeloMaxlength)
                    .HasColumnName("Modelo")
                    .HasColumnType($"varchar({Veiculo.ModeloMaxlength})");

                ft.Property(u => u.Cor)
                    .HasMaxLength(Veiculo.CorMaxlength)
                    .HasColumnName("Cor")
                    .HasColumnType($"varchar({Veiculo.CorMaxlength})");
            });

        }
    }
}
