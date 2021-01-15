using CondominioApp.Portaria.Aplication.Commands;
using CondominioApp.Portaria.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.Factories
{
   public interface IVisitanteFactory
    {
        public Visitante Fabricar(VisitanteCommand request);

        public Visitante Fabricar(VisitaCommand request);
    }
}
