using CondominioApp.Portaria.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Aplication.Query
{
    public interface IPortariaQuery : IDisposable
    {
        Task<VisitanteFlat> ObterPorId(Guid id);

        Task<IEnumerable<VisitanteFlat>> ObterVisitantesPorCondominio(Guid condominioId);

        Task<IEnumerable<VisitanteFlat>> ObterVisitantesPorUnidade(Guid unidadeId);

        Task<IEnumerable<VisitanteFlat>> ObterVisitantesPorDocumento(string documento);

        Task<VisitaFlat> ObterVisitaPorId(Guid id);

        Task<IEnumerable<VisitaFlat>> ObterVisitasPorCondominio(Guid condominioId);

        Task<IEnumerable<VisitaFlat>> ObterVisitasPorUnidade(Guid unidadeId);

        Task<IEnumerable<VisitaFlat>> ObterVisitasPorUsuario(Guid usuarioId);

    }
}