using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{
    public abstract class VeiculoValidation<T> : AbstractValidator<T> where T : VeiculoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidatePlaca()
        {
            RuleFor(c => c.Placa)
                .NotNull().WithMessage("Placa não pode estar vazio!")
                .NotEmpty().WithMessage("Placa não pode estar vazio!")
                .Length(7, 7).WithMessage("Placa deve ter 7 caracteres!");
        }

        protected void ValidateModelo()
        {
            RuleFor(c => c.Modelo)
                  .NotNull().WithMessage("Modelo não pode estar vazio!")
                  .NotEmpty().WithMessage("Modelo não pode estar vazio!")
                  .Length(3, 200).WithMessage("Modelo deve ter mais de 2 caracteres!");                  
        }

        protected void ValidateCor()
        {
            RuleFor(c => c.Cor)
                  .NotNull().WithMessage("Cor não pode estar vazio!")
                  .NotEmpty().WithMessage("Cor não pode estar vazio!")
                  .Length(3, 30).WithMessage("Cor deve ter mais de 2 caracteres!");
        }

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }
    }
}
