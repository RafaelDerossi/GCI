using CondominioApp.ReservaAreaComum.Aplication.Commands;
using FluentValidation;
using System;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class AreaComumValidation<T> : AbstractValidator<T> where T : AreaComumCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.AreaComumId)
                .NotEqual(Guid.Empty);
        }
       
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome da Area Comum não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome da Area Comum deve ter mais de 2 caracteres!");
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNomeCondominio()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do condominio não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do Condominio deve ter mais de 2 caracteres!");
        }

        protected void ValidateDiasPermitidos()
        {
            RuleFor(c => c.DiasPermitidos)
                .NotEmpty().WithMessage("Dias Permitidos não pode estar vazio!")
                .Length(5, 200).WithMessage("Dias permitidos deve ter mais de 5 caracteres!");
        }

        protected void ValidateAntecedenciaMaximaEmMeses()
        {
            RuleFor(c => c.AntecedenciaMaximaEmMeses)
                .NotEmpty().WithMessage("Antecedência Máxima Em Meses não pode estar vazio!");
        }
    }
}
