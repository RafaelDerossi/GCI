using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class EditarRespostaOcorrenciaCommand : RespostaOcorrenciaCommand
    {
        public EditarRespostaOcorrenciaCommand
            (Guid id, Guid moradorIdFuncionarioId, string descricao, string fotoNome, string fotoNomeOriginal)
        {
            Id = id;
            MoradorIdFuncionarioId = moradorIdFuncionarioId;
            Descricao = descricao;          
            SetFoto(fotoNomeOriginal, fotoNome);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarRespostaOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarRespostaOcorrenciaCommandValidation : RespostaOcorrenciaValidation<EditarRespostaOcorrenciaCommand>
        {
            public EditarRespostaOcorrenciaCommandValidation()
            {
                ValidateId();
                ValidateMoradorIdFuncionarioId();
                ValidateDescricao();
            }
        }
    }
}
