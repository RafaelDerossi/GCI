using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
   public class RegrasDeReserva : IRegrasDeReserva
    {
        private readonly IRegrasDeCriacaoDeReserva _regrasDeCriacao;

        private readonly IRegrasDeCancelamentoDeReserva _regrasDeCancelamento;

        public RegrasDeReserva(IRegrasDeCriacaoDeReserva regrasDeCriacao, IRegrasDeCancelamentoDeReserva regrasDeCancelamento)
        {
            _regrasDeCriacao = regrasDeCriacao;
            _regrasDeCancelamento = regrasDeCancelamento;
        }

        public ValidationResult ValidarRegrasParaCriacao(Reserva reserva, AreaComum areaComum)
        {
            return _regrasDeCriacao.Validar(reserva, areaComum);
        }
        public ValidationResult VerificaReservasAprovadas(Reserva reserva, AreaComum areaComum)
        {
            return _regrasDeCriacao.VerificaReservasAprovadas(reserva, areaComum);
        }
        
        public ValidationResult ValidarRegrasParaCancelamentoPelaAdministracao(Reserva reserva)
        {
            return _regrasDeCancelamento.ValidarCancelamentoPelaAdministracao(reserva);
        }

        public ValidationResult ValidarRegrasParaCancelamentoPeloMorador(Reserva reserva, AreaComum areaComum)
        {
            return _regrasDeCancelamento.ValidarCancelamentoPeloMorador(reserva, areaComum);
        }
    }
}
