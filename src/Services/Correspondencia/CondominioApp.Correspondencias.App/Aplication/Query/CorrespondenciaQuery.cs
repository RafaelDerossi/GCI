using CondominioApp.Core.Enumeradores;
using CondominioApp.Correspondencias.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Correspondencias.App.Aplication.Query
{
    public class CorrespondenciaQuery : ICorrespondenciaQuery
    {
        private ICorrespondenciaRepository _correspondenciaRepository;

        public CorrespondenciaQuery(ICorrespondenciaRepository correspondenciaRepository)
        {
            _correspondenciaRepository = correspondenciaRepository;
        }


        public async Task<Correspondencia> ObterPorId(Guid id)
        {
            return await _correspondenciaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Correspondencia>> ObterPorUnidadeEPeriodo(
            Guid unidadeId, DateTime dataInicio, DateTime dataFim)
        {
            return await _correspondenciaRepository.Obter(
                c=>c.UnidadeId == unidadeId && c.DataDeCadastro>=dataInicio && c.DataDeCadastro<=dataFim );
        }

        public async Task<IEnumerable<Correspondencia>> ObterPorCondominioPeriodoEStatus(
            Guid condominioId, DateTime dataInicio, DateTime dataFim, StatusCorrespondencia status)
        {           
            return await _correspondenciaRepository.Obter(
                 c => c.CondominioId == condominioId &&
                 c.DataDeCadastro >= dataInicio && c.DataDeCadastro <= dataFim &&
                 c.Status == status);
        }        
                



        public void Dispose()
        {
            _correspondenciaRepository?.Dispose();
        }
    }
}