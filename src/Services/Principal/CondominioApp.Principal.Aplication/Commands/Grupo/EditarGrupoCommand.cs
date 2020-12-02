using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class EditarGrupoCommand : GrupoCommand
    {

        public EditarGrupoCommand(Guid grupoId, string descricao)
        {            
            Descricao = descricao;
            GrupoId = grupoId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarGrupoCommandValidation : GrupoValidation<EditarGrupoCommand>
        {
            public EditarGrupoCommandValidation()
            {
                ValidateId();
                ValidateDescricao();                               
            }
        }

    }
}
