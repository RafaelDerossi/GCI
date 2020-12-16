using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.ReservaAreaComum.Domain;

namespace CondominioApp.Principal.Infra.Data.Mapping
{
   public class ReservaMapping : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Reservas");

            builder.Property(u => u.AreaComumId).IsRequired();

            builder.Property(u => u.Observacao).HasColumnType($"varchar(240)");

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.NumeroUnidade).IsRequired().HasColumnType($"varchar({AreaComum.Max})");           

            builder.Property(u => u.AndarUnidade).IsRequired().HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.DescricaoGrupoUnidade).IsRequired();

            builder.Property(u => u.UsuarioId).IsRequired();

            builder.Property(u => u.NomeUsuario).IsRequired();

            builder.Property(u => u.HoraInicio).IsRequired().HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.HoraFim).IsRequired().HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.Ativa).IsRequired();

            builder.Property(u => u.Preco).IsRequired();

            builder.Property(u => u.EstaNaFila).IsRequired();           

            builder.Property(u => u.Justificativa).HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.Origem).HasColumnType($"varchar({AreaComum.Max})");

            builder.Property(u => u.ReservadoPelaAdministracao).IsRequired();
        }
    }
}
