using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras.Interfaces;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaAdministracao
{
    public class RegrasDeCancelamentoDeReservaPelaAdministracao : IRegrasDeCancelamentoDeReservaPelaAdministracao
    {
        private readonly IRegraDoStatusPraCancelar _regraDoStatusParaCancelar;        

        public RegrasDeCancelamentoDeReservaPelaAdministracao
            (IRegraDoStatusPraCancelar regraDoStatusParaCancelar)
        {
            _regraDoStatusParaCancelar = regraDoStatusParaCancelar;            
        }

        public ValidationResult Validar(Reserva reserva)
        {           
            return _regraDoStatusParaCancelar.Validar(reserva);
        }

    }
}
