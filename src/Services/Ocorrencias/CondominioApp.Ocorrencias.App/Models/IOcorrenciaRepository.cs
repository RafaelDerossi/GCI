using CondominioApp.Core.Data;

namespace CondominioApp.Ocorrencias.App.Models
{
    public interface IOcorrenciaRepository : IRepository<Ocorrencia>
    {
        void Remover(Ocorrencia entity);
    }
}