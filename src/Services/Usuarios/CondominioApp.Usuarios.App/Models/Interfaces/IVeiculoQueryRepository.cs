using CondominioApp.Core.Data;
using CondominioApp.Usuarios.App.FlatModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Models
{
    public interface IVeiculoQueryRepository : IRepository<VeiculoFlat>
    {
        Task<VeiculoFlat> ObterVeiculoPorPlaca(string placa);

        Task<IEnumerable<VeiculoFlat>> ObterPorVeiculoId(Guid veiculoId);

        Task<VeiculoFlat> ObterPorVeiculoCondominioId(Guid veiculoCondominioId);

        void Remover(VeiculoFlat veiculo);
    }
}