using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.RegrasParaAdministracao;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.RegrasParaMorador;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento
{
    public class RegrasDeCancelamentoDeReserva : IRegrasDeCancelamentoDeReserva
    {
        private readonly IRegrasDeCancelamentoDeReservaPelaAdministracao _regrasAdm;

        private readonly IRegrasDeCancelamentoDeReservaPeloMorador _regrasMorador;

        public RegrasDeCancelamentoDeReserva(IRegrasDeCancelamentoDeReservaPelaAdministracao regrasAdm, IRegrasDeCancelamentoDeReservaPeloMorador regrasMorador)
        {
            _regrasAdm = regrasAdm;
            _regrasMorador = regrasMorador;
        }

        public ValidationResult ValidarCancelamentoPelaAdministracao(Reserva reserva)
        {
            return _regrasAdm.Validar(reserva);
        }

        public ValidationResult ValidarCancelamentoPeloMorador(Reserva reserva, AreaComum areaComum)
        {
            return _regrasMorador.Validar(reserva, areaComum);
        }
                
        
    }
}
