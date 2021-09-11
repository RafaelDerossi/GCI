using CondominioAppMarketplace.Domain.ValueObjects;
using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppMarketplace.Infra.Mapping
{
    public class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedor");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(Vendedor.NomeMaximo);

            builder.OwnsOne(x => x.Endereco, endereco =>
            {
                endereco.Property(x => x.logradouro).HasColumnName("Logradouro").HasMaxLength(Endereco.LogradouroMaximo);

                endereco.Property(x => x.complemento).HasColumnName("Complemento").HasMaxLength(Endereco.ComplementoMaximo);

                endereco.Property(x => x.numero).HasColumnName("Numero").HasMaxLength(Endereco.NumeroMaximo);

                endereco.Property(x => x.cep).HasColumnName("Cep").HasMaxLength(Endereco.CepNumero);

                endereco.Property(x => x.bairro).HasColumnName("Bairro").HasMaxLength(Endereco.BairroMaximo);

                endereco.Property(x => x.cidade).HasColumnName("Cidade").HasMaxLength(Endereco.CidadeMaximo);

                endereco.Property(x => x.estado).HasColumnName("Estado").HasMaxLength(Endereco.EstadoMaximo);

            });

            builder.OwnsOne(x => x.Cpf, cpf =>
            {
                cpf.Property(x => x.Numero).HasColumnName("Cpf").HasMaxLength(Cpf.Maxlength);
            });

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Endereco).HasColumnName("Email").HasMaxLength(Email.EmailMaximo);
            });

            builder.OwnsOne(x => x.Telefone, celular =>
            {
                celular.Property(x => x.Numero).HasColumnName("Celular").HasMaxLength(Telefone.NumeroMaximo);
            });
        }
    }
}
