using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Automacao.ViewModel
{
   public class DispositivoViewModel
    {
        /// <summary>
        /// Id do dispositivo
        /// </summary>
        public string DispositivoId { get; set; }        

        /// <summary>
        /// Nome do dispositivo
        /// </summary>
        public string Nome { get; set; }        

        /// <summary>
        /// Informa de o dispositivo esta online(Ewelink)
        /// </summary>
        public bool Online { get; set; }        

        /// <summary>
        /// Informa a hora em que o dispositivo ficou online pela última vez (Ewelink)
        /// </summary>
        public string OnlineHora { get; set; }

        /// <summary>
        /// Data de criação do dispositivo
        /// </summary>
        public string DataDeCriacao { get; set; }

        /// <summary>
        /// Ip do dispositivo (Ewelink)
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Informa a hora em que o dispositivo ficou offline pela última vez (Ewelink)
        /// </summary>
        public string OfflineHora { get; set; }

        /// <summary>
        /// Informa se o dispositivo esta ligado(on) ou desligado(off)
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Informa a marca do dispositivo (Ewelink)
        /// </summary>
        public string NomeDaMarca { get; set; }

        /// <summary>
        /// Informa o modelo do dispositivo (Ewelink)
        /// </summary>
        public string ModeloDoProduto { get; set; }

        /// <summary>
        /// Informa se o modo pulse do dispositivo esta ligado(on) ou desligado(off)
        /// </summary>
        public string Pulse {get; set; }

        /// <summary>
        /// Tempo em milisegundos do pulse
        /// </summary>
        public string PulseWidth { get; set; }

        /// <summary>
        /// Tipo da Automacao (Ewelink = 1, Webhook = 2)
        /// </summary>
        public TipoApiAutomacao TipoAutomacao { get; set; }
    }
}
