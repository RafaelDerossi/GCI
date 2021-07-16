using CondominioApp.ReservaAreaComum.Aplication.Commands;
using FluentValidation;
using System;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class AreaComumValidation<T> : AbstractValidator<T> where T : AreaComumCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
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
            RuleFor(c => c.NomeCondominio)
                .NotNull().WithMessage("Nome do condominio não pode estar vazio!")
                .NotEmpty().WithMessage("Nome do condominio não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do Condominio deve ter mais de 2 caracteres!");
        }

        protected void ValidateTermoDeUso()
        {
            RuleFor(c => c.TermoDeUso)
                .Length(0, 500).WithMessage("Termo de Uso deve ter no máximo 500 caracteres!");
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
                .NotNull().WithMessage("Antecedência Máxima em meses não pode estar vazio!")
                .GreaterThan(-1).WithMessage("Antecedência Máxima em meses deve ser maior ou igual a zero!");
        }

        protected void ValidateAntecedenciaMaximaEmDias()
        {
            RuleFor(c => c.AntecedenciaMaximaEmDias)
                .NotNull().WithMessage("Antecedência Máxima em dias não pode estar vazio!")
                .GreaterThan(-1).WithMessage("Antecedência Máxima em dias deve ser maior ou igual a zero!");
        }

        protected void ValidateAntecedenciaMinimaEmDias()
        {
            RuleFor(c => c.AntecedenciaMinimaEmDias)
                .NotNull().WithMessage("Antecedência Mínima em dias não pode estar vazio!")
                .GreaterThan(-1).WithMessage("Antecedência Mínima deve ser maior ou igual a zero!");
        }

        protected void ValidateAntecedenciaMinimaParaCancelamentoEmDias()
        {
            RuleFor(c => c.AntecedenciaMinimaParaCancelamentoEmDias)
                .NotNull().WithMessage("Antecedência Mínima para Cancelamento em dias não pode estar vazio!")
                .GreaterThan(-1).WithMessage("Antecedência Mínima para cancelamento deve ser maior ou igual a zero!");
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
                .NotNull().WithMessage("Número Limite De Reserva Por Unidade não pode estar vazio!")
                .GreaterThan(-1).WithMessage("Número Limite de Reserva por Unidade deve ser maior ou igual a zero!");
        }

        protected void ValidatePermiteReservaSobreposta()
        {
            RuleFor(c => c.PermiteReservaSobreposta)
                .NotNull().WithMessage("Permite Reserva Sobreposta não pode estar vazio!");
        }

        protected void ValidateNumeroLimiteDeReservaSobreposta()
        {
            RuleFor(c => c.NumeroLimiteDeReservaSobreposta)
                .NotNull().WithMessage("Número Limite de Reserva Sobreposta não pode estar vazio!")
                .GreaterThan(-1).WithMessage("Número Limite de Reserva Sobreposta deve ser maior ou igual a zero!");
        }

        protected void ValidateNumeroLimiteDeReservaSobrepostaPorUnidade()
        {
            RuleFor(c => c.NumeroLimiteDeReservaSobrepostaPorUnidade)
                .NotNull().WithMessage("Número Limite de Reserva Sobreposta por Unidade não pode estar vazio!")
                .GreaterThan(-1).WithMessage("Número Limite de Reserva Sobreposta por Unidade deve ser maior ou igual a zero!");
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
                .NotNull().WithMessage("'Hora Inicio' no Periodo não pode estar nulo!")
                .Length(5).WithMessage("'Hora Inicio' deve ter 5 caracteres!")
                .Matches("[012][0-9]:[0-5][0-9]").WithMessage("Hora Inicio inválida!");

                Regra.RuleFor(p => p.HoraFim)
                .NotEmpty().WithMessage("'Hora Fim' no Periodo não pode estar vazia!")
                .NotNull().WithMessage("'Hora Fim' no Periodo não pode estar nulo!")
                .Length(5).WithMessage("'Hora Fim' deve ter 5 caracteres!")
                .Matches("[012][0-9]:[0-5][0-9]").WithMessage("Hora Fim inválida!");

                Regra.RuleFor(p => p.Valor)
               .NotNull().WithMessage("'Valor' do Periodo não pode estar nulo!");
            });

        }

        protected void ValidateArquivoAnexo()
        {
            RuleFor(c => c.NomeArquivoAnexo)
                .NotNull();
            RuleFor(c => c.NomeArquivoAnexo.NomeOriginal)
                .NotNull()
                .NotEmpty();

        }

    }
}
