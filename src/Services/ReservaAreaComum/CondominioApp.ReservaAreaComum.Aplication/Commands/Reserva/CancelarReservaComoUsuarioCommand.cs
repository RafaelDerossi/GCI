

using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class CancelarReservaComoUsuarioCommand : ReservaCommand
    {

        public CancelarReservaComoUsuarioCommand
            (Guid reservaId, string justificatica, Guid moradorId, string nomeMorador, string origem)
        {            
            Id = reservaId;
            Justificativa = justificatica;
            MoradorId = moradorId;
            NomeMorador = nomeMorador;
            Origem = origem;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CancelarReservaComoUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CancelarReservaComoUsuarioCommandValidation : ReservaValidation<CancelarReservaComoUsuarioCommand>
        {
            public CancelarReservaComoUsuarioCommandValidation()
            {
                ValidateId();
                ValidateJustificativa();
                ValidateMoradorId();
                ValidateNomeMorador();
                ValidateOrigem();
            }
        }

    }
}
