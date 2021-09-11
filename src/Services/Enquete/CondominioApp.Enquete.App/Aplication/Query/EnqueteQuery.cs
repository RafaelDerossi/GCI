using CondominioApp.Core.Helpers;
using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Enquetes.App.Aplication.Query
{
    public class EnqueteQuery : IEnqueteQuery
    {
        private readonly IEnqueteRepository _enqueteRepository;

        public EnqueteQuery(IEnqueteRepository enqueteRepository)
        {
            _enqueteRepository = enqueteRepository;
        }


        #region Enquete
        public async Task<Enquete> ObterPorId(Guid Id)
        {
            return await _enqueteRepository.ObterPorId(Id);
        }

        public async Task<IEnumerable<Enquete>> ObterTodos()
        {
            return await _enqueteRepository.ObterTodos();
        }

        public async Task<IEnumerable<Enquete>> ObterRemovidos()
        {
            return await _enqueteRepository.Obter(c => c.Lixeira);
        }

        public async Task<IEnumerable<Enquete>> ObterPorCondominio(Guid condominioId)
        {
            return await _enqueteRepository.Obter(e => e.CondominioId == condominioId && !e.Lixeira);
        }

        public async Task<IEnumerable<Enquete>> ObterAtivasPorCondominio(Guid condominioId)
        {
            return await _enqueteRepository.Obter(e=>e.CondominioId == condominioId && !e.Lixeira && e.DataInicio <= DataHoraDeBrasilia.Get() && e.DataFim >= DataHoraDeBrasilia.Get());
        }      

        #endregion





        public void Dispose()
        {
            _enqueteRepository?.Dispose();
        }
    }
}