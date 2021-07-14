using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.FlatModel
{
    public class HistoricoReservaFlat
    {
        /// <summary>
        /// Id(Guid) do registro de histórico
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Data do registro
        /// </summary>
        public DateTime DataDeCadastro { get; private set; }
        
        /// <summary>
        /// Data de alteração do registro
        /// </summary>
        public DateTime DataDeAlteracao { get; private set; }
        
        /// <summary>
        /// Informa de o registro esta na lixeira
        /// </summary>
        public bool Lixeira { get; private set; }

        /// <summary>
        /// Id(Guid) da reserva a qual o registro se refere
        /// </summary>
        public Guid ReservaId { get; private set; }

        /// <summary>
        /// Enum da ação realiza. (SOLICITADA = 0, APROVADA = 1, REPROVADA = 2,
        ///                        AGUARDAR_APROVACAO = 3, ENVIADA_PARA_FILA = 4,
        ///                        RETIRADA_DA_FILA = 5, CANCELADA = 6, 
        ///                        EXPIRADA = 7, REMOVIDA = 8)
        /// </summary>
        public AcoesReserva Acao { get; private set; }

        /// <summary>
        /// Id(Guid) do autor da ação
        /// </summary>
        public Guid AutorId { get; private set; }

        /// <summary>
        /// nome do autor da ação
        /// </summary>
        public string NomeAutorAcao { get; private set; }

        /// <summary>
        /// Enum do tipo do autor da ação. (ADMINISTRACAO = 1, MORADOR = 2, SISTEMA = 3)
        /// </summary>
        public TipoDoAutor TipoDoAutor { get; private set; }  

        /// <summary>
        /// Origem da ação (Modelo do dispositivo/Sistema Web)
        /// </summary>
        public string Origem { get; private set; }

        /// <summary>
        /// Descrição da Ação
        /// </summary>
        public string DescricaoDaAcao
        {
            get
            {
                return Acao switch
                {
                    AcoesReserva.SOLICITADA => "Solicitada",
                    AcoesReserva.APROVADA => "Aprovada",
                    AcoesReserva.REPROVADA => "Reprovada",
                    AcoesReserva.AGUARDAR_APROVACAO => "Aguardar Aprovação",
                    AcoesReserva.ENVIADA_PARA_FILA => "Enviada para Fila",
                    AcoesReserva.RETIRADA_DA_FILA => "Retirada da FIla",
                    AcoesReserva.CANCELADA => "Cancelada",
                    AcoesReserva.EXPIRADA => "Expirada",
                    AcoesReserva.REMOVIDA => "Removida",
                    _ => "Indefinido",
                };
            }
        }

        /// <summary>
        /// Descrição do tipo do autor
        /// </summary>
        public string DescricaoTipoDoAutor
        {
            get
            {
                return TipoDoAutor switch
                {
                    TipoDoAutor.ADMINISTRACAO => "Administração",
                    TipoDoAutor.MORADOR => "Morador",
                    TipoDoAutor.SISTEMA => "Sistema",
                    _ => "Indefinido",
                };
            }
        }


        public HistoricoReservaFlat()
        {
        }

        public HistoricoReservaFlat
            (Guid reservaId, AcoesReserva acao, Guid autorId, string nomeAutorAcao,
             TipoDoAutor tipoDoAutor, string origem)
        {
            ReservaId = reservaId;
            Acao = acao;
            AutorId = autorId;
            NomeAutorAcao = nomeAutorAcao;
            TipoDoAutor = tipoDoAutor;
            Origem = origem;
        }

        public void SetEntidadeId(Guid NovoId) => Id = NovoId;
        public void EnviarParaLixeira() => Lixeira = true;
        public void RestaurarDaLixeira() => Lixeira = false;


        public void SetReservaId(Guid id) => ReservaId = id;

        public void SetAcao(AcoesReserva acao) => Acao = acao;

        public void SetAutor(Guid moradorIdFuncionarioId, string nomeAutorAcao, TipoDoAutor tipoDoAutor)
        {
            AutorId = moradorIdFuncionarioId;
            NomeAutorAcao = nomeAutorAcao;
            TipoDoAutor = tipoDoAutor;
        }

        public void SetOrigem(string origem) => Origem = origem;


    }
}
