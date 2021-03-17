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

        protected void ValidateTamanho()
        {
            RuleFor(c => c.Tamanho)
                .NotEmpty()
                .WithMessage("Tamanho do Arquivo deve ser maior que zero!"); ;
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

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNomeUsuario()
        {
            RuleFor(c => c.NomeUsuario)
                .NotEmpty()
                .NotNull();
        }

        protected void ValidateTitulo()
        {
            RuleFor(c => c.Titulo)
                .Length(0, 50).WithMessage("Titulo do arquivo deve ter ate 50 caracteres!");
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .Length(0, 200).WithMessage("Descrição do arquivo deve ter até 200 caracteres!");
        }

    }
}
