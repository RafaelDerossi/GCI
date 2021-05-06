

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AprovarReservaPelaAdministracaoCommand : ReservaCommand
    {

        public AprovarReservaPelaAdministracaoCommand
            (Guid reservaId, Guid funcionarioid, string nomeFuncionario, string origem)
        {            
            Id = reservaId;
            FuncionarioId = funcionarioid;
            NomeFuncionario = nomeFuncionario;
            Origem = origem;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AprovarReservaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AprovarReservaCommandValidation : ReservaValidation<AprovarReservaPelaAdministracaoCommand>
        {
            public AprovarReservaCommandValidation()
            {
                ValidateId();
                ValidateFuncionarioId();
                ValidateNomeFuncionario();
                ValidateOrigem();
            }
        }

    }
}
