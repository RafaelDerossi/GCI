using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras.Interfaces;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.RegrasParaAdministracao
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
