using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class CondominioMapping : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Condominios");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({Condominio.Max})");          

            builder.OwnsOne(u => u.Cnpj, cnpj =>
            {
                cnpj.Property(u => u.numero)
                    .IsRequired()
                    .HasMaxLength(Cnpj.Maxlength)
                    .HasColumnName("Cnpj")
                    .HasColumnType($"varchar({Cnpj.Maxlength})");
            });

            builder.OwnsOne(u => u.Telefone, tel =>
            {
                tel.Property(u => u.Numero)                    
                    .HasMaxLength(Telefone.NumeroMaximo)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.NumeroMaximo})");
            });           

            builder.OwnsOne(u => u.LogoMarca, ft =>
            {
                ft.Property(u => u.NomeDoArquivo)                    
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeDoArquivo")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");

                ft.Property(u => u.NomeOriginal)                   
                    .HasMaxLength(Foto.NomeFotoMaximo)
                    .HasColumnName("NomeOriginal")
                    .HasColumnType($"varchar({Foto.NomeFotoMaximo})");
            });

            builder.Property(u => u.LinkGeraBoleto).HasColumnType($"varchar({Condominio.Max})");

            builder.Property(u => u.BoletoFolder).HasColumnType($"varchar({Condominio.Max})");

            builder.OwnsOne(u => u.UrlWebServer, tel =>
            {
                tel.Property(u => u.Endereco)                    
                    .HasMaxLength(Url.TamanhoMaximo)
                    .HasColumnName("UrlWebServer")
                    .HasColumnType($"varchar({Url.TamanhoMaximo})");
            });

            builder.Property(u => u.Portaria).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.PortariaMorador).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Classificado).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ClassificadoMorador).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Mural).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.MuralMorador).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Chat).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ChatMorador).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Reserva).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ReservaNaPortaria).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Ocorrencia).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.OcorrenciaMorador).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.Correspondencia).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.CorrespondenciaNaPortaria).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.LimiteTempoReserva).IsRequired().HasDefaultValueSql("0");

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
