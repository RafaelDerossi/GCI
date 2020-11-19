using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using System;


namespace CondominioApp.Principal.Aplication.Commands
{
    public abstract class CondominioCommand : Command
    {
        public Guid CondominioId { get; protected set; }

        public string Cnpj { get; protected set; }      

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public string LogoMarca { get; protected set; }

        public string NomeOriginal { get; protected set; }

        public string Telefone { get; protected set; }

        public string Logradouro { get; protected set; }

        public string Complemento { get; protected set; }

        public string Numero { get; protected set; }

        public string Cep { get; protected set; }

        public string Bairro { get; protected set; }

        public string Cidade { get; protected set; }

        public string Estado { get; protected set; }

        /// Referencia Externa
        /// <summary>
        /// Id de referencia externa do condominio
        /// </summary>
        public int? RefereciaId { get; protected set; }

        public string LinkGeraBoleto { get; protected set; }

        public string BoletoFolder { get; protected set; }

        public string UrlWebServer { get; protected set; }



        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool Portaria { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaMorador { get; protected set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool Classificado { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoMorador { get; protected set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool Mural { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralMorador { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool Chat { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatMorador { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Reserva
        /// </summary>
        public bool Reserva { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Reserva na Portaria
        /// </summary>
        public bool ReservaNaPortaria { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia
        /// </summary>
        public bool Ocorrencia { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia para o morador
        /// </summary>
        public bool OcorrenciaMorador { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool Correspondencia { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortaria { get; protected set; }

        /// <summary>
        /// Habilita/Desabilita Limite de Tempo na Reserva
        /// </summary>
        public bool LimiteTempoReserva { get; protected set; }       

    }
}
