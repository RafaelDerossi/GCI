using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AdicionarPastaRaizCommand : PastaCommand
    {

        public AdicionarPastaRaizCommand(string titulo, string descricao, Guid condominioId, bool publica)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            CondominioId = condominioId;
            Publica = publica;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarPastaCommandValidation : PastaValidation<AdicionarPastaRaizCommand>
        {
            public AdicionarPastaCommandValidation()
            {
                ValidateTitulo();
                ValidateDescricao();                
                ValidateCondominioId();                
                ValidatePublica();               
            }
        }

    }
}
