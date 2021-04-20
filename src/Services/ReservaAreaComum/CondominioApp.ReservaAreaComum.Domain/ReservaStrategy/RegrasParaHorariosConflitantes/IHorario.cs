using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaHorariosConflitantes
{
   public interface IHorario
    {
        public int ObterHoraInicio { get; }

        public int ObterHoraFim { get; }
    }
}
