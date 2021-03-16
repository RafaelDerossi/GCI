using System;
using FluentValidation;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations
{
   public class ArquivoValidation<T> : AbstractValidator<T> where T : ArquivoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .Length(1, 200).WithMessage("Nome do arquivo deve ter até 200 caracteres!");
        }

        protected void ValidateNomeOriginal()
        {
            RuleFor(c => c.NomeOriginal)                
                .Length(1, 200).WithMessage("Nome original do arquivo deve ter até 200 caracteres!");
        }

        protected void ValidateExtensao()
        {
            RuleFor(c => c.Extensao)
                .Length(2, 200).WithMessage("Extensão do arquivo deve ter entre 2 e 200 caracteres!");
        }

        protected void ValidateTamanho()
        {
            RuleFor(c => c.Tamanho)
                .NotEmpty()
                .WithMessage("Tamanho do Arquivo deve ser maior que zero!"); ;
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                
        }

        protected void ValidatePastaId()
        {
            RuleFor(c => c.PastaId)
                .NotEqual(Guid.Empty);                
        }

        protected void ValidatePublico()
        {
            RuleFor(c => c.Publico)                
                .NotNull()        
                .WithMessage("Publico não pode estar vazio!");
        }            
     
    }
}
