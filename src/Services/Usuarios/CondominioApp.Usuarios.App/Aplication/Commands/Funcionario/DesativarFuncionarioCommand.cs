using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class DesativarFuncionarioCommand : FuncionarioCommand
    {
        public DesativarFuncionarioCommand
            (Guid funcionarioId)
        {
            Id = funcionarioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DesativarFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DesativarFuncionarioCommandValidation : FuncionarioValidation<DesativarFuncionarioCommand>
        {
            public DesativarFuncionarioCommandValidation()
            {
                ValidateId();
            }
        }

    }
}