using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Ocorrencias.App.Aplication.Query
{
    public interface IOcorrenciaQuery : IDisposable
    {
        Task<Ocorrencia> ObterPorId(Guid id);

        Task<IEnumerable<Ocorrencia>> ObterPorCondominio(Guid condominioId);

        Task<IEnumerable<Ocorrencia>> ObterPorCondominioEUsuario(Guid condominioId, Guid usuarioId);        

        Task<IEnumerable<Ocorrencia>> ObterPorCondominioEStatus(Guid condominioId, StatusDaOcorrencia status);        

        Task<IEnumerable<Ocorrencia>> ObterPorCondominioEFiltro(Guid condominioId, string filtro);

        Task<IEnumerable<Ocorrencia>> ObterPorCondominioEStatusEFiltro(Guid condominioId, StatusDaOcorrencia status, string filtro);
    }
}