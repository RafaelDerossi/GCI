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
        void AdicionarUnidade(UnidadeComunicado entity);

        void RemoverUnidade(UnidadeComunicado entity);

        Task<IEnumerable<UnidadeComunicado>> ObterUnidades(Expression<Func<UnidadeComunicado, bool>> expression, bool OrderByDesc = false, int take = 0);
    }
}