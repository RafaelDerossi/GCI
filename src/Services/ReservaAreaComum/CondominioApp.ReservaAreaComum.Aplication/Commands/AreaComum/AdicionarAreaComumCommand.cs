

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AdicionarAreaComumCommand : AreaComumCommand
    {

        public AdicionarAreaComumCommand(
            string nome, string descricao, string termoDeUso, Guid condominioId, 
            string nomeCondominio, int capacidade, string diasPermitidos, int antecedenciaMaximaEmMeses,
            int antecedenciaMaximaEmDias, int antecedenciaMinimaEmDias, int antecedenciaMinimaParaCancelamentoEmDias,
            bool requerAprovacaoDeReserva, bool temHorariosEspecificos, string tempoDeIntervaloEntreReservas, bool ativa,
            string tempoDeDuracaoDeReserva, int numeroLimiteDeReservaPorUnidade, bool permiteReservaSobreposta,
            int numeroLimiteDeReservaSobreposta, int numeroLimiteDeReservaSobrepostaPorUnidade,
            string tempoDeIntervaloEntreReservasPorUnidade ,ICollection<Periodo> periodos)
        {           
            SetNome(nome);
            Descricao = descricao;
            TermoDeUso = termoDeUso;
            SetCondominioId(condominioId);
            SetNomeCondominio(nomeCondominio);
            Capacidade = capacidade;
            SetDiasPermitidos(diasPermitidos);
            SetAntecedenciaMaximaEmMeses(antecedenciaMaximaEmMeses);
            SetAntecedenciaMaximaEmDias(antecedenciaMaximaEmDias);
            SetAntecedenciaMinimaEmDias(antecedenciaMinimaEmDias);
            SetAntecedenciaMinimaParaCancelamentoEmDias(antecedenciaMinimaParaCancelamentoEmDias);
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = temHorariosEspecificos;
            SetTempoDeIntervaloEntreReservas(tempoDeIntervaloEntreReservas);
            Ativa = ativa;
            SetTempoDeDuracaoDeReserva(tempoDeDuracaoDeReserva);
            SetNumeroLimiteDeReservaPorUnidade(numeroLimiteDeReservaPorUnidade);
            PermiteReservaSobreposta = permiteReservaSobreposta;
            SetNumeroLimiteDeReservaSobreposta(numeroLimiteDeReservaSobreposta);
            SetNumeroLimiteDeReservaSobrepostaPorUnidade(numeroLimiteDeReservaSobrepostaPorUnidade);
            SetTempoDeIntervaloEntreReservasPorUnidade(tempoDeIntervaloEntreReservasPorUnidade);
            Periodos = periodos;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarAreaComumCommandValidation :AreaComumValidation<AdicionarAreaComumCommand>
        {
            public AdicionarAreaComumCommandValidation()
            { 
                ValidateNome();
                ValidateCondominioId();
                ValidateNomeCondominio();
                ValidateTermoDeUso();
                ValidateDiasPermitidos();
                ValidateAntecedenciaMaximaEmMeses();
                ValidateAntecedenciaMaximaEmDias();
                ValidateAntecedenciaMinimaEmDias();
                ValidateAntecedenciaMinimaParaCancelamentoEmDias();
                ValidateRequerAprovacaoDeReserva();
                ValidateTemHorariosEspecificos();
                ValidateAtiva();
                ValidateNumeroLimiteDeReservaPorUnidade();
                ValidatePermiteReservaSobreposta();
                ValidateNumeroLimiteDeReservaSobreposta();
                ValidateNumeroLimiteDeReservaSobrepostaPorUnidade();
                ValidatePeriodos();
            }
        }

    }
}
