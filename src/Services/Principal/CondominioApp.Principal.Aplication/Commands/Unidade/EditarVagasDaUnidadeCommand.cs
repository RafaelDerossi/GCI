using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class EditarVagasDaUnidadeCommand : UnidadeCommand
    {
        public EditarVagasDaUnidadeCommand(Guid unidadeId, int vagas)
        {
            UnidadeId = unidadeId;
            Vaga = vagas;
        }

        public override bool EstaValido()
        {
            ValidationResult = new EditarVagasDaUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarVagasDaUnidadeCommandValidation : UnidadeValidation<EditarVagasDaUnidadeCommand>
        {
            public EditarVagasDaUnidadeCommandValidation()
            {
                ValidateId();                                    
            }
        }

    }
}
