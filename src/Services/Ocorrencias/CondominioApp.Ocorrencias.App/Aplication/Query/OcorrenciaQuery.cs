using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Core.Helpers;

namespace CondominioApp.Ocorrencias.App.Aplication.Query
{
    public class OcorrenciaQuery : IOcorrenciaQuery
    {
        private IOcorrenciaRepository _ocorrenciaRepository;
        private readonly int meses = -60;
        private readonly int take = 100;

        public OcorrenciaQuery(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }


        public async Task<Ocorrencia> ObterPorId(Guid id)
        {
            return await _ocorrenciaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Ocorrencia>> ObterPorMoradorOuPublicas(Guid condominioId, Guid moradorId)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                 c => c.CondominioId == condominioId &&
                      (c.MoradorId == moradorId || c.Publica) &&
                      c.DataDeCadastro >= dataAtrasada &&
                      !c.Lixeira, true, take);
        }


        public async Task<IEnumerable<Ocorrencia>> ObterPorCondominio(Guid condominioId)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                 c => c.CondominioId == condominioId &&
                 c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }        

        public async Task<IEnumerable<Ocorrencia>> ObterPorCondominioEStatus(Guid condominioId, StatusDaOcorrencia status)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                 c => c.CondominioId == condominioId &&
                 c.Status == status &&
                 c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }        
        
        public async Task<IEnumerable<Ocorrencia>> ObterPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                c => c.CondominioId == condominioId &&
                c.Descricao.Contains(filtro) &&
                c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }

        public async Task<IEnumerable<Ocorrencia>> ObterPorCondominioEStatusEFiltro(Guid condominioId, StatusDaOcorrencia status, string filtro)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                 c => c.CondominioId == condominioId &&
                 c.Status == status &&
                 c.Descricao.Contains(filtro) &&
                 c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }


        public async Task<IEnumerable<Ocorrencia>> ObterPorUnidade(Guid unidadeId)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                 c => c.UnidadeId == unidadeId &&
                 c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }

        public async Task<IEnumerable<Ocorrencia>> ObterPorUnidadeEStatus(Guid unidadeId, StatusDaOcorrencia status)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                 c => c.UnidadeId == unidadeId &&
                 c.Status == status &&
                 c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }

        public async Task<IEnumerable<Ocorrencia>> ObterPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                c => c.UnidadeId == unidadeId &&
                c.Descricao.Contains(filtro) &&
                c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }

        public async Task<IEnumerable<Ocorrencia>> ObterPorUnidadeEStatusEFiltro(Guid unidadeid, StatusDaOcorrencia status, string filtro)
        {
            var dataAtrasada = DataHoraDeBrasilia.Get().AddMonths(meses);
            return await _ocorrenciaRepository.Obter(
                 c => c.UnidadeId == unidadeid &&
                 c.Status == status &&
                 c.Descricao.Contains(filtro) &&
                 c.DataDeCadastro >= dataAtrasada &&
                 !c.Lixeira, true, take);
        }



        public async Task<IEnumerable<RespostaOcorrencia>> ObterRespostasPorOcorrencia(Guid ocorrenciaId)
        {            
            return await _ocorrenciaRepository.ObterRespostasPorOcorrencia(ocorrenciaId);
        }

        public void Dispose()
        {
            _ocorrenciaRepository?.Dispose();
        }

    }
}