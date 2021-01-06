

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class AreaComumEditadaEvent : AreaComumEvent
    {
        public AreaComumEditadaEvent(
            Guid id, string nome, string descricao, string termoDeUso, int capacidade, string diasPermitidos,
            int antecedenciaMaximaEmMeses, int antecedenciaMaximaEmDias, int antecedenciaMinimaEmDias,
            int antecedenciaMinimaParaCancelamentoEmDias, bool requerAprovacaoDeReserva, bool temHorariosEspecificos,
            string tempoDeIntervaloEntreReservas, string tempoDeDuracaoDeReserva, int numeroLimiteDeReservaPorUnidade,
            bool permiteReservaSobreposta, int numeroLimiteDeReservaSobreposta, int numeroLimiteDeReservaSobrepostaPorUnidade,
            ICollection<Periodo> periodos)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            TermoDeUso = termoDeUso;
            Capacidade = capacidade;
            DiasPermitidos = diasPermitidos;
            AntecedenciaMaximaEmMeses = antecedenciaMaximaEmMeses;
            AntecedenciaMaximaEmDias = antecedenciaMaximaEmDias;
            AntecedenciaMinimaEmDias = antecedenciaMinimaEmDias;
            AntecedenciaMinimaParaCancelamentoEmDias = antecedenciaMinimaParaCancelamentoEmDias;
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = temHorariosEspecificos;
            TempoDeIntervaloEntreReservas = tempoDeIntervaloEntreReservas;            
            TempoDeDuracaoDeReserva = tempoDeDuracaoDeReserva;
            NumeroLimiteDeReservaPorUnidade = numeroLimiteDeReservaPorUnidade;
            PermiteReservaSobreposta = permiteReservaSobreposta;
            NumeroLimiteDeReservaSobreposta = numeroLimiteDeReservaSobreposta;
            NumeroLimiteDeReservaSobrepostaPorUnidade = numeroLimiteDeReservaSobrepostaPorUnidade;
            Periodos = periodos;
        }

    }
}
