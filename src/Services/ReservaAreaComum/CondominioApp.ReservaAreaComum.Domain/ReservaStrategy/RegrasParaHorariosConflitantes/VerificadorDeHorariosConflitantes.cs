
namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaHorariosConflitantes
{
    public static class VerificadorDeHorariosConflitantes
    {
        public static bool Verificar(IHorario horarioA, IHorario horarioB)
        {
           int _horaInicioA = horarioA.ObterHoraInicio;
           int _horaFimA = horarioA.ObterHoraFim; ;
           int _horaInicioB = horarioB.ObterHoraInicio;
           int _horaFimB = horarioB.ObterHoraFim;

            if ( _horaInicioA < _horaFimA && _horaInicioB < _horaFimB)
            {
                if (
                    (_horaInicioB == _horaInicioA && _horaFimB == _horaFimA)
                    ||
                    (_horaFimB > _horaInicioA && _horaFimB < _horaFimA)
                    ||
                    (_horaFimA > _horaInicioB && _horaFimA <= _horaFimB)
                    ||
                    (_horaInicioA > _horaInicioB && _horaFimA < _horaFimB)
                    ||
                    (_horaInicioB > _horaInicioA && _horaFimB < _horaFimA)
                    )
                {
                    return true;
                }
            }
            else if (_horaInicioA < _horaFimA)
            {
                if (
                    (_horaInicioB == _horaInicioA && _horaFimB == _horaFimA)
                    ||
                    (_horaFimB > _horaInicioA && _horaFimB < _horaFimA)
                    ||
                    (_horaFimA > _horaInicioB && _horaFimA < _horaFimB)
                    ||
                    (_horaInicioA > _horaInicioB && _horaFimA < _horaFimB)
                    ||
                    (_horaInicioA < _horaInicioB && _horaInicioA < _horaFimB)
                    )
                {
                    return true;
                }
            }
            else if (_horaInicioB < _horaFimB)
            {
                if (
                    (_horaInicioB == _horaInicioA && _horaFimB == _horaFimA)
                    ||
                    (_horaFimB > _horaInicioA && _horaFimB < _horaFimA)
                    ||
                    (_horaFimA > _horaInicioB && _horaFimA < _horaFimB)                   
                    ||
                    (_horaInicioB > _horaInicioA && _horaFimB < _horaFimA)
                    ||
                    (_horaInicioB <_horaInicioA && _horaInicioB < _horaFimA)
                    ||
                    (_horaInicioB < _horaInicioA && _horaFimB > _horaInicioA)
                    )
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;

        }       

    }
}
