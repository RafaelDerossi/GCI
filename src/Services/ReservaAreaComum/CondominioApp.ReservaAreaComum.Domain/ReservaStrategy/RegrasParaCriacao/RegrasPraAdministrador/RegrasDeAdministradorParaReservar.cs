using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasParaAdministrador
{
    public class RegrasDeAdministradorParaReservar : IRegrasDeAdministradorParaReservar
    {
        private readonly IRegraDataRetroativaPermitida _regraDaDataRetroativaPermitida;
       
        public RegrasDeAdministradorParaReservar
           (IRegraDataRetroativaPermitida regraDaDataRetroativa)            
        {            
            _regraDaDataRetroativaPermitida = regraDaDataRetroativa;         
        }

        public ValidationResult Validar(Reserva _reserva)
        {
            //Regra para Data de realizacao da Reserva Retroativa
            return _regraDaDataRetroativaPermitida.Validar(_reserva);            
        }
      
    }
}
