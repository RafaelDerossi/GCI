using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class RemoverGrupoCommand : GrupoCommand
    {

        public RemoverGrupoCommand(Guid grupoId)
        {  
            GrupoId = grupoId;
        }


        public override bool EstaValido()
        {
            ValidationResult = new RemoverGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverGrupoCommandValidation : GrupoValidation<RemoverGrupoCommand>
        {
            public RemoverGrupoCommandValidation()
            {
                ValidateId();                                           
            }
        }

    }
}
