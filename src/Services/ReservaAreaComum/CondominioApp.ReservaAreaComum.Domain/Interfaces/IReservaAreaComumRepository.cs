using CondominioApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Domain.Interfaces
{
    public interface IReservaAreaComumRepository : IRepository<AreaComum>
    {
        Task<Reserva> ObterReservaPorId(Guid id);

        Task<Guid> Obter_AreaComumId_Por_ReservaId(Guid reservaId);

        Task<int> ObterQtdDeReservasProcessando();

        Task<int> ObterQtdDeReservasAguardandoAprovacaoAteHoje();

        Task<int> ObterQtdDeReservasNaFilaAteHoje();

        Task<Reserva> ObterPrimeiraNaFilaParaSerProcessada();

        Task<IEnumerable<Reserva>> ObterReservasAguardandoAprovacaoAteHoje();

        Task<IEnumerable<Reserva>> ObterReservasNaFilaAteHoje();


        void AdicionarPeriodo(Periodo entity);

        void RemoverPeriodo(Periodo entity);

        void AdicionarReserva(Reserva entity);

        void AtualizarReserva(Reserva entity);



        void AdicionarFotoDaAreaComum(FotoDaAreaComum entity);

        void ApagarFotoDaAreaComum(Func<FotoDaAreaComum, bool> predicate);

        void RemoverFotoDaAreaComum(FotoDaAreaComum entity);


        Task<FotoDaAreaComum> ObterFotoDaAreaComumPorId(Guid fotoId);

        Task<IEnumerable<FotoDaAreaComum>> ObterFotosDaAreaComum(Guid areaComumId);

    }
}
