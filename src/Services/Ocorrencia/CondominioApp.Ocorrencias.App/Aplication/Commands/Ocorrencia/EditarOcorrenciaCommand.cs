using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class EditarOcorrenciaCommand : OcorrenciaCommand
    {
        public EditarOcorrenciaCommand
            (Guid id, string descricao, string nomeOriginalfoto, string nomefoto,
             bool publica)
        {
            Id = id;
            Descricao = descricao;            
            Publica = publica;                        
            SetFoto(nomeOriginalfoto, nomefoto);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarOcorrenciaCommandValidation : OcorrenciaValidation<EditarOcorrenciaCommand>
        {
            public EditarOcorrenciaCommandValidation()
            {
                ValidateId();
                ValidateDescricao();
                ValidatePublica();
            }
        }
    }
}
