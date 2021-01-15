using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Aplication.Query
{
    public class PortariaQuery : IPortariaQuery
    {        
        private IVisitanteQueryRepository _visitanteQueryRepository;

        public PortariaQuery(IVisitanteQueryRepository visitanteQueryRepository)
        {
            _visitanteQueryRepository = visitanteQueryRepository;
        }


        public async Task<VisitanteFlat> ObterPorId(Guid id)
        {
            return await _visitanteQueryRepository.ObterPorId(id);
        }       

        public async Task<VisitaFlat> ObterVisitaPorId(Guid id)
        {
            return await _visitanteQueryRepository.ObterVisitaPorId(id);
        }               

       


        public void Dispose()
        {           
            _visitanteQueryRepository?.Dispose();
        }

       
    }
}