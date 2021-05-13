using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AdicionarGrupoCommand : GrupoCommand
    {

        public AdicionarGrupoCommand(string descricao, Guid condominioId)
        {            
            Descricao = descricao;
            CondominioId = condominioId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarGrupoCommandValidation : GrupoValidation<AdicionarGrupoCommand>
        {
            public AdicionarGrupoCommandValidation()
            {                               
                ValidateDescricao();
                ValidateCondominioId();                
            }
        }

    }
}
