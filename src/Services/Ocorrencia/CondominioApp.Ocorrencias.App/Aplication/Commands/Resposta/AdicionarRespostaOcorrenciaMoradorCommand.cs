using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class AdicionarRespostaOcorrenciaMoradorCommand : RespostaOcorrenciaCommand
    {
        public AdicionarRespostaOcorrenciaMoradorCommand
            (Guid ocorrenciaId, string descricao, Guid autorId, string nomeDoAutor,
             string fotoNomeOriginal, string arquivoAnexoNomeOriginal)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = TipoDoAutor.MORADOR;
            AutorId = autorId;
            NomeDoAutor = nomeDoAutor;
            SetFoto(fotoNomeOriginal);
            SetArquivoAnexo(arquivoAnexoNomeOriginal);
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
