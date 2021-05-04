using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CondominioApp.Automacao.App.Models;
using CondominioApp.Automacao.Models;

namespace CondominioApp.Automacao.App.Aplication.Query
{
    public class AutomacaoQuery : IAutomacaoQuery
    {
        private readonly IAutomacaoRepository _condominioCredencialRepository;

        public AutomacaoQuery(IAutomacaoRepository condominioCredencialRepository)
        {
            _condominioCredencialRepository = condominioCredencialRepository;
        }


        public async Task<CondominioCredencial> ObterPorId(Guid id)
        {
            return await _condominioCredencialRepository.ObterPorId(id);
        }


        public async Task<CondominioCredencial> ObterPorCondominioETipoApi
            (Guid condominioId, TipoApiAutomacao tipoApiAutomacao)
        {
            var lista = await _condominioCredencialRepository.Obter
                (c => c.CondominioId == condominioId && 
                 c.TipoApiAutomacao == tipoApiAutomacao && 
                 !c.Lixeira);

            if (lista == null || lista.Count() == 0)
                return null;

            return lista.FirstOrDefault();
        }

        public async Task<bool> VerificaSeJaEstaCadastrado(Guid condominioId, TipoApiAutomacao tipoApiAutomacao)
        {
            return await _condominioCredencialRepository.VerificaSeJaEstaCadastrado(condominioId, tipoApiAutomacao);
        }


        public void Dispose()
        {
            _condominioCredencialRepository?.Dispose();
        }

       
    }
}