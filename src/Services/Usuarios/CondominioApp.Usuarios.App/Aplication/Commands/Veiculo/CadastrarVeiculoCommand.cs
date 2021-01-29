using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.ValueObjects;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using FluentValidation;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarVeiculoCommand : VeiculoCommand
    {
        public CadastrarVeiculoCommand(Guid usuarioId, string placa, string modelo, string cor, Guid unidadeId, Guid condominioId)
        {
            SetUsuarioId(usuarioId);
            SetPlaca(placa);
            SetModelo(modelo);
            SetCor(cor);
            SetUnidadeId(unidadeId);
            SetCondominioId(condominioId);
        }

        public override bool EstaValido()
        {
            ValidationResult = new CadastrarVeiculoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarVeiculoCommandValidation : VeiculoValidation<CadastrarVeiculoCommand>
        {
            public CadastrarVeiculoCommandValidation()
            {
                ValidatePlaca();
                ValidateModelo();
                ValidateCor();
                ValidateUsuarioId();
                ValidateUnidadeId();
                ValidateCondominioId();
            }
        }

    }
}