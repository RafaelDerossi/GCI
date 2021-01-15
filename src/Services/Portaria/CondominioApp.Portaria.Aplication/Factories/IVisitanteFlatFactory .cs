using CondominioApp.Portaria.Aplication.Events;
using CondominioApp.Portaria.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.Factories
{
   public interface IVisitanteFlatFactory
    {
        public VisitanteFlat Fabricar(VisitanteEvent request);

        public VisitanteFlat Fabricar(VisitaEvent request);
    }
}
