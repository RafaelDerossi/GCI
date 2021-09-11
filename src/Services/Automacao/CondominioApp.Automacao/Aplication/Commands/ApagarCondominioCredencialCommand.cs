using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class ApagarCondominioCredencialCommand : CondominioCredencialCommand
    {
        public ApagarCondominioCredencialCommand(Guid id)
        {
            Id = id;            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarCondominioCredencialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarCondominioCredencialCommandValidation : CondominioCredencialValidation<ApagarCondominioCredencialCommand>
        {
            public ApagarCondominioCredencialCommandValidation()
            {
                ValidateId();             
            }
        }
    }
}
