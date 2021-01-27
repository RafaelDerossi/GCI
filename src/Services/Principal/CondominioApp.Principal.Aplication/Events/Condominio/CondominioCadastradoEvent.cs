using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioCadastradoEvent : CondominioEvent
    {
      
        public CondominioCadastradoEvent(Guid id,
           Cnpj cnpj, string nome, string descricao, Foto logoMarca, Telefone telefone, Endereco endereo,
           int? refereciaId, string linkGeraBoleto, string boletoFolder, Url urlWebServer, bool portaria, 
           bool portariaMorador, bool classificado, bool classificadoMorador, bool mural, bool muralMorador,
           bool chat, bool chatMorador, bool reserva, bool reservaNaPortaria, bool ocorrencia, bool ocorrenciaMorador,
           bool correspondencia, bool correspondenciaNaPortaria, bool limiteTempoReserva,Guid contratoId,
           DateTime dataAssinaturaContrato, TipoDePlano tipoPlano, string descricaoContrato, bool contratoAtivo, 
           string linkDoContrato)            
        {
            CondominioId = id;       
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
            Endereco = endereo;
            RefereciaId = refereciaId;
            LinkGeraBoleto = linkGeraBoleto;
            BoletoFolder = boletoFolder;
            UrlWebServer = urlWebServer;
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
            ContratoId = contratoId;
            DataAssinatura = dataAssinaturaContrato;
            TipoPlano = tipoPlano;
            DescricaoContrato = descricaoContrato;
            ContratoAtivo = contratoAtivo;
            LinkContrato = linkDoContrato;
        }


    }
}