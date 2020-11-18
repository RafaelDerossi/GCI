using CondominioApp.Core.ValueObjects;
using CondominioAppPreCadastro.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppPreCadastro.App.Data.Mapping
{
    public class LeadMapping : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");

            builder.HasKey(a => a.Id);
            
            builder.Property(i => i.Nome).IsRequired().HasColumnName("Nome").HasColumnType($"varchar({Lead.Max})");
            
            builder.Property(i => i.Motivo).HasColumnName("Motivo").HasColumnType($"varchar({Lead.Max})");

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(u => u.Endereco).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            });

            builder.OwnsOne(u => u.Telefone, tel =>
            {
                tel.Property(u => u.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
            });
        }
    }
}