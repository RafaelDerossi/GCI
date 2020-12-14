using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class GerenciadorDeReserva
    {

        private readonly RegrasStrategy _strategy;

        public GerenciadorDeReserva(RegrasStrategy strategy)
        {
            _strategy = strategy;
        }

        public ValidationResult Validar()
        {
            return _strategy.Validar();
        }
    }
}
