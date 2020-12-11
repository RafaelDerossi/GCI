using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Aplication.Query
{
    public interface IComunicadoQuery : IDisposable
    {
        Task<Comunicado> ObterPorId(Guid id);       

        Task<IEnumerable<Comunicado>> ObterPorCondominioUnidadeEProprietario(Guid condominioId, Guid UnidadeId, bool IsProprietario);

        Task<IEnumerable<Comunicado>> ObterPorCondominioEUsuario(Guid condominioId, Guid usuarioId);

      
    }
}