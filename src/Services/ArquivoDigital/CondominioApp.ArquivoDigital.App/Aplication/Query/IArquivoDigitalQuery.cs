using CondominioApp.ArquivoDigital.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Aplication.Query
{
    public interface IArquivoDigitalQuery : IDisposable
    {
        Task<Pasta> ObterPorId(Guid Id);

        Task<IEnumerable<Pasta>> ObterTodos();

        Task<IEnumerable<Pasta>> ObterRemovidos();

        Task<IEnumerable<Pasta>> ObterPorCondominio(Guid condominioId);
        
    }
}