using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class AtualizarOcorrenciaCommand : OcorrenciaCommand
    {
        public AtualizarOcorrenciaCommand
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

            ValidationResult = new AtualizarOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarOcorrenciaCommandValidation : OcorrenciaValidation<AtualizarOcorrenciaCommand>
        {
            public AtualizarOcorrenciaCommandValidation()
            {
                ValidateId();
                ValidateDescricao();
                ValidatePublica();
            }
        }
    }
}
