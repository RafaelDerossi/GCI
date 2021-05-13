using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AdicionarPastaCommand : PastaCommand
    {

        public AdicionarPastaCommand(string titulo, string descricao, Guid condominioId, bool publica,
            bool pastaDoSistema = false, CategoriaDaPastaDeSistema categoriaDaPastaDeSistema = 0)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            CondominioId = condominioId;
            Publica = publica;
            PastaDoSistema = pastaDoSistema;
            CategoriaDaPastaDeSistema = categoriaDaPastaDeSistema;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarPastaCommandValidation : PastaValidation<AdicionarPastaCommand>
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
