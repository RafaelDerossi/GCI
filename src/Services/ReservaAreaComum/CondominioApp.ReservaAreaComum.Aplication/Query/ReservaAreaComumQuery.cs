using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.App.Aplication.Query
{
    public class ReservaAreaComumQuery : IReservaAreaComumQuery
    {        
        private IReservaAreaComumQueryRepository _reservaAreaComumQueryRepository;

        public ReservaAreaComumQuery(IReservaAreaComumQueryRepository reservaAreaComumQueryRepository)
        {
            _reservaAreaComumQueryRepository = reservaAreaComumQueryRepository;
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
            return await _reservaAreaComumQueryRepository.ObterReserva(r=>r.CondominioId == condominioId && !r.Lixeira);
        }

        public async Task<IEnumerable<ReservaFlat>> ObterReservasPorUnidade(Guid unidadeId)
        {
            return await _reservaAreaComumQueryRepository.ObterReserva(r => r.UnidadeId == unidadeId && !r.Lixeira);
        }

        public async Task<IEnumerable<ReservaFlat>> ObterReservasPorUsuario(Guid usuarioId)
        {
            return await _reservaAreaComumQueryRepository.ObterReserva(r => r.UsuarioId == usuarioId && !r.Lixeira);
        }

        public async Task<IEnumerable<ReservaFlat>> ObterReservasPorAreaComum(Guid areaComumId)
        {
            return await _reservaAreaComumQueryRepository.ObterReserva(r => r.AreaComumId == areaComumId && !r.Lixeira);
        }



        public void Dispose()
        {           
            _reservaAreaComumQueryRepository?.Dispose();
        }

       
    }
}