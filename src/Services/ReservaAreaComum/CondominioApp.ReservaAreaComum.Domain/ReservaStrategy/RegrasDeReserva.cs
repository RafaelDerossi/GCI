using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class RegrasDeReserva : IRegrasDeReserva
    {
        protected IRegrasDeReservaEspecificas _regraEspecifica { get; private set; }

        protected IRegrasDeReservaGlobais _regraGlobal { get; private set; }

        public RegrasDeReserva(IRegrasDeReservaEspecificas regraEspecifica, IRegrasDeReservaGlobais regraGlobal)
        {
            _regraEspecifica = regraEspecifica;
            _regraGlobal = regraGlobal;
        }

        public ValidationResult Validar()
        {            
            var resultado = _regraEspecifica.Validar();
            if (!resultado.IsValid)
                return resultado;


            return _regraGlobal.Validar();
        }
                
        
    }
}
