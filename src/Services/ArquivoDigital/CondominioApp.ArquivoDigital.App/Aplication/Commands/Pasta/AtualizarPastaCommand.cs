using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AtualizarPastaCommand : PastaCommand
    {

        public AtualizarPastaCommand(Guid id, string titulo, string descricao, bool publica)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;            
            Publica = publica;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarPastaCommandCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarPastaCommandCommandValidation : PastaValidation<AtualizarPastaCommand>
        {
            public AtualizarPastaCommandCommandValidation()
            {
                ValidateId();
                ValidateTitulo();
                ValidateDescricao();                                  
                ValidatePublica();               
            }
        }

    }
}
