using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class CadastrarArquivoCommand : ArquivoCommand
    {

        public CadastrarArquivoCommand
            (string nomeOriginal, string extensao, int tamanho, Guid condominioId, Guid pastaId, bool publico)
        {            
            NomeOriginal = nomeOriginal;
            Extensao = extensao;
            Tamanho = tamanho;
            CondominioId = condominioId;
            PastaId = pastaId;
            Publico = publico;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarArquivoCommandValidation : ArquivoValidation<CadastrarArquivoCommand>
        {
            public CadastrarArquivoCommandValidation()
            {
                ValidateNome();
                ValidateNomeOriginal();
                ValidateExtensao();
                ValidateTamanho();
                ValidateCondominioId();
                ValidatePastaId();
                ValidatePublico();
            }
        }

    }
}
