using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Models
{
    public interface IComunidadoRepository : IRepository<Comunicado>
    {
        void AdicionarUnidade(Unidade entity);

        void RemoverUnidade(Unidade entity);

        Task<IEnumerable<Unidade>> ObterUnidades(Expression<Func<Unidade, bool>> expression, bool OrderByDesc = false, int take = 0);
    }
}