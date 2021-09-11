using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AtualizarVagasDaUnidadeCommand : UnidadeCommand
    {
        public AtualizarVagasDaUnidadeCommand(Guid unidadeId, int vagas)
        {
            UnidadeId = unidadeId;
            Vaga = vagas;
        }

        public override bool EstaValido()
        {
            ValidationResult = new AtualizarVagasDaUnidadeCommandCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarVagasDaUnidadeCommandCommandValidation : UnidadeValidation<AtualizarVagasDaUnidadeCommand>
        {
            public AtualizarVagasDaUnidadeCommandCommandValidation()
            {
                ValidateId();                                    
            }
        }

    }
}
