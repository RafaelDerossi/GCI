using CondominioApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Correspondencias.App.Models
{
    public interface ICorrespondenciaRepository : IRepository<Correspondencia>
    {
        Task<IEnumerable<HistoricoCorrespondencia>> ObterHistoricoPorCorrespondenciaId(Guid correspondenciaId);

        void AdicionarHistorico(HistoricoCorrespondencia entity);

        void AtualizarHistorico(HistoricoCorrespondencia entity);

    }
}