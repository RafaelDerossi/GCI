using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ConfiguracaoDoCondominioAtualizadaEvent : CondominioEvent
    {
      
        public ConfiguracaoDoCondominioAtualizadaEvent(Guid id,
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