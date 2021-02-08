using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarVeiculoCommand : VeiculoCommand
    {
        public CadastrarVeiculoCommand
            (Guid usuarioId, string placa, string modelo, string cor, Guid unidadeId, string numeroUnidade,
            string andarUnidade, string grupoDaUnidade, Guid condominioId, string nomeCondominio)
        {
            SetUsuarioId(usuarioId);
            SetVeiculo(placa, modelo, cor);            
            SetUnidade(unidadeId, numeroUnidade, andarUnidade, grupoDaUnidade);
            SetCondominio(condominioId, nomeCondominio);
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

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
                ValidateNumeroUnidade();
                ValidateAndarUnidade();
                ValidateGrupoDaUnidade();

                ValidateCondominioId();
                ValidateNomeCondominio();

            }
        }

    }
}