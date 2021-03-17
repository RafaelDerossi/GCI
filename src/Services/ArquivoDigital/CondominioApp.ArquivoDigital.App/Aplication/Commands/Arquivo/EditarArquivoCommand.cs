using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class EditarArquivoCommand : ArquivoCommand
    {

        public EditarArquivoCommand
            (Guid id, string novoNome,  bool publico)
        {
            Id = id;
            Publico = publico;
            SetNome(novoNome);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarArquivoCommandValidation : ArquivoValidation<EditarArquivoCommand>
        {
            public EditarArquivoCommandValidation()
            {
                ValidateId();       
                ValidatePublico();
            }
        }

    }
}
