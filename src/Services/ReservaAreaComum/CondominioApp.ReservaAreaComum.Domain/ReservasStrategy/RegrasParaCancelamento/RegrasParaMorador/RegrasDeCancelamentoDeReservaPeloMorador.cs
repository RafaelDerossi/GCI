using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras.Interfaces;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaMorador
{
    public class RegrasDeCancelamentoDeReservaPeloMorador : IRegrasDeCancelamentoDeReservaPeloMorador
    {
        private readonly IRegraDoStatusPraCancelar _regraDoStatusParaCancelar;

        private readonly IRegraDoPrazoMinimoPraCancelar _regraDoPrazoMinimoPraCancelar;

        public RegrasDeCancelamentoDeReservaPeloMorador
            (IRegraDoStatusPraCancelar regraDoStatusParaCancelar, IRegraDoPrazoMinimoPraCancelar regraDoPrazoMinimoPraCancelar)
        {
            _regraDoStatusParaCancelar = regraDoStatusParaCancelar;
            _regraDoPrazoMinimoPraCancelar = regraDoPrazoMinimoPraCancelar;
        }

        public ValidationResult Validar(Reserva reserva, AreaComum areaComum)
        {
            if (reserva.Status == StatusReserva.NA_FILA)
                return new ValidationResult();

            var retorno = _regraDoStatusParaCancelar.Validar(reserva);
            if (!retorno.IsValid)
                return retorno;
            

            return _regraDoPrazoMinimoPraCancelar.Validar(reserva, areaComum);

        }
    }
}
