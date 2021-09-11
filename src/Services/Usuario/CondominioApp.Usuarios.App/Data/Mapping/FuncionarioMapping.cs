using CondominioApp.Usuarios.App.ValueObjects;
using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Usuarios.App.Data.Mapping
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Funcionarios");

            builder.Property(u => u.UsuarioId).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();            

            builder.Property(u => u.Atribuicao).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Funcao).HasColumnType($"varchar({Usuario.Max})");

            builder.Property(u => u.Ativo).IsRequired().HasDefaultValueSql("0");

        }
    }
}