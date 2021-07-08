using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class CorrespondenciaViewModel
    {
        /// <summary>
        /// Id(Guid) da correspondência
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data de cadastro da correspondência
        /// </summary>
        public string DataDeCadastro { get; set; }

        /// <summary>
        /// Data de alteração da correspondência
        /// </summary>
        public string DataDeAlteracao { get; set; }

        /// <summary>
        /// Id(Guid) do condomínio da correspondência
        /// </summary>
        public Guid CondominioId { get; set; }

        /// <summary>
        /// Id(Guid) da unidade da correspondência
        /// </summary>
        public Guid UnidadeId { get; set; }

        /// <summary>
        /// Numero da unidade da correspondência
        /// </summary>
        public string NumeroUnidade { get; set; }

        /// <summary>
        /// Bloco da unidade da correspondência
        /// </summary>
        public string Bloco { get; set; }

        /// <summary>
        /// Informa se o aviso de corrêspondecia ja foi visto pelo morador
        /// </summary>
        public bool Visto { get; set; }
        
        public string Observacao { get; set; }       

        /// <summary>
        /// Id(Guid) do funcionário que cadastrou a correspondência ou que a entregou
        /// </summary>
        public Guid FuncionarioId { get; set; }

        /// <summary>
        /// Nome do funcionário que cadastrou a correspondência ou que a entregou
        /// </summary>
        public string NomeFuncionario { get; set; }

        /// <summary>
        /// Nome do arquivo da foto da correspondência
        /// </summary>
        public string NomeArquivoFoto { get;  set; }

        /// <summary>
        /// Nome original do arquivo da foto da correspondência
        /// </summary>
        public string NomeOriginalFoto { get; set; }

        /// <summary>
        /// Número de rastreamento da correspondência nos Correios ou transportadora
        /// </summary>
        public string NumeroRastreamentoCorreio { get; set; }

        /// <summary>
        /// Data em que a correspondência chegou
        /// </summary>
        public string DataDeChegada { get; set; }

        /// <summary>
        /// Quantidade de alertas enviados ao morador
        /// </summary>
        public int QuantidadeDeAlertasFeitos { get; set; }

        /// <summary>
        /// Tipo da correspondência, ex: "Caixa", "Pacote", "Mercado Livre", "Amazon"
        /// </summary>
        public string TipoDeCorrespondencia { get; set; }

        /// <summary>
        /// Status da correspondência (Pendente, Retirado, Devolvido)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Nome do Morador que retirou a correspondência
        /// </summary>
        public string NomeRetirante { get; set; }

        /// <summary>
        /// Nome do arquivo da foto do retirante
        /// </summary>
        public string NomeArquivoFotoRetirante { get; set; }

        /// <summary>
        /// Nome original do arquivo da foto do retirante
        /// </summary>
        public string NomeOriginalFotoRetirante { get; set; }

        /// <summary>
        /// Data em que a correspondência foir entreque
        /// </summary>
        public string DataDaRetirada { get; private set; }

        /// <summary>
        /// Localização da correspondência para retirada
        /// </summary>
        public string Localizacao { get; set; }       

        /// <summary>
        /// Informa se envia notificação sobre a correspôndencia ao morador ou não
        /// </summary>
        public bool EnviarNotificacao { get; set; }

        public bool Lixeira { get; set; }

    }
}
