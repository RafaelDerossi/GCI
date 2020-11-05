using System.Threading.Tasks;

namespace CondominioApp.Core.Data
{
    public interface IUnitOfWorks
    {
        Task<bool> Commit();
    }
}