using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class HistoricoCorrespondenciaViewModel
    {
        /// <summary>
        /// Historico Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id(Guid) da correspondência
        /// </summary>
        public Guid CorrespondenciaId { get; set; }

        /// <summary>
        /// Data de cadastro da correspondência
        /// </summary>
        public string DataDeCadastro { get; set; }

        /// <summary>
        /// Data de alteração da correspondência
        /// </summary>
        public string DataDeAlteracao { get; set; }

        /// <summary>
        /// Enum Ação: CADASTRO = 0, NOTIFICACAO = 1, RETIRADA = 2, DEVOLUCAO = 3, EXCLUSAO = 4
        /// </summary>
        public AcoesCorrespondencia Acao { get; set; }

        /// <summary>
        /// Descrição da Ação
        /// </summary>
        public string DescricaoDaAcao 
        { 
            get 
            {
                return Acao switch
                {
                    AcoesCorrespondencia.CADASTRO => "Cadastro",
                    AcoesCorrespondencia.NOTIFICACAO => "Notificação",
                    AcoesCorrespondencia.RETIRADA => "Retirada",
                    AcoesCorrespondencia.DEVOLUCAO => "Devolução",
                    AcoesCorrespondencia.EXCLUSAO => "Exclusão",
                    _ => "Indefinido",
                };
            }
        }

        /// <summary>
        /// Id(Guid) do funcionario envolvido na ação
        /// </summary>
        public Guid FuncionarioId { get; private set; }

        /// <summary>
        /// Nome do funcionario envolvido na ação
        /// </summary>
        public string NomeFuncionario { get; private set; }

        /// <summary>
        /// Informa se a corrêspondecia ja foi vista pelo morador
        /// </summary>
        public bool Visto { get; set; }        

    }
}
