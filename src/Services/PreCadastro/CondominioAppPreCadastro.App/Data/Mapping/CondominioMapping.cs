using CondominioApp.Core.ValueObjects;
using CondominioAppPreCadastro.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioAppPreCadastro.App.Data.Mapping
{
    public class CondominioMapping : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Condominio");

            builder.Property(u => u.NomeDoCondominio).IsRequired().HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.RazaoSocial).IsRequired().HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.NomeDoSindico).IsRequired().HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.OutroTipoDeDocumento).HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.NumeroDoDocumento).HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.Observacao).HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.Transferido).IsRequired().HasDefaultValueSql("0");
            
            builder.OwnsOne(u => u.EmailDoSindico, email =>
            {
                email.Property(u => u.Endereco).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("EmailDoSindico")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            });

            builder.OwnsOne(u => u.TelefoneDoSindico, tel =>
            {
                tel.Property(u => u.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("TelefoneDoSindico")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
            });


            builder.OwnsOne(x => x.Endereco, endereco =>
            {
                endereco.Property(e => e.logradouro).HasColumnName("Logradouro").HasMaxLength(Endereco.LogradouroMaximo);
                endereco.Property(e => e.complemento).HasColumnName("Complemento").HasMaxLength(Endereco.ComplementoMaximo);
                endereco.Property(e => e.numero).HasColumnName("Numero").HasMaxLength(Endereco.NumeroMaximo);
                endereco.Property(e => e.cep).HasColumnName("Cep").HasMaxLength(Endereco.CepNumero);
                endereco.Property(e => e.municipio).HasColumnName("Municipio").HasMaxLength(Endereco.MunicipioMaximo);
                endereco.Property(e => e.bairro).HasColumnName("Bairro").HasMaxLength(Endereco.BairroMaximo);
                endereco.Property(e => e.cidade).HasColumnName("Cidade").HasMaxLength(Endereco.CidadeMaximo);
                endereco.Property(e => e.estado).HasColumnName("Estado").HasMaxLength(Endereco.EstadoMaximo);
            });
        }
    }
}