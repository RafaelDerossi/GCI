

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AtualizarAreaComumCommand : AreaComumCommand
    {

        public AtualizarAreaComumCommand(
            Guid areaComumId, string nome, string descricao, string termoDeUso, int capacidade, string diasPermitidos,
            int antecedenciaMaximaEmMeses, int antecedenciaMaximaEmDias, int antecedenciaMinimaEmDias,
            int antecedenciaMinimaParaCancelamentoEmDias, bool requerAprovacaoDeReserva, bool temHorariosEspecificos,
            string tempoDeIntervaloEntreReservas, string tempoDeDuracaoDeReserva, 
            int numeroLimiteDeReservaPorUnidade, bool permiteReservaSobreposta, int numeroLimiteDeReservaSobreposta,
            int numeroLimiteDeReservaSobrepostaPorUnidade, string tempoDeIntervaloEntreReservasPorUnidade,
            DateTime? dataInicioBloqueio, DateTime? dataFimBloqueio, ICollection<Periodo> periodos)
        {
            Id = areaComumId;
            SetNome(nome);
            Descricao = descricao;
            TermoDeUso = termoDeUso;
            Capacidade = capacidade;
            SetDiasPermitidos(diasPermitidos);
            SetAntecedenciaMaximaEmMeses(antecedenciaMaximaEmMeses);
            SetAntecedenciaMaximaEmDias(antecedenciaMaximaEmDias);
            SetAntecedenciaMinimaEmDias(antecedenciaMinimaEmDias);
            SetAntecedenciaMinimaParaCancelamentoEmDias(antecedenciaMinimaParaCancelamentoEmDias);
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = temHorariosEspecificos;
            SetTempoDeIntervaloEntreReservas(tempoDeIntervaloEntreReservas);
            SetTempoDeDuracaoDeReserva(tempoDeDuracaoDeReserva);
            SetNumeroLimiteDeReservaPorUnidade(numeroLimiteDeReservaPorUnidade);
            PermiteReservaSobreposta = permiteReservaSobreposta;
            SetNumeroLimiteDeReservaSobreposta(numeroLimiteDeReservaSobreposta);
            SetNumeroLimiteDeReservaSobrepostaPorUnidade(numeroLimiteDeReservaSobrepostaPorUnidade);
            SetTempoDeIntervaloEntreReservasPorUnidade(tempoDeIntervaloEntreReservasPorUnidade);
            Periodos = periodos;
            DataInicioBloqueio = dataInicioBloqueio;
            DataFimBloqueio = dataFimBloqueio;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarAreaComumCommandValidation :AreaComumValidation<AtualizarAreaComumCommand>
        {
            public AtualizarAreaComumCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateTermoDeUso();
                ValidateDiasPermitidos();
                ValidateAntecedenciaMaximaEmMeses();
                ValidateAntecedenciaMaximaEmDias();
                ValidateAntecedenciaMinimaEmDias();
                ValidateAntecedenciaMinimaParaCancelamentoEmDias();
                ValidateRequerAprovacaoDeReserva();
                ValidateTemHorariosEspecificos();
                ValidateNumeroLimiteDeReservaPorUnidade();
                ValidatePermiteReservaSobreposta();
                ValidateNumeroLimiteDeReservaSobreposta();
                ValidateNumeroLimiteDeReservaSobrepostaPorUnidade();
                ValidatePeriodos();
            }
        }

    }
}
