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
                .NotNull().WithMessage("Antecedência Máxima em meses não pode estar vazio!");
        }

        protected void ValidateAntecedenciaMaximaEmDias()
        {
            RuleFor(c => c.AntecedenciaMaximaEmMeses)
                .NotNull().WithMessage("Antecedência Máxima em dias não pode estar vazio!");
        }

        protected void ValidateAntecedenciaMinimaEmDias()
        {
            RuleFor(c => c.AntecedenciaMinimaEmDias)
                .NotNull().WithMessage("Antecedência Mínima em dias não pode estar vazio!");
        }

        protected void ValidateAntecedenciaMinimaParaCancelamentoEmDias()
        {
            RuleFor(c => c.AntecedenciaMinimaParaCancelamentoEmDias)
                .NotNull().WithMessage("Antecedência Mínima para Cancelamento em dias não pode estar vazio!");
        }

        protected void ValidateRequerAprovacaoDeReserva()
        {
            RuleFor(c => c.RequerAprovacaoDeReserva)
                .NotNull().WithMessage("Requer Aprovação de Reserva não pode estar vazio!");
        }

        protected void ValidateTemHorariosEspecificos()
        {
            RuleFor(c => c.TemHorariosEspecificos)
                .NotNull().WithMessage("Tem Horários Específicos não pode estar vazio!");
        }

        protected void ValidateAtiva()
        {
            RuleFor(c => c.Ativa)
                .NotNull().WithMessage("Ativa não pode estar vazio!");
        }

        protected void ValidateNumeroLimiteDeReservaPorUnidade()
        {
            RuleFor(c => c.NumeroLimiteDeReservaPorUnidade)
                .NotNull().WithMessage("Número Limite De Reserva Por Unidade não pode estar vazio!");
        }

        protected void ValidatePermiteReservaSobreposta()
        {
            RuleFor(c => c.PermiteReservaSobreposta)
                .NotNull().WithMessage("Permite Reserva Sobreposta não pode estar vazio!");
        }

        protected void ValidateNumeroLimiteDeReservaSobreposta()
        {
            RuleFor(c => c.NumeroLimiteDeReservaSobreposta)
                .NotNull().WithMessage("Número Limite de Reserva Sobreposta não pode estar vazio!");
        }

        protected void ValidateNumeroLimiteDeReservaSobrepostaPorUnidade()
        {
            RuleFor(c => c.NumeroLimiteDeReservaSobrepostaPorUnidade)
                .NotNull().WithMessage("Número Limite de Reserva Sobreposta por Unidade não pode estar vazio!");
        }

        protected void ValidatePeriodos()
        {
            RuleForEach(c => c.Periodos).ChildRules(Regra =>
            {
                Regra.RuleFor(p => p.Ativo)
                .NotNull()
                .WithMessage("'Ativo' no Periodo não pode estar vazio!");

                Regra.RuleFor(p => p.HoraInicio)
                .NotEmpty().WithMessage("'Hora Inicio' no Periodo não pode estar vazia!")
                .NotNull().WithMessage("'Hora Inicio' no Periodo não pode estar nulo!");

                Regra.RuleFor(p => p.HoraFim)
                .NotEmpty().WithMessage("'Hora Fim' no Periodo não pode estar vazia!")
                .NotNull().WithMessage("'Hora Fim' no Periodo não pode estar nulo!");

                Regra.RuleFor(p => p.Valor)
               .NotNull().WithMessage("'Hora Fim' no Periodo não pode estar nulo!");
            });

        }
    }
}
