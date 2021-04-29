using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasGerais;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasParaAdministrador;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva
{
    public class RegrasDeCriacaoDeReserva : IRegrasDeCriacaoDeReserva
    {
        private readonly IRegrasDeMoradorParaReservar _regrasDeMoradorParaReservar;

        private readonly IRegrasDeAdministradorParaReservar _regrasDeAdministradorParaReservar;

        private readonly IRegrasGeraisParaReservar _regrasGerais;

        public RegrasDeCriacaoDeReserva
            (IRegrasDeMoradorParaReservar regrasDeMoradorParaReservar,
             IRegrasDeAdministradorParaReservar regrasDeAdministradorParaReservar,
             IRegrasGeraisParaReservar regrasGerais)
        {
            _regrasDeMoradorParaReservar = regrasDeMoradorParaReservar;
            _regrasDeAdministradorParaReservar = regrasDeAdministradorParaReservar;
            _regrasGerais = regrasGerais;
        }

        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            var resultado = _regrasGerais.Validar(_reserva, _areaComum);
            if (!resultado.IsValid)
                return resultado;

            if (_reserva.CriadaPelaAdministracao)
              return _regrasDeAdministradorParaReservar.Validar(_reserva);                
            

            return _regrasDeMoradorParaReservar.Validar(_reserva, _areaComum);
        }

        public ValidationResult VerificaReservasAprovadas(Reserva _reserva, AreaComum _areaComum)
        {
            return _regrasGerais.VerificaReservasAprovadas(_reserva, _areaComum);
        }
    }
}
