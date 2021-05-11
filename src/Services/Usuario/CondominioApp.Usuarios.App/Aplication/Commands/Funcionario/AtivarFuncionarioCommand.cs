using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AtivarFuncionarioCommand : FuncionarioCommand
    {
        public AtivarFuncionarioCommand
            (Guid funcionarioId)
        {
            Id = funcionarioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtivarFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtivarFuncionarioCommandValidation : FuncionarioValidation<AtivarFuncionarioCommand>
        {
            public AtivarFuncionarioCommandValidation()
            {
                ValidateId();
            }
        }

    }
}