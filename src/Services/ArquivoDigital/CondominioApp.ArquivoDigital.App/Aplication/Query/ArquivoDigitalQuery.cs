using CondominioApp.ArquivoDigital.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Aplication.Query
{
    public class ArquivoDigitalQuery : IArquivoDigitalQuery
    {
        private IArquivoDigitalRepository _pastaRepository;

        public ArquivoDigitalQuery(IArquivoDigitalRepository pastaRepository)
        {
            _pastaRepository = pastaRepository;
        }


        #region Pasta
        public async Task<Pasta> ObterPorId(Guid Id)
        {
            return await _pastaRepository.ObterPorId(Id);
        }

        public async Task<IEnumerable<Pasta>> ObterTodos()
        {
            return await _pastaRepository.ObterTodos();
        }

        public async Task<IEnumerable<Pasta>> ObterRemovidos()
        {
            return await _pastaRepository.Obter(c => c.Lixeira);
        }

        public async Task<IEnumerable<Pasta>> ObterPorCondominio(Guid condominioId)
        {
            return await _pastaRepository.Obter(e => e.CondominioId == condominioId && !e.Lixeira);
        }

        #endregion





        public void Dispose()
        {
            _pastaRepository?.Dispose();
        }
    }
}