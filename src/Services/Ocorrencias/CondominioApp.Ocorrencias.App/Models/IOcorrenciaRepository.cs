using CondominioApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Ocorrencias.App.Models
{
    public interface IOcorrenciaRepository : IRepository<Ocorrencia>
    {
        Task<RespostaOcorrencia> ObterRespostaPorId(Guid Id);

        void AdicionarResposta(RespostaOcorrencia entity);

        void AtualizarResposta(RespostaOcorrencia entity);

        Task<IEnumerable<RespostaOcorrencia>> ObterRespostasPorOcorrencia(Guid ocorrenciaId);

    }
}