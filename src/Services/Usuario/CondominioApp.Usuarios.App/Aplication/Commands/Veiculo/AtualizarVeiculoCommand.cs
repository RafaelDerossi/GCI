using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AtualizarVeiculoCommand : VeiculoCommand
    {
        public AtualizarVeiculoCommand
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

            ValidationResult = new AtualizarVeiculoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarVeiculoCommandValidation : VeiculoValidation<AtualizarVeiculoCommand>
        {
            public AtualizarVeiculoCommandValidation()
            {
                ValidateVeiculoCondominioId();
                ValidatePlaca();
                ValidateModelo();
                ValidateCor();
            }
        }

    }
}