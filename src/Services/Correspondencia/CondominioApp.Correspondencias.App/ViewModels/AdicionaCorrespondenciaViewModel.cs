using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class AdicionaCorrespondenciaViewModel
    {
        /// <summary>
        /// Data em que a correspondência chegou
        /// </summary>
        public DateTime DataDeChegada { get; set; }

        /// <summary>
        /// Id(Guid) da unidade da correspondência
        /// </summary>
        public Guid UnidadeId { get; set; }        

        /// <summary>
        /// Id(Guid) do funcionário que cadastrou a correspondência
        /// </summary>
        public Guid FuncionarioId { get; set; }        

        /// <summary>
        /// Observações sobre a chegada da correspôndencia
        /// </summary>
        public string Observacao { get; set; }

        /// <summary>
        /// Arquivo da foto da correspondência
        /// </summary>
        public IFormFile ArquivoFotoCorrespondencia { get;  set; }

        /// <summary>
        /// Número de rastreamento da correspondência nos Correios ou transportadora
        /// </summary>
        public string NumeroRastreamentoCorreio { get; set; }        

        /// <summary>
        /// Tipo da correspondência, ex: "Caixa", "Pacote", "Mercado Livre", "Amazon"
        /// </summary>
        public string TipoDeCorrespondencia { get; set; }

        /// <summary>
        /// Localização da correspondência para retirada
        /// </summary>
        public string Localizacao { get; set; }

        /// <summary>
        /// Informa se envia notificação sobre a correspôndencia ao morador ou não
        /// </summary>
        public bool EnviarNotificacao { get; set; }

    }
}