using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class ReservaFlatMapping : IEntityTypeConfiguration<ReservaFlat>
    {
        public void Configure(EntityTypeBuilder<ReservaFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("ReservasFlat");

            builder.Property(u => u.AreaComumId).IsRequired();

            builder.Property(u => u.NomeAreaComum).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");           

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.NomeCondominio).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.Observacao).HasColumnType($"varchar(240)");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.NumeroUnidade).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");           

            builder.Property(u => u.AndarUnidade).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.DescricaoGrupoUnidade).IsRequired();

            builder.Property(u => u.UsuarioId).IsRequired();

            builder.Property(u => u.NomeUsuario).IsRequired();

            builder.Property(u => u.HoraInicio).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.HoraFim).IsRequired().HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.Ativa).IsRequired();

            builder.Property(u => u.Preco).IsRequired().HasColumnType($"decimal(14,2)"); 

            builder.Property(u => u.EstaNaFila).IsRequired();           

            builder.Property(u => u.Justificativa).HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.Origem).HasColumnType($"varchar({ReservaFlat.Max})");

            builder.Property(u => u.ReservadoPelaAdministracao).IsRequired();
        }
    }
}
