using CondominioApp.Principal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.Principal.Domain.FlatModel;

namespace CondominioApp.Principal.Infra.DataQuery.Mapping
{
    public class CondominioFlatMapping : IEntityTypeConfiguration<CondominioFlat>
    {
        public void Configure(EntityTypeBuilder<CondominioFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("CondominiosFlat");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({CondominioFlat.Max})");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({CondominioFlat.Max})");

            builder.Property(u => u.Cnpj).HasColumnType($"varchar({Cnpj.Maxlength})");

            builder.Property(u => u.Telefone).HasColumnType($"varchar({Telefone.NumeroMaximo})");

            builder.Property(u => u.NomeArquivoLogo).HasColumnType($"varchar({Foto.NomeFotoMaximo})");           

            builder.Property(u => u.LinkGeraBoleto).HasColumnType($"varchar({CondominioFlat.Max})");

            builder.Property(u => u.BoletoFolder).HasColumnType($"varchar({CondominioFlat.Max})");

            builder.Property(u => u.UrlWebServer).HasColumnType($"varchar({Url.TamanhoMaximo})");           

            builder.Property(u => u.PortariaAtivada).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.PortariaParaMoradorAtivada).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ClassificadoAtivado).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ClassificadoParaMoradorAtivado).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.MuralAtivado).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.MuralParaMoradorAtivado).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ChatAtivado).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ChatParaMoradorAtivado).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ReservaAtivada).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.ReservaNaPortariaAtivada).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.OcorrenciaAtivada).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.OcorrenciaParaMoradorAtivada).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.CorrespondenciaAtivada).IsRequired().HasDefaultValueSql("0");

            builder.Property(u => u.CorrespondenciaNaPortariaAtivada).IsRequired().HasDefaultValueSql("0");            

            builder.Property(e => e.Logradouro).HasColumnName("Logradouro").HasMaxLength(Endereco.LogradouroMaximo);

            builder.Property(e => e.Complemento).HasColumnName("Complemento").HasMaxLength(Endereco.ComplementoMaximo);

            builder.Property(e => e.Numero).HasColumnName("Numero").HasMaxLength(Endereco.NumeroMaximo);

            builder.Property(e => e.Cep).HasColumnName("Cep").HasMaxLength(Endereco.CepNumero);

            builder.Property(e => e.Bairro).HasColumnName("Bairro").HasMaxLength(Endereco.BairroMaximo);

            builder.Property(e => e.Cidade).HasColumnName("Cidade").HasMaxLength(Endereco.CidadeMaximo);

            builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(Endereco.EstadoMaximo);

            builder.Property(u => u.NomeDoSindico).HasColumnType($"varchar({CondominioFlat.Max})");

            builder.Property(u => u.NomeArquivoLogo).HasColumnType($"varchar({Foto.NomeFotoMaximo})");

            builder.Property(u => u.NomeOriginalArquivoLogo).HasColumnType($"varchar({Foto.NomeFotoMaximo})");

            builder.Property(u => u.NomeArquivoContrato).HasColumnType($"varchar({NomeArquivo.NomeArquivoMaximo})");

            builder.Property(u => u.NomeOriginalArquivoContrato).HasColumnType($"varchar({NomeArquivo.NomeArquivoMaximo})");
        }
    }
}
