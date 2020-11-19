using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class CondominioFlat
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


        
    }
}
