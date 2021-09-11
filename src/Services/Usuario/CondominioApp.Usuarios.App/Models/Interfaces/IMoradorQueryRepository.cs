using CondominioApp.Core.Data;
using CondominioApp.Usuarios.App.FlatModel;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Models
{
    public interface IMoradorQueryRepository : IRepository<MoradorFlat>
    {
        void Remover(MoradorFlat morador);
    }
}