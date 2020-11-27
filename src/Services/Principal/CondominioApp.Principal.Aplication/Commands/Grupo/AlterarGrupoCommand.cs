using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AlterarGrupoCommand : GrupoCommand
    {

        public AlterarGrupoCommand(Guid grupoId, string descricao)
        {            
            Descricao = descricao;
            GrupoId = grupoId;
        }


        public override bool EstaValido()
        {
            if (!base.EstaValido())
                return ValidationResult.IsValid;

            ValidationResult = new AlterarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarGrupoCommandValidation : GrupoValidation<AlterarGrupoCommand>
        {
            public AlterarGrupoCommandValidation()
            {
                ValidateId();
                ValidateDescricao();                               
            }
        }

    }
}
