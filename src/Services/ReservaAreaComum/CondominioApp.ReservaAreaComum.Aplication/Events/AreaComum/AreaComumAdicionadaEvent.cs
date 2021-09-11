﻿

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class AreaComumAdicionadaEvent : AreaComumEvent
    {
        public AreaComumAdicionadaEvent(
            Guid id, string nome, string descricao, string termoDeUso, Guid condominioId,
            string nomeCondominio, int capacidade, string diasPermitidos, int antecedenciaMaximaEmMeses,
            int antecedenciaMaximaEmDias, int antecedenciaMinimaEmDias, int antecedenciaMinimaParaCancelamentoEmDias,
            bool requerAprovacaoDeReserva, bool temHorariosEspecificos, string tempoDeIntervaloEntreReservas, bool ativa,
            string tempoDeDuracaoDeReserva, int numeroLimiteDeReservaPorUnidade, bool permiteReservaSobreposta,
            int numeroLimiteDeReservaSobreposta, int numeroLimiteDeReservaSobrepostaPorUnidade,
            string tempoDeIntervaloEntreReservasPorUnidade,string nomeOriginalArquivoAnexo, string nomeArquivoAnexo,
            ICollection<Periodo> periodos)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            TermoDeUso = termoDeUso;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Capacidade = capacidade;
            DiasPermitidos = diasPermitidos;
            AntecedenciaMaximaEmMeses = antecedenciaMaximaEmMeses;
            AntecedenciaMaximaEmDias = antecedenciaMaximaEmDias;
            AntecedenciaMinimaEmDias = antecedenciaMinimaEmDias;
            AntecedenciaMinimaParaCancelamentoEmDias = antecedenciaMinimaParaCancelamentoEmDias;
            RequerAprovacaoDeReserva = requerAprovacaoDeReserva;
            TemHorariosEspecificos = temHorariosEspecificos;
            TempoDeIntervaloEntreReservas = tempoDeIntervaloEntreReservas;
            Ativa = ativa;
            TempoDeDuracaoDeReserva = tempoDeDuracaoDeReserva;
            NumeroLimiteDeReservaPorUnidade = numeroLimiteDeReservaPorUnidade;
            PermiteReservaSobreposta = permiteReservaSobreposta;
            NumeroLimiteDeReservaSobreposta = numeroLimiteDeReservaSobreposta;
            NumeroLimiteDeReservaSobrepostaPorUnidade = numeroLimiteDeReservaSobrepostaPorUnidade;
            TempoDeIntervaloEntreReservasPorUnidade = tempoDeIntervaloEntreReservasPorUnidade;
            Periodos = periodos;
            NomeOriginalArquivoAnexo = nomeOriginalArquivoAnexo;
            NomeArquivoAnexo = nomeArquivoAnexo;
        }

    }
}