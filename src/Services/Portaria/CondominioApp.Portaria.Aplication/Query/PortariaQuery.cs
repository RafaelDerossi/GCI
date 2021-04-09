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
        private IPortariaQueryRepository _visitanteQueryRepository;

        public PortariaQuery(IPortariaQueryRepository visitanteQueryRepository)
        {
            _visitanteQueryRepository = visitanteQueryRepository;
        }



        public async Task<VisitanteFlat> ObterPorId(Guid id)
        {
            return await _visitanteQueryRepository.ObterPorId(id);
        }        

        public async Task<IEnumerable<VisitanteFlat>> ObterVisitantesPorCondominio(Guid condominioId)
        {
            return await _visitanteQueryRepository.Obter(
                             c => c.CondominioId == condominioId &&
                             !c.Lixeira);
        }

        public async Task<IEnumerable<VisitanteFlat>> ObterVisitantesPorUnidade(Guid unidadeId)
        {
            return await _visitanteQueryRepository.Obter(
                            c => c.UnidadeId == unidadeId &&
                            !c.Lixeira);
        }

        public async Task<IEnumerable<VisitanteFlat>> ObterVisitantesPorDocumento(string documento)
        {
            return await _visitanteQueryRepository.Obter(
                            c => c.Documento == documento && !c.Lixeira);
        }


        public async Task<VisitaFlat> ObterVisitaPorId(Guid id)
        {
            return await _visitanteQueryRepository.ObterVisitaPorId(id);
        }

        public async Task<IEnumerable<VisitaFlat>> ObterVisitasPorCondominio(Guid condominioId)
        {
            return await _visitanteQueryRepository.ObterVisitas(
                             c => c.CondominioId == condominioId &&
                             !c.Lixeira);
        }

        public async Task<IEnumerable<VisitaFlat>> ObterVisitasPorUnidade(Guid unidadeId)
        {
            return await _visitanteQueryRepository.ObterVisitas(
                             c => c.UnidadeId == unidadeId &&
                             !c.Lixeira);
        }

        public async Task<IEnumerable<VisitaFlat>> ObterVisitasPorUsuario(Guid usuarioId)
        {
            return await _visitanteQueryRepository.ObterVisitas(
                             c => c.UsuarioId == usuarioId &&
                             !c.Lixeira);
        }

        public async Task<IEnumerable<VisitaFlat>> ObterVisitasPorPlacaOuModeloDoVeiculo(string pesquisa, Guid condominioId)
        {
            return await _visitanteQueryRepository.ObterVisitas(
                             c => c.CondominioId == condominioId &&
                             (c.PlacaVeiculo.Contains(pesquisa) || c.ModeloVeiculo.Contains(pesquisa)) &&
                             !c.Lixeira);
        }


        public void Dispose()
        {           
            _visitanteQueryRepository?.Dispose();
        }

       
    }
}