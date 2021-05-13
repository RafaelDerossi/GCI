using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AtualizarGrupoCommand : GrupoCommand
    {

        public AtualizarGrupoCommand(Guid grupoId, string descricao)
        {            
            Descricao = descricao;
            GrupoId = grupoId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarGrupoCommandValidation : GrupoValidation<AtualizarGrupoCommand>
        {
            public AtualizarGrupoCommandValidation()
            {
                ValidateId();
                ValidateDescricao();                               
            }
        }

    }
}
