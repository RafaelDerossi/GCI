using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class EditarPastaCommand : PastaCommand
    {

        public EditarPastaCommand(Guid id, string titulo, string descricao, Guid condominioId, bool publica)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            CondominioId = condominioId;
            Publica = publica;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarPastaCommandValidation : PastaValidation<EditarPastaCommand>
        {
            public EditarPastaCommandValidation()
            {
                ValidateId();
                ValidateTitulo();
                ValidateDescricao();                
                ValidateCondominioId();                
                ValidatePublica();               
            }
        }

    }
}
