using CondominioApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Models
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Veiculo> ObterVeiculoPorId(Guid Id);        

        Task<IEnumerable<Veiculo>> ObterVeiculo(Expression<Func<Veiculo, bool>> expression, bool OrderByDesc = false, int take = 0);

        Task<Veiculo> ObterVeiculoPorPlaca(string placa);



        void AdicionarVeiculo(Veiculo veiculo);

        void AtualizarVeiculo(Veiculo entity);

        void AdicionarVeiculoCondominio(VeiculoCondominio veiculo);
        void RemoverVeiculoCondominio(VeiculoCondominio unidade);
    }
}