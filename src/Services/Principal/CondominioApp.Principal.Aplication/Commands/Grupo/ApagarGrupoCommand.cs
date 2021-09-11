using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class ApagarGrupoCommand : GrupoCommand
    {

        public ApagarGrupoCommand(Guid grupoId)
        {  
            GrupoId = grupoId;
        }


        public override bool EstaValido()
        {
            ValidationResult = new ApagarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarGrupoCommandValidation : GrupoValidation<ApagarGrupoCommand>
        {
            public ApagarGrupoCommandValidation()
            {
                ValidateId();                                           
            }
        }

    }
}
