using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.App.Aplication.Query
{
    public interface IAreaComumQuery : IDisposable
    {
        Task<AreaComum> ObterPorId(Guid id);

        Task<IEnumerable<AreaComum>> ObterPorCondominio(Guid condominioId);

        Task<IEnumerable<AreaComum>> ObterPorCondominioEAtiva(Guid condominioId,  bool Ativa);      
    }
}