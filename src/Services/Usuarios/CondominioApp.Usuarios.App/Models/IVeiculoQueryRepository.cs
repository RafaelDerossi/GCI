﻿using CondominioApp.Core.Data;
using CondominioApp.Usuarios.App.FlatModel;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Models
{
    public interface IVeiculoQueryRepository : IRepository<VeiculoFlat>
    {
        Task<VeiculoFlat> ObterVeiculoPorPlaca(string placa);
    }
}