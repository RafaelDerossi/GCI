using System;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioConfiguracaoEditadoEvent : CondominioEvent
    {
      
        public CondominioConfiguracaoEditadoEvent(Guid id,
           bool portaria, bool portariaMorador, bool classificado, bool classificadoMorador,
           bool mural, bool muralMorador, bool chat, bool chatMorador, bool reserva,
           bool reservaNaPortaria, bool ocorrencia, bool ocorrenciaMorador, bool correspondencia,
           bool correspondenciaNaPortaria, bool cadastroDeVeiculoPeloMoradorAtivado)            
        {
            CondominioId = id;       
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
        }


    }
}