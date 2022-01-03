using GCI.Core.Data;
using System.Threading.Tasks;

namespace GCI.Acoes.Domain.Interfaces
{
    public interface IAcaoRepository : IRepository<Acao>
    {
        Task<bool> VerificaCodigoJaCadastrado(string codigo);
    }
}
