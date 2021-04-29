using CondominioApp.Core.DomainObjects;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaHorariosConflitantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain
{
   public class Periodo : Entity, IHorario
    {
        public string HoraInicio { get; private set; }
        public string HoraFim { get; private set; }     
        public Guid AreaComumId { get; private set; }        
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }

        protected Periodo() { }

        public Periodo(string horaInicio, string horaFim, decimal valor, bool ativo)
        {
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Valor = valor;
            Ativo = ativo;
        }

        public int ObterHoraInicio
        {
            get
            {
                if (!string.IsNullOrEmpty(HoraInicio))
                    return Convert.ToInt32(HoraInicio.Replace(":", ""));

                return 0;
            }
        }

        public int ObterHoraFim
        {
            get
            {
                if (!string.IsNullOrEmpty(HoraFim))
                    return Convert.ToInt32(HoraFim.Replace(":", ""));

                return 0;
            }
        }       

       
    }
}
