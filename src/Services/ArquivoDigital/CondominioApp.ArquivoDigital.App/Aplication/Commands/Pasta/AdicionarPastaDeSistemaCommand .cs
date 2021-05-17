using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AdicionarPastaDeSistemaCommand : PastaCommand
    {

        public AdicionarPastaDeSistemaCommand
            (string titulo, string descricao, Guid condominioId,
             CategoriaDaPastaDeSistema categoriaDaPastaDeSistema)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            CondominioId = condominioId;            
            CategoriaDaPastaDeSistema = categoriaDaPastaDeSistema;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarPastaCommandValidation : PastaValidation<AdicionarPastaDeSistemaCommand>
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
