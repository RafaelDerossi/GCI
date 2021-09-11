using CondominioApp.Core.Data;
using CondominioApp.Usuarios.App.FlatModel;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Models
{
    public interface IFuncionarioQueryRepository : IRepository<FuncionarioFlat>
    {
        void Remover(FuncionarioFlat entity);
    }
}