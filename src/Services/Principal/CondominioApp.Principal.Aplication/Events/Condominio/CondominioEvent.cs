using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioEvent : Event
    {
        public Guid CondominioId { get; protected set; }  

        public Cnpj Cnpj { get; protected set; }

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public Foto LogoMarca { get; protected set; }

        public Telefone Telefone { get; protected set; }

        public Endereco Endereco { get; protected set; }


       
        public int? RefereciaId { get; protected set; }

        public string LinkGeraBoleto { get; protected set; }

        public string BoletoFolder { get; protected set; }

        public Url UrlWebServer { get; protected set; }


      
        public bool Portaria { get; protected set; }

        public bool PortariaMorador { get; protected set; }

        public bool Classificado { get; protected set; }
     
        public bool ClassificadoMorador { get; protected set; }
       
        public bool Mural { get; protected set; }

        public bool MuralMorador { get; protected set; }

        public bool Chat { get; protected set; }

        public bool ChatMorador { get; protected set; }

        public bool Reserva { get; protected set; }

        public bool ReservaNaPortaria { get; protected set; }

        public bool Ocorrencia { get; protected set; }

        public bool OcorrenciaMorador { get; protected set; }

        public bool Correspondencia { get; protected set; }

        public bool CorrespondenciaNaPortaria { get; protected set; }

        public bool LimiteTempoReserva { get; protected set; }


        public Guid ContratoId { get; protected set; }

        public DateTime DataAssinatura { get; protected set; }

        public TipoDePlano TipoPlano { get; protected set; }       

        public string DescricaoContrato { get; protected set; }

        public bool ContratoAtivo { get; protected set; }

        public string LinkContrato { get; protected set; }

    }
}