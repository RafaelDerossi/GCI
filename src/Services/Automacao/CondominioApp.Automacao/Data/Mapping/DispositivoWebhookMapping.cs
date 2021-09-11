using CondominioApp.Automacao.App.ValueObjects;
using CondominioApp.Automacao.Models;
using CondominioApp.Principal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Automacao.App.Data.Mapping
{
    public class DispositivoWebhookMapping : IEntityTypeConfiguration<DispositivoWebhook>
    {
        public void Configure(EntityTypeBuilder<DispositivoWebhook> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("DispositivoWebhook");            

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({CondominioCredencial.Max})");

            builder.Property(u => u.CondominioId).IsRequired();

            builder.OwnsOne(u => u.UrlLigar, tel =>
            {
                tel.Property(u => u.Endereco)
                    .HasMaxLength(Url.TamanhoMaximo)
                    .HasColumnName("UrlLigar")
                    .HasColumnType($"varchar({Url.TamanhoMaximo})");
            });

            builder.OwnsOne(u => u.UrlDesligar, tel =>
            {
                tel.Property(u => u.Endereco)
                    .HasMaxLength(Url.TamanhoMaximo)
                    .HasColumnName("UrlDesligar")
                    .HasColumnType($"varchar({Url.TamanhoMaximo})");
            });
            
        }
    }
}