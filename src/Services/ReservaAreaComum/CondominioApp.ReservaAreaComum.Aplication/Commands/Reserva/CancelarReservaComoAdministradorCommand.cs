

using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class CancelarReservaComoAdministradorCommand : ReservaCommand
    {

        public CancelarReservaComoAdministradorCommand
            (Guid reservaId, string justificatica, Guid funcionarioId, string nomeFuncionario, string origem)
        {            
            Id = reservaId;
            Justificativa = justificatica;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Origem = origem;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CancelarReservaComoAdministradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CancelarReservaComoAdministradorCommandValidation : ReservaValidation<CancelarReservaComoAdministradorCommand>
        {
            public CancelarReservaComoAdministradorCommandValidation()
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
