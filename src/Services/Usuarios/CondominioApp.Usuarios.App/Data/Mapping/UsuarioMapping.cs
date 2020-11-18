using CondominioApp.Core.ValueObjects;
using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Usuarios.App.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Usuarios");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Sobrenome).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Rg).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Atribuicao).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Funcao).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Ativo).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.SindicoProfissional).IsRequired().HasDefaultValueSql("0");

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(u => u.Endereco).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            });

            builder.OwnsOne(u => u.Cpf, cpf =>
            {
                cpf.Property(u => u.Numero)
                    .IsRequired()
                    .HasMaxLength(Cpf.Maxlength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.Maxlength})");
            });

            builder.OwnsOne(u => u.Telefone, tel =>
            {
                tel.Property(u => u.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
            });

            builder.OwnsOne(u => u.Cel, tel =>
            {
                tel.Property(u => u.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("Celular")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
            });

            builder.OwnsOne(u => u.Foto, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)
                    .IsRequired()
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeDoArquivo")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)
                    .IsRequired()
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginal")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

            builder.OwnsOne(x => x.Endereco, endereco =>
            {
                endereco.Property(e => e.logradouro).HasColumnName("Logradouro").HasMaxLength(Endereco.LogradouroMaximo);
                endereco.Property(e => e.complemento).HasColumnName("Complemento").HasMaxLength(Endereco.ComplementoMaximo);
                endereco.Property(e => e.numero).HasColumnName("Numero").HasMaxLength(Endereco.NumeroMaximo);
                endereco.Property(e => e.cep).HasColumnName("Cep").HasMaxLength(Endereco.CepNumero);                
                endereco.Property(e => e.bairro).HasColumnName("Bairro").HasMaxLength(Endereco.BairroMaximo);
                endereco.Property(e => e.cidade).HasColumnName("Cidade").HasMaxLength(Endereco.CidadeMaximo);
                endereco.Property(e => e.estado).HasColumnName("Estado").HasMaxLength(Endereco.EstadoMaximo);
            });
        }
    }
}