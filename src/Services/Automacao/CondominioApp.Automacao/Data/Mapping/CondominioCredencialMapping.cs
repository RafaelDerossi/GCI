using CondominioApp.Automacao.App.ValueObjects;
using CondominioApp.Automacao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Automacao.App.Data.Mapping
{
    public class CondominioCredencialMapping : IEntityTypeConfiguration<CondominioCredencial>
    {
        public void Configure(EntityTypeBuilder<CondominioCredencial> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("CondominiosCredenciais");

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(u => u.Endereco).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            });

            builder.Property(u => u.Senha).IsRequired().HasColumnType($"varchar({CondominioCredencial.Max})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.TipoApiAutomacao).IsRequired();
        }
    }
}