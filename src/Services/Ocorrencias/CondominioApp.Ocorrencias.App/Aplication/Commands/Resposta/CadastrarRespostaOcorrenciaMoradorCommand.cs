using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class CadastrarRespostaOcorrenciaMoradorCommand : RespostaOcorrenciaCommand
    {
        public CadastrarRespostaOcorrenciaMoradorCommand
            (Guid ocorrenciaId, string descricao, Guid moradorIdFuncionarioId, string nomeUsuario,
             string fotoNome, string fotoNomeOriginal)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = TipoDoAutor.MORADOR;
            MoradorIdFuncionarioId = moradorIdFuncionarioId;
            NomeUsuario = nomeUsuario;
            SetFoto(fotoNomeOriginal, fotoNome);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarRespostaOcorrenciaMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarRespostaOcorrenciaMoradorCommandValidation : RespostaOcorrenciaValidation<CadastrarRespostaOcorrenciaMoradorCommand>
        {
            public CadastrarRespostaOcorrenciaMoradorCommandValidation()
            {
                ValidateOcorrenciaId();
                ValidateDescricao();
                ValidateMoradorIdFuncionarioId();

            }
        }
    }
}
