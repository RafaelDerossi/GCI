﻿using System;
using System.Collections.Generic;
using System.Text;
using CondominioApp.Core.DomainObjects;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class CondominioFlat : Entity, IAggregateRoot
   {
        public Guid Id { get; set; }

        public string Cnpj { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string LogoMarca { get; set; }

        public string Telefone { get; set; }

        public string logradouro { get; set; }

        public string complemento { get; set; }

        public string numero { get; set; }

        public string cep { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }
        

        /// Referencia Externa
        /// <summary>
        /// Id de referencia externa do condominio
        /// </summary>
        public int? RefereciaId { get; set; }

        public string LinkGeraBoleto { get; set; }

        public string BoletoFolder { get; set; }

        public string UrlWebServer { get; set; }
        

        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool Portaria { get; set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaMorador { get; set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool Classificado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoMorador { get; set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool Mural { get; set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralMorador { get; set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool Chat { get; set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatMorador { get; set; }

        /// <summary>
        /// Habilita/Desabilita Reserva
        /// </summary>
        public bool Reserva { get; set; }

        /// <summary>
        /// Habilita/Desabilita Reserva na Portaria
        /// </summary>
        public bool ReservaNaPortaria { get; set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia
        /// </summary>
        public bool Ocorrencia { get; set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia para o morador
        /// </summary>
        public bool OcorrenciaMorador { get; set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool Correspondencia { get; set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortaria { get; set; }

        /// <summary>
        /// Habilita/Desabilita Limite de Tempo na Reserva
        /// </summary>
        public bool LimiteTempoReserva { get; set; }

        protected CondominioFlat() { }

        public CondominioFlat(Guid id, string cnpj, string nome, string descricao, string logoMarca, 
            string telefone, string logradouro, string complemento, string numero, string cep, 
            string bairro, string cidade, string estado, int? refereciaId, string linkGeraBoleto, 
            string boletoFolder, string urlWebServer, bool portaria, bool portariaMorador, bool classificado,
            bool classificadoMorador, bool mural, bool muralMorador, bool chat, bool chatMorador, bool reserva,
            bool reservaNaPortaria, bool ocorrencia, bool ocorrenciaMorador, bool correspondencia,
            bool correspondenciaNaPortaria, bool limiteTempoReserva)
        {
            Id = id;
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
            this.logradouro = logradouro;
            this.complemento = complemento;
            this.numero = numero;
            this.cep = cep;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
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
        }
    }
}
