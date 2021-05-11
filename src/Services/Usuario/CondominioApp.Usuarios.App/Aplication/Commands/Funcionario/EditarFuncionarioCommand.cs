using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class EditarFuncionarioCommand : FuncionarioCommand
    {
        public EditarFuncionarioCommand
            (Guid funcionarioId, string atribuicao = null, string funcao = null, Permissao permissao = Permissao.USUARIO)
        {
            Id = funcionarioId;            
            Permissao = permissao;            
            Atribuicao = atribuicao;
            Funcao = funcao;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarFuncionarioCommandValidation : FuncionarioValidation<EditarFuncionarioCommand>
        {
            public EditarFuncionarioCommandValidation()
            {
                ValidateId();                
                ValidateAtribuicao();
                ValidateFuncao();
            }
        }

    }
}