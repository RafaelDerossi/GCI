using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class CadastrarGrupoCommand : GrupoCommand
    {

        public CadastrarGrupoCommand(string descricao, Guid condominioId)
        {            
            Descricao = descricao;
            CondominioId = condominioId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarGrupoCommandValidation : GrupoValidation<CadastrarGrupoCommand>
        {
            public CadastrarGrupoCommandValidation()
            {                               
                ValidateDescricao();
                ValidateCondominioId();                
            }
        }

    }
}
