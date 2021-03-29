using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class CadastrarRespostaOcorrenciaSindicoCommand : RespostaOcorrenciaCommand
    {
        public CadastrarRespostaOcorrenciaSindicoCommand
            (Guid ocorrenciaId, string descricao, Guid moradorIdFuncionarioId, string nomeUsuario,
             string fotoNome, string fotoNomeOriginal, StatusDaOcorrencia status)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = TipoDoAutor.SINDICO;
            MoradorIdFuncionarioId = moradorIdFuncionarioId;
            NomeUsuario = nomeUsuario;
            SetFoto(fotoNomeOriginal, fotoNome);
            Status = status;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarRespostaOcorrenciaSindicoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarRespostaOcorrenciaSindicoCommandValidation : RespostaOcorrenciaValidation<CadastrarRespostaOcorrenciaSindicoCommand>
        {
            public CadastrarRespostaOcorrenciaSindicoCommandValidation()
            {
                ValidateOcorrenciaId();
                ValidateDescricao();
                ValidateMoradorIdFuncionarioId();

            }
        }
    }
}
