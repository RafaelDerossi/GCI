using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class CadastrarArquivoCommand : ArquivoCommand
    {

        public CadastrarArquivoCommand
            (string nomeOriginal, int tamanho, Guid condominioId, Guid pastaId, bool publico)
        {
            Id = Guid.NewGuid();
            Tamanho = tamanho;
            CondominioId = condominioId;
            PastaId = pastaId;
            Publico = publico;
            SetNome(nomeOriginal);
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
                ValidateTamanho();
                ValidateCondominioId();
                ValidatePastaId();
                ValidatePublico();
            }
        }

    }
}
