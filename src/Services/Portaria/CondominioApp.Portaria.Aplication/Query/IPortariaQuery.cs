using CondominioApp.Portaria.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.App.Aplication.Query
{
    public interface IPortariaQuery : IDisposable
    {
        Task<VisitanteFlat> ObterPorId(Guid id);
      
               

        Task<VisitaFlat> ObterVisitaPorId(Guid id);
      
        

    }
}