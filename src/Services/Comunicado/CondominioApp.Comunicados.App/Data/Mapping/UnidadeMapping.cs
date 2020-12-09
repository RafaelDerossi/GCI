using CondominioApp.Comunicados.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Comunicados.App.Data.Mapping
{
    public class UnidadeMapping : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Unidades");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.Numero).IsRequired().HasColumnType($"varchar({Comunicado.Max})");
           
            builder.Property(u => u.Andar).IsRequired().HasColumnType($"varchar({Comunicado.Max})");

            builder.Property(u => u.GrupoId).IsRequired();

            builder.Property(u => u.DescricaoGrupo).HasColumnType($"varchar({Comunicado.Max})");           
        }
    }
}