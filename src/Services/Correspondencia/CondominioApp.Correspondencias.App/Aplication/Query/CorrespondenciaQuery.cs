using CondominioApp.Core.Enumeradores;
using CondominioApp.Correspondencias.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Correspondencias.App.Aplication.Query
{
    public class CorrespondenciaQuery : ICorrespondenciaQuery
    {
        private readonly ICorrespondenciaRepository _correspondenciaRepository;

        public CorrespondenciaQuery(ICorrespondenciaRepository correspondenciaRepository)
        {
            _correspondenciaRepository = correspondenciaRepository;
        }


        public async Task<Correspondencia> ObterPorId(Guid id)
        {
            return await _correspondenciaRepository.ObterPorId(id);
        }

        public async Task<Correspondencia> ObterPorCodigo(string codigo)
        {
            var correspondencia = await _correspondenciaRepository.Obter(
              c => c.CodigoDeVerificacao == codigo && !c.Lixeira);

            return correspondencia.FirstOrDefault();
        }

        public async Task<IEnumerable<Correspondencia>> ObterPorUnidadeEPeriodo(
            Guid unidadeId, DateTime dataInicio, DateTime dataFim)
        {
            return await _correspondenciaRepository.Obter(
                c=>c.UnidadeId == unidadeId && 
                c.DataDeCadastro.Date >= dataInicio.Date && c.DataDeCadastro.Date <= dataFim.Date && 
                !c.Lixeira, true);
        }

        public async Task<IEnumerable<Correspondencia>> ObterPorCondominioPeriodoEStatus(
            Guid condominioId, DateTime dataInicio, DateTime dataFim, StatusCorrespondencia status)
        {           
            return await _correspondenciaRepository.Obter(
                 c => c.CondominioId == condominioId &&
                 c.DataDeCadastro.Date >= dataInicio.Date && c.DataDeCadastro.Date <= dataFim.Date &&
                 c.Status == status &&
                 !c.Lixeira, true);
        }        
        
        
        public async Task<IEnumerable<HistoricoCorrespondencia>> ObterHistoricoPorCorrespondencia(Guid correspondenciaId)
        {           
            return await _correspondenciaRepository.ObterHistoricoPorCorrespondenciaId(correspondenciaId);
        }        



        public void Dispose()
        {
            _correspondenciaRepository?.Dispose();
        }
    }
}