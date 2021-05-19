using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class AdicionarRespostaOcorrenciaMoradorCommand : RespostaOcorrenciaCommand
    {
        public AdicionarRespostaOcorrenciaMoradorCommand
            (Guid ocorrenciaId, string descricao, Guid moradorIdFuncionarioId, string nomeUsuario,
             string fotoNomeOriginal)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = TipoDoAutor.MORADOR;
            MoradorIdFuncionarioId = moradorIdFuncionarioId;
            NomeUsuario = nomeUsuario;
            SetFoto(fotoNomeOriginal);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarRespostaOcorrenciaMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarRespostaOcorrenciaMoradorCommandValidation : RespostaOcorrenciaValidation<AdicionarRespostaOcorrenciaMoradorCommand>
        {
            public AdicionarRespostaOcorrenciaMoradorCommandValidation()
            {
                ValidateOcorrenciaId();
                ValidateDescricao();
                ValidateMoradorIdFuncionarioId();

            }
        }
    }
}
