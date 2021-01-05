
namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class VerificadorDeHorariosConflitantes
    {
        private int _horaInicioA;

        private int _horaFimA;

        private int _horaInicioB;

        private int _horaFimB;
       

        public bool Verificar(int horaInicioA, int horaFimA, int horaInicioB, int horaFimB)
        {
            _horaInicioA = horaInicioA;
            _horaFimA = horaFimA;
            _horaInicioB = horaInicioB;
            _horaFimB = horaFimB;

            if ( _horaInicioA < _horaFimA && _horaInicioB < _horaFimB)
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
