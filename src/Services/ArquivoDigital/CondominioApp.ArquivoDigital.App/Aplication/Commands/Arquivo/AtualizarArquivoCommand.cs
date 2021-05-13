using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AtualizarArquivoCommand : ArquivoCommand
    {

        public AtualizarArquivoCommand
            (Guid id, string titulo, string descricao,  bool publico, string nomeArquivo, string nomeOriginal)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Publico = publico;
            SetNome(nomeArquivo, nomeOriginal);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarArquivoCommandValidation : ArquivoValidation<AtualizarArquivoCommand>
        {
            public AtualizarArquivoCommandValidation()
            {
                ValidateId();
                ValidateTitulo();
                ValidateDescricao();
                ValidatePublico();
            }
        }

    }
}
