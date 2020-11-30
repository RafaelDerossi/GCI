using System;
using FluentValidation;

namespace CondominioApp.Enquetes.App.Aplication.Commands.Validations
{
   public class RespostaEnqueteValidation<T> : AbstractValidator<T> where T : RespostaEnqueteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUnidadeId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty)
                .WithMessage("A Unidade deve ser informada!"); ;
        }
        
        protected void ValidateUnidade()
        {
            RuleFor(c => c.Unidade)
                .NotEmpty()
                .NotNull()
                .Length(2, 200)
                .WithMessage("Descrição da Unidade deve ter mais de 2 caracteres!");
        }


        protected void ValidateBloco()
        {
            RuleFor(c => c.Bloco)
                .NotEmpty()
                .NotNull()
                .Length(2, 200).WithMessage("Bloco deve ter mais de 2 caracteres!");
        }

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Usuario não pode estar vazio!");
        }

        protected void ValidateUsuarioNome()
        {
            RuleFor(c => c.UsuarioNome)
                .NotEmpty()
                .Length(2, 200).WithMessage("Nome do usuario deve ter mais de 2 caracteres!");
        }

        protected void ValidateTipoUsuario()
        {
            RuleFor(c => c.TipoDeUsuario)
                .NotEmpty()
                .Length(2, 200).WithMessage("Tipo do usuario deve ter mais de 2 caracteres!");
        }

        protected void ValidateAlternativaId()
        {
            RuleFor(c => c.AlternativaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Alternativa deve ser informada!");
        }
    }
}
