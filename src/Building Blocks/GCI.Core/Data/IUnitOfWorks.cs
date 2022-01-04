using System.Threading.Tasks;

namespace GCI.Core.Data
{
    public interface IUnitOfWorks
    {
        Task<bool> Commit();
    }
}