

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class ReprovarReservaPelaAdmCommand : ReservaCommand
    {

        public ReprovarReservaPelaAdmCommand
        (Guid reservaId, string justificativa, Guid funcionarioid, string nomeFuncionario, string origem)
        {
            Id = reservaId;
            Justificativa = justificativa;
            FuncionarioId = funcionarioid;
            NomeFuncionario = nomeFuncionario;
            Origem = origem;
        }     


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ReprovarReservaPelaAdmCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ReprovarReservaPelaAdmCommandValidation : ReservaValidation<ReprovarReservaPelaAdmCommand>
        {
            public ReprovarReservaPelaAdmCommandValidation()
            {
                ValidateId();
                ValidateJustificativa();
                ValidateFuncionarioId();
                ValidateNomeFuncionario();
                ValidateOrigem();
            }
        }

    }
}
