using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class RemoverCondominioCredencialCommand : CondominioCredencialCommand
    {
        public RemoverCondominioCredencialCommand(Guid id)
        {
            Id = id;            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverCondominioCredencialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverCondominioCredencialCommandValidation : CondominioCredencialValidation<RemoverCondominioCredencialCommand>
        {
            public RemoverCondominioCredencialCommandValidation()
            {
                ValidateId();             
            }
        }
    }
}
