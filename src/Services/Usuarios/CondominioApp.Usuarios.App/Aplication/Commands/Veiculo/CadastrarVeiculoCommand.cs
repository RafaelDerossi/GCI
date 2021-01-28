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
        public CadastrarVeiculoCommand(Guid usuarioId, string placa, string modelo, string cor, Guid unidadeId)
        {
            UsuarioId = usuarioId;            
            SetPlaca(placa);
            SetModelo(modelo);
            SetCor(cor);
            UnidadeId = unidadeId;
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
            }
        }

    }
}