using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class AtualizaConfiguracaoCondominioViewModel
    {

        public Guid Id { get; set; }
               
        ///Parametros
        /// <summary>
        /// Habilita/Desabilita Portaria
        /// </summary>
        public bool PortariaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Portaria Para o Morador
        /// </summary>
        public bool PortariaMoradorAtivada { get; set; }

        /// <summary>
        ///  Habilita/Desabilita Classificado
        /// </summary>
        public bool ClassificadoAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Classificado para o morador
        /// </summary>
        public bool ClassificadoMoradorAtivado { get; set; }

        /// <summary>
        ///  Habilita/Desabilita Mural
        /// </summary>
        public bool MuralAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Mural para o morador
        /// </summary>
        public bool MuralMoradorAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Chat
        /// </summary>
        public bool ChatAtivado { get; set; }

        /// <summary>
        /// Habilita/Desabilita Chat para o morador
        /// </summary>
        public bool ChatMoradorAtivado { get; set; }

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
        public bool OcorrenciaMoradorAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia 
        /// </summary>
        public bool CorrespondenciaAtivada { get; set; }

        /// <summary>
        /// Habilita/Desabilita Correspondencia na Portaria
        /// </summary>
        public bool CorrespondenciaNaPortariaAtivada { get; set; }

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

    }
}
