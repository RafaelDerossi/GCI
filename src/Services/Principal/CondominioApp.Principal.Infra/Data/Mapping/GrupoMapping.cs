using CondominioApp.Principal.Domain.ValueObjects;
using CondominioApp.Principal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class GrupoMapping : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Grupos");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Grupo.Max})");

            builder.Property(u => u.CondominioId).IsRequired();

        }
    }
}
