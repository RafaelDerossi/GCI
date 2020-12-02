using System;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioConfiguracaoEditadoEvent : CondominioEvent
    {
      
        public CondominioConfiguracaoEditadoEvent(Guid id, DateTime dataDeAlteracao,
           bool portaria, bool portariaMorador, bool classificado, bool classificadoMorador,
           bool mural, bool muralMorador, bool chat, bool chatMorador, bool reserva,
           bool reservaNaPortaria, bool ocorrencia, bool ocorrenciaMorador, bool correspondencia,
           bool correspondenciaNaPortaria, bool limiteTempoReserva)            
        {
            CondominioId = id;          
            DataDeAlteracao = dataDeAlteracao;           
            Portaria = portaria;
            PortariaMorador = portariaMorador;
            Classificado = classificado;
            ClassificadoMorador = classificadoMorador;
            Mural = mural;
            MuralMorador = muralMorador;
            Chat = chat;
            ChatMorador = chatMorador;
            Reserva = reserva;
            ReservaNaPortaria = reservaNaPortaria;
            Ocorrencia = ocorrencia;
            OcorrenciaMorador = ocorrenciaMorador;
            Correspondencia = correspondencia;
            CorrespondenciaNaPortaria = correspondenciaNaPortaria;
            LimiteTempoReserva = limiteTempoReserva;
        }


    }
}