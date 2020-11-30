using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class CadastrarRespostaCommand : RespostaEnqueteCommand
    {

        public CadastrarRespostaCommand(Guid unidadeId, string unidade, string bloco,
            Guid usuarioId, string usuarioNome, string tipoDeUsuario,
            Guid alternativaId )
        {            
            UnidadeId = unidadeId;
            Unidade = unidade;
            Bloco = bloco;
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            TipoDeUsuario = tipoDeUsuario;
            AlternativaId = alternativaId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarRespostaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarRespostaCommandValidation : RespostaEnqueteValidation<CadastrarRespostaCommand>
        {
            public CadastrarRespostaCommandValidation()
            {               
                ValidateUnidadeId();
                ValidateUnidade();
                ValidateBloco();
                ValidateUsuarioId();
                ValidateUsuarioNome();
                ValidateTipoUsuario();
                ValidateAlternativaId();                              
            }
        }

    }
}
