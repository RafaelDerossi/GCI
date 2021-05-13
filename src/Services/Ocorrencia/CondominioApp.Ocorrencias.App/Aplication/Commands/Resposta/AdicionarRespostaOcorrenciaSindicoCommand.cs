using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class AdicionarRespostaOcorrenciaSindicoCommand : RespostaOcorrenciaCommand
    {
        public AdicionarRespostaOcorrenciaSindicoCommand
            (Guid ocorrenciaId, string descricao, Guid moradorIdFuncionarioId, string nomeUsuario,
             string fotoNome, string fotoNomeOriginal, StatusDaOcorrencia status)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = TipoDoAutor.ADMINISTRACAO;
            MoradorIdFuncionarioId = moradorIdFuncionarioId;
            NomeUsuario = nomeUsuario;
            SetFoto(fotoNomeOriginal, fotoNome);
            Status = status;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarRespostaOcorrenciaSindicoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarRespostaOcorrenciaSindicoCommandValidation : RespostaOcorrenciaValidation<AdicionarRespostaOcorrenciaSindicoCommand>
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
