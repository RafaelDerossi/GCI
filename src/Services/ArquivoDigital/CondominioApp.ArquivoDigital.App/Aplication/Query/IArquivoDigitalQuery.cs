﻿using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Aplication.Query
{
    public interface IArquivoDigitalQuery : IDisposable
    {
        #region Pasta
        Task<Pasta> ObterPorId(Guid Id);

        Task<Pasta> ObterPastaComConteudo(Guid pastaId);

        Task<IEnumerable<Pasta>> ObterTodos();

        Task<IEnumerable<Pasta>> ObterRemovidos();

        Task<IEnumerable<Pasta>> ObterPorCondominio(Guid condominioId);

        Task<IEnumerable<Pasta>> ObterPastasRaizesPorCondominio(Guid condominioId);

        Task<Pasta> ObterPastaDeSistema(CategoriaDaPastaDeSistema categoriaDaPastaDeSistema, Guid condominioId);
        #endregion

        #region Arquivo
        Task<Arquivo> ObterArquivoPorId(Guid Id);

        Task<IEnumerable<Arquivo>> ObterArquivosPorPasta(Guid pastaId);

        Task<IEnumerable<Arquivo>> ObterArquivosPorCondominio(Guid condominioId);

        Task<IEnumerable<Arquivo>> ObterArquivosPorAnexadoPorId(Guid anexadoPorId);        

        #endregion

    }
}