using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AdicionarSubPastaCommand : PastaCommand
    {

        public AdicionarSubPastaCommand(string titulo, string descricao, bool publica, Guid pastaMaeId)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;            
            Publica = publica;
            PastaMaeId = pastaMaeId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarPastaCommandValidation : PastaValidation<AdicionarSubPastaCommand>
        {
            public AdicionarPastaCommandValidation()
            {
                ValidateTitulo();
                ValidateDescricao();                
                ValidatePublica();
                ValidatePastaMae();
            }
        }

    }
}
