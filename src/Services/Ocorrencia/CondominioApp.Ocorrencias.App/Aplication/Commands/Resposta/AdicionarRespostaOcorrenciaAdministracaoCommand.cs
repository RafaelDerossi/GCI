using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class AdicionarRespostaOcorrenciaAdministracaoCommand : RespostaOcorrenciaCommand
    {
        public AdicionarRespostaOcorrenciaAdministracaoCommand
            (Guid ocorrenciaId, string descricao, Guid autorId, string nomeUsuario,
             string fotoNomeOriginal, StatusDaOcorrencia status, string nomeOriginalArquivoAnexo)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = TipoDoAutor.ADMINISTRACAO;
            AutorId = autorId;
            NomeDoAutor = nomeUsuario;
            SetFoto(fotoNomeOriginal);
            Status = status;
            SetArquivoAnexo(nomeOriginalArquivoAnexo);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarRespostaOcorrenciaSindicoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarRespostaOcorrenciaSindicoCommandValidation : RespostaOcorrenciaValidation<AdicionarRespostaOcorrenciaAdministracaoCommand>
        {
            public AdicionarRespostaOcorrenciaSindicoCommandValidation()
            {
                ValidateOcorrenciaId();
                ValidateDescricao();
                ValidateMoradorIdFuncionarioId();

            }
        }
    }
}
