using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarFuncionarioCommand : FuncionarioCommand
    {
        public CadastrarFuncionarioCommand(Guid usuarioId, Guid condominioId, string nomeCondominio,
            string atribuicao = null, string funcao = null, Permissao permissao = Permissao.USUARIO)
        {
            UsuarioId = usuarioId;            
            Permissao = permissao;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Atribuicao = atribuicao;
            Funcao = funcao;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarFuncionarioCommandValidation : FuncionarioValidation<CadastrarFuncionarioCommand>
        {
            public CadastrarFuncionarioCommandValidation()
            {
                ValidateUsuarioId();
                ValidateCondominioId();                
                ValidateAtribuicao();
                ValidateFuncao();
            }
        }

    }
}