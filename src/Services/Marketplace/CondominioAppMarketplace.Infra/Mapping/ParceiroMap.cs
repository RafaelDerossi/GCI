using CondominioApp.Core.ValueObjects;
using CondominioAppMarketplace.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppMarketplace.Infra.Mapping
{
    public class ParceiroMap : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> builder)
        {
            builder.ToTable("Parceiro");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.NomeCompleto).HasMaxLength(Parceiro.NomeCompletoMaximo);

            builder.Property(x => x.NomeDoResponsavel).HasMaxLength(Parceiro.NomeDoResponsavelMaximo);
          
            builder.Property(x => x.Descricao).HasMaxLength(Parceiro.DescricaoMaximo);

            builder.Property(x => x.Cor).HasMaxLength(Parceiro.CorMaximo);

            builder.OwnsOne(x => x.Email, email =>  email.Property(x => x.Endereco).HasColumnName("Email").HasMaxLength(Email.EmailMaximo));

            builder.OwnsOne(x => x.TelefoneCelular, telefoneCelular =>
            {
                telefoneCelular.Property(x => x.Numero).HasColumnName("Celular").HasMaxLength(Telefone.NumeroMaximo);
            });

            builder.OwnsOne(x => x.TelefoneFixo, telefoneFixo => 
            {
                telefoneFixo.Property(x => x.Numero).HasColumnName("NumeroFixo").HasMaxLength(Telefone.NumeroMaximo);
            });

            builder.OwnsOne(x => x.Cnpj, numero =>
            {
                numero.Property(x => x.numero).HasColumnName("Cnpj").HasMaxLength(Cnpj.Maxlength);
            });

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

            builder.OwnsOne(x => x.Contrato, contrato =>
            {
                contrato.Property(x => x.Descricao).HasColumnName("DescricaoDoContrato").HasMaxLength(Contrato.DescricaoMaximo);

                contrato.Property(x => x.DataDeInicio).HasColumnName("DataDeInicioDoContrato").HasColumnType("DateTime");

                contrato.Property(x => x.DataDeRenovacao).HasColumnName("DataDeRenovacaoDoContrato").HasColumnType("DateTime");
            });
        }
    }
}
