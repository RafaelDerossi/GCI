using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.FlatModel
{
    public class HistoricoReservaFlat
    {
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public Guid ReservaId { get; private set; }

        public AcoesReserva Acao { get; private set; }

        public Guid AutorId { get; private set; }

        public string NomeAutorAcao { get; private set; }

        public TipoDoAutor TipoDoAutor { get; private set; }  

        public string Origem { get; private set; }


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
