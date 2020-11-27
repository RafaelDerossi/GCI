using CondominioApp.Enquetes.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Enquetes.App.Data.Mapping
{
    public class RespostaEnqueteMapping : IEntityTypeConfiguration<RespostaEnquete>
    {
        public void Configure(EntityTypeBuilder<RespostaEnquete> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("RespostasEnquete");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.Unidade).IsRequired().HasColumnType($"varchar({Enquete.Max})");

            builder.Property(u => u.Bloco).IsRequired().HasColumnType($"varchar({Enquete.Max})");

            builder.Property(u => u.UsuarioId).IsRequired();

            builder.Property(u => u.UsuarioNome).IsRequired().HasColumnType($"varchar({Enquete.Max})");

            builder.Property(u => u.TipoDeUsuario).IsRequired().HasColumnType($"varchar({Enquete.Max})");

            builder.Property(u => u.AlternativaId).IsRequired();
        }
    }
}