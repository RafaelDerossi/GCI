using CondominioApp.Principal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.Principal.Domain.ValueObjects;
using CondominioApp.Principal.Domain.FlatModel;

namespace CondominioApp.Principal.Infra.DataQuery.Mapping
{
   public class UnidadeFlatMapping : IEntityTypeConfiguration<UnidadeFlat>
    {
        public void Configure(EntityTypeBuilder<UnidadeFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("UnidadesFlat");

            builder.Property(u => u.Codigo)
                .IsRequired()
                .HasColumnType($"varchar({Unidade.Max})");                

            builder
                .HasIndex(x => x.Codigo)
                .IsUnique();

            builder.Property(u => u.Numero).IsRequired().HasColumnType($"varchar({Unidade.Max})");

            builder.Property(u => u.Andar).IsRequired().HasColumnType($"varchar({Unidade.Max})");

            builder.Property(u => u.Vagas).IsRequired();

            builder.Property(u => u.Andar).HasColumnType($"varchar({Telefone.NumeroMaximo})");           

            builder.Property(u => u.Ramal).HasColumnType($"varchar({Unidade.Max})");

            builder.Property(u => u.Complemento).HasColumnType($"varchar({Unidade.Max})");


            builder.Property(u => u.GrupoId).IsRequired();

            builder.Property(u => u.GrupoDescricao).IsRequired().HasColumnType($"varchar({Grupo.Max})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.CondominioCnpj).HasColumnType($"varchar({Cnpj.Maxlength})");

            builder.Property(u => u.CondominioNome).IsRequired().HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.CondominioLogoMarca).HasColumnType($"varchar({Foto.NomeFotoMaximo})");
        }
    }
}
