using CondominioApp.ArquivoDigital.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Aplication.Query
{
    public class ArquivoDigitalQuery : IArquivoDigitalQuery
    {
        private IArquivoDigitalRepository _arquivoDigitalRepository;

        public ArquivoDigitalQuery(IArquivoDigitalRepository pastaRepository)
        {
            _arquivoDigitalRepository = pastaRepository;
        }


        #region Pasta
        public async Task<Pasta> ObterPorId(Guid Id)
        {
            return await _arquivoDigitalRepository.ObterPorId(Id);
        }

        public async Task<IEnumerable<Pasta>> ObterTodos()
        {
            return await _arquivoDigitalRepository.ObterTodos();
        }

        public async Task<IEnumerable<Pasta>> ObterRemovidos()
        {
            return await _arquivoDigitalRepository.Obter(c => c.Lixeira);
        }

        public async Task<IEnumerable<Pasta>> ObterPorCondominio(Guid condominioId)
        {
            return await _arquivoDigitalRepository.Obter(e => e.CondominioId == condominioId && !e.Lixeira);
        }

        #endregion


        #region Arquivo
        public async Task<Arquivo> ObterArquivoPorId(Guid Id)
        {
            return await _arquivoDigitalRepository.ObterArquivoPorId(Id);
        }

        public async Task<IEnumerable<Arquivo>> ObterArquivosPorPasta(Guid pastaId)
        {
            return await _arquivoDigitalRepository.ObterArquivo(e => e.PastaId == pastaId && !e.Lixeira);
        }

        public async Task<IEnumerable<Arquivo>> ObterArquivosPorCondominio(Guid condominioId)
        {
            return await _arquivoDigitalRepository.ObterArquivo(e => e.CondominioId == condominioId && !e.Lixeira);
        }

        #endregion



        public void Dispose()
        {
            _arquivoDigitalRepository?.Dispose();
        }
    }
}