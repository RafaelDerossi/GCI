using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class EditarVeiculoCommand : VeiculoCommand
    {
        public EditarVeiculoCommand
            (Guid veiculoCondominioId, string placa, string modelo, string cor, string tag, string observacao)
        {
            VeiculoCondominioId = veiculoCondominioId;
            SetVeiculo(placa, modelo, cor);
            Tag = tag;
            Observacao = observacao;
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
                ValidateVeiculoCondominioId();
                ValidatePlaca();
                ValidateModelo();
                ValidateCor();
            }
        }

    }
}