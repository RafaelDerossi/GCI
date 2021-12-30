using GCI.Core.Data;
using System.Threading.Tasks;

namespace GCI.Acoes.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<bool> VerificaEmailJaCadastrado(string email);
    }
}
