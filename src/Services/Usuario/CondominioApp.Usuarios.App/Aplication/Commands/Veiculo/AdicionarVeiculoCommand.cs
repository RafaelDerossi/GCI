using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AdicionarVeiculoCommand : VeiculoCommand
    {
        public AdicionarVeiculoCommand
            (Guid usuarioId, string placa, string modelo, string cor, Guid unidadeId, string numeroUnidade,
             string andarUnidade, string grupoDaUnidade, Guid condominioId, string nomeCondominio, string tag, 
             string observacao)
        {
            SetUsuarioId(usuarioId);
            SetVeiculo(placa, modelo, cor);            
            SetUnidade(unidadeId, numeroUnidade, andarUnidade, grupoDaUnidade);
            SetCondominio(condominioId, nomeCondominio);
            Tag = tag;
            Observacao = observacao;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarVeiculoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarVeiculoCommandValidation : VeiculoValidation<AdicionarVeiculoCommand>
        {
            public AdicionarVeiculoCommandValidation()
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