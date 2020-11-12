using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

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
            var Result = new CadastrarGrupoCommandValidation().Validate(this);
            return Result.IsValid;
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
