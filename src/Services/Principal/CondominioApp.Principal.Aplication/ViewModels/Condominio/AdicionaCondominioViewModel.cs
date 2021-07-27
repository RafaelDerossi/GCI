using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class AdicionaCondominioViewModel
    {
        public string Cnpj { get; set; }       

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public IFormFile ArquivoLogo { get; set; }        

        public string Telefone { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        
        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool PortariaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaParaMoradorAtivada { get; set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool ClassificadoAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoParaMoradorAtivado { get; set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool MuralAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralParaMoradorAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool ChatAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatParaMoradorAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Reserva
        /// </summary>
        public bool ReservaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Reserva na Portaria
        /// </summary>
        public bool ReservaNaPortariaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia
        /// </summary>
        public bool OcorrenciaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Ocorrencia para o morador
        /// </summary>
        public bool OcorrenciaParaMoradorAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool CorrespondenciaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortariaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Limite de Tempo na Reserva
        /// </summary>
        public bool CadastroDeVeiculoPeloMoradorAtivado { get; set; }


        /// <summary>
        /// Habilita/Desabilita a criação de enquetes
        /// </summary>
        public bool EnqueteAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita o Controle de Acesso
        /// </summary>
        public bool ControleDeAcessoAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita a gestão de tarefas
        /// </summary>
        public bool TarefaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita a gestão de orçamentos
        /// </summary>
        public bool OrcamentoAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita a automação
        /// </summary>
        public bool AutomacaoAtivada { get; set; }


        public DateTime DataAssinaturaContrato { get; set; }

        public TipoDePlano TipoDePlano { get; set; }

        public string DescricaoContrato { get; set; }

        public bool ContratoAtivo { get; set; }

        public int QuantidadeDeUnidadesContratada { get; set; }

        public IFormFile ArquivoContrato { get; set; }
       
    }
}
