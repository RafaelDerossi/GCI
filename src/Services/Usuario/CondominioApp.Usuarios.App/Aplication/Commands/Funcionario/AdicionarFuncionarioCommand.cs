using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AdicionarFuncionarioCommand : FuncionarioCommand
    {
        public AdicionarFuncionarioCommand(Guid usuarioId, Guid condominioId, string nomeCondominio,
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

            ValidationResult = new AdicionarFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarFuncionarioCommandValidation : FuncionarioValidation<AdicionarFuncionarioCommand>
        {
            public AdicionarFuncionarioCommandValidation()
            {
                ValidateUsuarioId();
                ValidateCondominioId();                
                ValidateAtribuicao();
                ValidateFuncao();
            }
        }

    }
}