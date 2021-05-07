using CondominioApp.Comunicados.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Comunicados.App.Data.Mapping
{
    public class ComunicadoMapping : IEntityTypeConfiguration<Comunicado>
    {
        public void Configure(EntityTypeBuilder<Comunicado> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Comunicados");           

            builder.Property(u => u.Titulo).IsRequired().HasColumnType($"varchar({Comunicado.Max})");
           
            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar(2000)");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.FuncionarioId).IsRequired();

            builder.Property(u => u.NomeFuncionario).HasColumnType($"varchar({Comunicado.Max})");          

            builder.Property(u => u.Visibilidade).IsRequired();

            builder.Property(u => u.Categoria).IsRequired();

            builder.Property(u => u.TemAnexos).IsRequired();

            builder.Property(u => u.CriadoPelaAdministradora).IsRequired();
        }
    }
}