using System;
using FluentValidation;

namespace CondominioApp.Enquetes.App.Aplication.Commands.Validations
{
   public class EnqueteValidation<T> : AbstractValidator<T> where T : EnqueteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty()
                .Length(2, 200).WithMessage("Descrição da Enquete deve ter mais de 2 caracteres!");
        }

        protected void ValidateDataInicial()
        {
            RuleFor(c => c.DataInicio)
                .NotEmpty()
                .NotNull()                
                .WithMessage("Data Inicial não pode estar vazio!");
        }

        protected void ValidateDataFinal()
        {
            RuleFor(c => c.DataFim)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data Final não pode estar vazio!");
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

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Condominio não pode estar vazio!");
        }

        protected void ValidateCondominioNome()
        {
            RuleFor(c => c.CondominioNome)
                .NotEmpty()
                .Length(2, 200).WithMessage("Nome do condominio deve ter mais de 2 caracteres!");
        }

        protected void ValidateApenasProprietarios()
        {
            RuleFor(c => c.ApenasProprietarios)
                .NotNull()
                .WithMessage("Apenas Proprietarios não pode estar vazio!");
        }
        

    }
}
