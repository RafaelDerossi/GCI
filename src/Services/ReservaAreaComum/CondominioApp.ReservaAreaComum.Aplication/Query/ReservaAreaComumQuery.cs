using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.App.Aplication.Query
{
    public class ReservaAreaComumQuery : IReservaAreaComumQuery
    {        
        private readonly IReservaAreaComumQueryRepository _reservaAreaComumQueryRepository;
        private readonly IReservaAreaComumRepository _reservaAreaComumRepository;
        private readonly int take = 500;

        public ReservaAreaComumQuery
            (IReservaAreaComumQueryRepository reservaAreaComumQueryRepository,
             IReservaAreaComumRepository reservaAreaComumRepository)
        {
            _reservaAreaComumQueryRepository = reservaAreaComumQueryRepository;
            _reservaAreaComumRepository = reservaAreaComumRepository;
        }

        public async Task<AreaComumFlat> ObterPorId(Guid id)
        {
            return await _reservaAreaComumQueryRepository.ObterPorId(id);
        }       

        public async Task<IEnumerable<AreaComumFlat>> ObterPorCondominio
           (Guid condominioId)
        {
            return await _reservaAreaComumQueryRepository.Obter(
                              c => c.CondominioId == condominioId &&
                              !c.Lixeira);           
        }

        public async Task<IEnumerable<AreaComumFlat>> ObterPorCondominioEAtiva
            (Guid condominioId, bool ativa)
        {           
            if (ativa)
            {
                return await _reservaAreaComumQueryRepository.Obter(
                                c => c.CondominioId == condominioId &&
                                c.Ativa && !c.Lixeira);
            }
            else
            {
                return await _reservaAreaComumQueryRepository.Obter(
                                c => c.CondominioId == condominioId &&
                                !c.Ativa && !c.Lixeira);
            }            
        }




        public async Task<ReservaFlat> ObterReservaPorId(Guid id)
        {
            return await _reservaAreaComumQueryRepository.ObterReservaPorId(id);
        }               

        public async Task<IEnumerable<ReservaFlat>> ObterReservasPorCondominio(Guid condominioId)
        {
            return await _reservaAreaComumQueryRepository.ObterReserva(r=>r.CondominioId == condominioId && !r.Lixeira, true, take);
        }

        public async Task<IEnumerable<ReservaFlat>> ObterReservasPorUnidade(Guid unidadeId)
        {
            return await _reservaAreaComumQueryRepository.ObterReserva(r => r.UnidadeId == unidadeId && !r.Lixeira, true, take);
        }

        public async Task<IEnumerable<ReservaFlat>> ObterReservasPorMorador(Guid moradorId)
        {
            return await _reservaAreaComumQueryRepository.ObterReserva(r => r.MoradorId == moradorId && !r.Lixeira, true, take);
        }

        public async Task<IEnumerable<ReservaFlat>> ObterReservasPorAreaComum(Guid areaComumId)
        {
            return await _reservaAreaComumQueryRepository.ObterReserva(r => r.AreaComumId == areaComumId && !r.Lixeira, true, take);
        }

        public async Task<int> ObterQtdDeReservasProcessando()
        {
            return await _reservaAreaComumQueryRepository.ObterQtdDeReservasProcessando();
        }

        public async Task<ReservaFlat> ObterPrimeiraNaFilaParaSerProcessada()
        {
            return await _reservaAreaComumQueryRepository.ObterPrimeiraNaFilaParaSerProcessada();
        }


        public async Task<IEnumerable<HistoricoReservaFlat>> ObterHistoricoDaReserva(Guid reservaId)
        {
            return await _reservaAreaComumQueryRepository.ObterHistoricoDaReserva(reservaId);
        }



        public async Task<IEnumerable<FotoDaAreaComum>> ObterFotosDaAreaComum(Guid areaComumId)
        {
            return await _reservaAreaComumRepository.ObterFotosDaAreaComum(areaComumId);
        }


        public void Dispose()
        {           
            _reservaAreaComumQueryRepository?.Dispose();
        }

       
    }
}