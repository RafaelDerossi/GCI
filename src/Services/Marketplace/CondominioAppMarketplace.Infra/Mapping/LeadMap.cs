using CondominioAppMarketplace.Domain.ValueObjects;
using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppMarketplace.Infra.Mapping
{
    public class LeadMap : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");
            builder.HasKey(x => x.Id);
         
            builder.Property(x => x.NomeDoCondominio).HasMaxLength(Lead.NomeDoCondominioMaximo);

            builder.Property(x => x.NomeDoCliente).HasMaxLength(Lead.NomeDoClienteMaximo);

            builder.Property(x => x.Unidade).HasMaxLength(Lead.UnidadeMaximo);

            builder.Property(x => x.Bloco).HasMaxLength(Lead.BlocoMaximo);

            builder.Property(x => x.Observacao).HasMaxLength(Lead.ObservacaoMaxmo);

            builder.OwnsOne(x => x.EmailDoCliente, emailDoCliente =>
            {
                emailDoCliente.Property(x => x.Endereco).HasColumnName("EmailDoCliente").HasMaxLength(Email.EmailMaximo);
            });

            builder.OwnsOne(x => x.Telefone, telefone =>
            {
                telefone.Property(x => x.Numero).HasColumnName("Celular").HasMaxLength(Telefone.NumeroMaximo);
            });
        }
    }
}
