using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.App.Aplication.Query
{
    public class ReservaAreaComumQuery : IReservaAreaComumQuery
    {
        private IReservaAreaComumRepository _areaComumRepository;

        public ReservaAreaComumQuery(IReservaAreaComumRepository comunicadoRepository)
        {
            _areaComumRepository = comunicadoRepository;
        }


        public async Task<AreaComum> ObterPorId(Guid id)
        {
            return await _areaComumRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<AreaComum>> ObterPorCondominio
           (Guid condominioId)
        {
            return await _areaComumRepository.Obter(
                              c => c.CondominioId == condominioId &&
                              !c.Lixeira);           
        }

        public async Task<IEnumerable<AreaComum>> ObterPorCondominioEAtiva
            (Guid condominioId, bool ativa)
        {           
            if (ativa)
            {
                return await _areaComumRepository.Obter(
                                c => c.CondominioId == condominioId &&
                                c.Ativa && !c.Lixeira);
            }
            else
            {
                return await _areaComumRepository.Obter(
                                c => c.CondominioId == condominioId &&
                                !c.Ativa && !c.Lixeira);
            }            
        }
       

        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }
    }
}