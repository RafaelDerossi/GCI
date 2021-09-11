using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class ApagarVeiculoCommand : VeiculoCommand
    {
        public ApagarVeiculoCommand
            (Guid veiculoId, Guid condominioId)
        {
            VeiculoId = veiculoId;
            CondominioId = condominioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarVeiculoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarVeiculoCommandValidation : VeiculoValidation<ApagarVeiculoCommand>
        {
            public ApagarVeiculoCommandValidation()
            {
                ValidateVeiculoId();
                ValidateCondominioId();
            }
        }

    }
}