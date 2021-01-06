using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
   public class PeriodoViewModel
    {
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
    }
}
