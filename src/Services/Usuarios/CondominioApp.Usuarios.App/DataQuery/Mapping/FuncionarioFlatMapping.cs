using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Usuarios.App.DataQuery.Mapping
{
    public class FuncionarioFlatMapping : IEntityTypeConfiguration<FuncionarioFlat>
    {
        public void Configure(EntityTypeBuilder<FuncionarioFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("FuncionariosFlat");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({MoradorFlat.Max})");

            builder.Property(u => u.Sobrenome).HasColumnType($"varchar({MoradorFlat.Max})");

            builder.Property(u => u.Rg).HasColumnType($"varchar({MoradorFlat.Max})");          

            builder.Property(u => u.Ativo).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.SindicoProfissional).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Email).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            
            builder.Property(u => u.Cpf)                   
                    .HasMaxLength(Cpf.Maxlength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.Maxlength})");


            builder.Property(u => u.Telefone)                    
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
           

            builder.Property(u => u.Cel)                    
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("Celular")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
           

            builder.Property(u => u.Foto)                   
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("Foto")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");


            builder.Property(u => u.Atribuicao).HasColumnType($"varchar({MoradorFlat.Max})");

            builder.Property(u => u.Funcao).HasColumnType($"varchar({MoradorFlat.Max})");

            builder.Property(e => e.Logradouro).HasColumnName("Logradouro").HasMaxLength(Endereco.LogradouroMaximo);
            builder.Property(e => e.Complemento).HasColumnName("Complemento").HasMaxLength(Endereco.ComplementoMaximo);
            builder.Property(e => e.Numero).HasColumnName("Numero").HasMaxLength(Endereco.NumeroMaximo);
            builder.Property(e => e.Cep).HasColumnName("Cep").HasMaxLength(Endereco.CepNumero);
            builder.Property(e => e.Bairro).HasColumnName("Bairro").HasMaxLength(Endereco.BairroMaximo);
            builder.Property(e => e.Cidade).HasColumnName("Cidade").HasMaxLength(Endereco.CidadeMaximo);
            builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(Endereco.EstadoMaximo);

            builder.Property(u => u.UsuarioId).IsRequired();          

            builder.Property(u => u.CondominioId).IsRequired();         


        }
    }
}