using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class RemoverVeiculoCommand : VeiculoCommand
    {
        public RemoverVeiculoCommand
            (Guid veiculoId, Guid condominioId)
        {
            VeiculoId = veiculoId;
            CondominioId = condominioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarVeiculoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarVeiculoCommandValidation : VeiculoValidation<RemoverVeiculoCommand>
        {
            public EditarVeiculoCommandValidation()
            {
                ValidateVeiculoId();
                ValidateCondominioId();
            }
        }

    }
}