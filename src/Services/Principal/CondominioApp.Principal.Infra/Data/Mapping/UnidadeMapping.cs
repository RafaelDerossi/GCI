using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class UnidadeMapping : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Unidades");

            builder.Property(u => u.Codigo)
                .IsRequired()
                .HasColumnType($"varchar({Unidade.Max})");                

            builder
                .HasIndex(x => x.Codigo)
                .IsUnique();

            builder.Property(u => u.Numero).IsRequired().HasColumnType($"varchar({Unidade.Max})");

            builder.Property(u => u.Andar).IsRequired().HasColumnType($"varchar({Unidade.Max})");

            builder.Property(u => u.Vagas).IsRequired();

            builder.OwnsOne(u => u.Telefone, tel =>
            {
                tel.Property(u => u.Numero)                   
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
            });

            builder.Property(u => u.Ramal).HasColumnType($"varchar({Unidade.Max})");

            builder.Property(u => u.Complemento).HasColumnType($"varchar({Unidade.Max})");


            builder.Property(u => u.GrupoId).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();

           
        }
    }
}
