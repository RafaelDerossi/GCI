using CondominioApp.ArquivoDigital.App.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;

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

        public async Task<Pasta> ObterPastaDeSistema(CategoriaDaPastaDeSistema categoriaDaPastaDeSistema, Guid condominioId)
        {
            var retorno = await _arquivoDigitalRepository
                .Obter(p => p.CategoriaDaPastaDeSistema == categoriaDaPastaDeSistema &&
                       p.CondominioId == condominioId && p.PastaDoSistema == true);
            return retorno.FirstOrDefault();
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

        public async Task<IEnumerable<Arquivo>> ObterArquivosPorAnexadoPorId(Guid anexadoPorId)
        {
            return await _arquivoDigitalRepository.ObterArquivo(e => e.AnexadoPorId == anexadoPorId && !e.Lixeira);
        }

        #endregion



        public void Dispose()
        {
            _arquivoDigitalRepository?.Dispose();
        }
    }
}