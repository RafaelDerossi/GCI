using CondominioApp.Comunicados.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Aplication.Query
{
    public interface IComunicadoQuery : IDisposable
    {
        Task<Comunicado> ObterPorId(Guid id);       

        Task<IEnumerable<Comunicado>> ObterPorCondominioEUnidadeEProprietario(Guid condominioId, Guid unidadeId, bool isProprietario);

        Task<IEnumerable<Comunicado>> ObterPorCondominioEUsuario(Guid condominioId, Guid usuarioId);

        Task<IEnumerable<Comunicado>> ObterPorCondominio(Guid condominioId);
    }
}