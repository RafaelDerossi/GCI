using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CondominioApp.Usuarios.App.Aplication.Query
{
    public interface IUsuarioQuery : IDisposable
    {
        Task<Usuario> ObterPorId(Guid Id);

        Task<VeiculoFlat> ObterVeiculoPorPlacaECondominio(string placa, Guid condominioId);

        Task<IEnumerable<VeiculoFlat>> ObterVeiculosPorCondominio(Guid condominioId);

        Task<IEnumerable<VeiculoFlat>> ObterVeiculosPorUsuario(Guid usuarioId);
    }
}