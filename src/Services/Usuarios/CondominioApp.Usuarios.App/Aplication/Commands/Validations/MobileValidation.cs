using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{
    public abstract class MobileValidation<T> : AbstractValidator<T> where T : MobileCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateDeviceKey()
        {
            RuleFor(c => c.DeviceKey)
                .NotEmpty().WithMessage("DeviceKey não pode estar vazio!")
                .NotNull().WithMessage("DeviceKey não pode estar vazio!")
                .MaximumLength(200).WithMessage("DeviceKey deve ter no máximo 200 caracteres!");
                
        }

        protected void ValidateMobileId()
        {
            RuleFor(c => c.MobileId)
                  .NotEmpty().WithMessage("MobileId não pode estar vazio!")
                  .NotNull().WithMessage("MobileId não pode estar vazio!")
                  .MaximumLength(200).WithMessage("MobileId deve ter no máximo 200 caracteres!");
        }

        protected void ValidateModelo()
        {
            RuleFor(c => c.Modelo)                 
                  .MaximumLength(200).WithMessage("Modelo deve ter no máximo 200 caracteres!");
        }

        protected void ValidatePlataforma()
        {
            RuleFor(c => c.Plataforma)
                  .MaximumLength(200).WithMessage("Plataforma deve ter no máximo 200 caracteres!");
        }

        protected void ValidateVersao()
        {
            RuleFor(c => c.Versao)
                  .MaximumLength(200).WithMessage("Versao deve ter no máximo 200 caracteres!");
        }

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.MoradorFuncionarioId)
                .NotEqual(Guid.Empty);
        }

    }
}
