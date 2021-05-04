using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class EditarVeiculoCommand : VeiculoCommand
    {
        public EditarVeiculoCommand
            (Guid veiculoId, string placa, string modelo, string cor)
        {
            Id = veiculoId;
            SetVeiculo(placa, modelo, cor);            
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarVeiculoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarVeiculoCommandValidation : VeiculoValidation<EditarVeiculoCommand>
        {
            public EditarVeiculoCommandValidation()
            {
                ValidateId();
                ValidatePlaca();
                ValidateModelo();
                ValidateCor();
            }
        }

    }
}