using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class AtualizarRespostaOcorrenciaCommand : RespostaOcorrenciaCommand
    {
        public AtualizarRespostaOcorrenciaCommand
            (Guid id, Guid moradorIdFuncionarioId, string descricao, string fotoNomeOriginal)
        {
            Id = id;
            MoradorIdFuncionarioId = moradorIdFuncionarioId;
            Descricao = descricao;          
            SetFoto(fotoNomeOriginal);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarRespostaOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarRespostaOcorrenciaCommandValidation : RespostaOcorrenciaValidation<AtualizarRespostaOcorrenciaCommand>
        {
            public AtualizarRespostaOcorrenciaCommandValidation()
            {
                ValidateId();
                ValidateMoradorIdFuncionarioId();
                ValidateDescricao();
            }
        }
    }
}
