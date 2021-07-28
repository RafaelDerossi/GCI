using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoDefinidoEvent : CondominioEvent
    {      
        public ContratoDefinidoEvent(Guid condominioId, Guid contratoId, DateTime dataAssinaturaContrato,
           TipoDePlano tipoPlano, string descricaoContrato, bool contratoAtivo,
           int quantidadeDeUnidadesContratadas, NomeArquivo arquivoContrato,
           bool portaria, bool portariaMorador, bool classificado, bool classificadoMorador,
           bool mural, bool muralMorador, bool chat, bool chatMorador, bool reserva,
           bool reservaNaPortaria, bool ocorrencia, bool ocorrenciaMorador, bool correspondencia,
           bool correspondenciaNaPortaria, bool cadastroDeVeiculoPeloMoradorAtivado, bool enqueteAtivada,
           bool controleDeAcessoAtivado, bool tarefaAtivada, bool orcamentoAtivado, bool automacaoAtivada)            
        {
            CondominioId = condominioId;                   
            ContratoId = contratoId;
            DataAssinatura = dataAssinaturaContrato;
            TipoPlano = tipoPlano;
            DescricaoContrato = descricaoContrato;
            ContratoAtivo = contratoAtivo;
            QuantidadeDeUnidadesContratadas = quantidadeDeUnidadesContratadas;
            ArquivoContrato = arquivoContrato;
            PortariaAtivada = portaria;
            PortariaMoradorAtivada = portariaMorador;
            ClassificadoAtivado = classificado;
            ClassificadoMoradorAtivado = classificadoMorador;
            MuralAtivado = mural;
            MuralMoradorAtivado = muralMorador;
            ChatAtivado = chat;
            ChatMoradorAtivado = chatMorador;
            ReservaAtivada = reserva;
            ReservaNaPortariaAtivada = reservaNaPortaria;
            OcorrenciaAtivada = ocorrencia;
            OcorrenciaMoradorAtivada = ocorrenciaMorador;
            CorrespondenciaAtivada = correspondencia;
            CorrespondenciaNaPortariaAtivada = correspondenciaNaPortaria;
            CadastroDeVeiculoPeloMoradorAtivado = cadastroDeVeiculoPeloMoradorAtivado;
            EnqueteAtivada = enqueteAtivada;
            ControleDeAcessoAtivado = controleDeAcessoAtivado;
            TarefaAtivada = tarefaAtivada;
            OrcamentoAtivado = orcamentoAtivado;
            AutomacaoAtivada = automacaoAtivada;
        }
    }
}