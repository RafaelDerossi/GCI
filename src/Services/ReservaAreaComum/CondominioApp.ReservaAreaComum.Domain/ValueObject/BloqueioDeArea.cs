using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ValueObject
{
    public class BloqueioDeArea
    {
        public DateTime? blockInicio { get; private set; }
        public DateTime? blockFim { get; private set; }

        protected BloqueioDeArea() { }

        public BloqueioDeArea(DateTime blockInicio, DateTime blockFim)
        {
            setIntervaloDeBloqueio(blockInicio, blockFim);
        }

        public void setNullBloqueio()
        {
            blockInicio = null;
            blockFim = null;
        }

        public void setIntervaloDeBloqueio(DateTime dtini, DateTime dtFim)
        {
            if (dtini != null)
                blockInicio = dtini;
            else
                throw new Exception("Data de início do bloqueio deve ser definida.");

            if (dtFim != null)
                blockFim = dtFim;
            else
                throw new Exception("Data de fim do bloqueio deve ser definida.");

            if (dtFim < dtini)
                throw new Exception("A data de fim do bloqueio é menor que a data de início do bloqueio, por favor verifique!");
        }

        public bool EstaBloqueada(DateTime DataDeRealizacaoDaReserva)
        {
            if (blockInicio != null && blockFim != null)
                if (DataDeRealizacaoDaReserva >= blockInicio && DataDeRealizacaoDaReserva <= blockFim)
                    return true;

            return false;
        }

        public override string ToString()
        {
            if (blockInicio != null && blockFim != null)
                return "Esta área comum se encontra indisponível no período de " + string.Format("{0:d}", blockInicio) + " a " + string.Format("{0:d}", blockFim);

            return base.ToString();
        }
    }
}
