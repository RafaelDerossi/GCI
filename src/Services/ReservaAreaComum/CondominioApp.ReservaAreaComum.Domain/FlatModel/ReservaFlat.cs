using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.FlatModel
{
    public class ReservaFlat
    {
        public const int Max = 200;

        /// <summary>
        /// Id(Guid) da reserva
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Data da solicitação da reserva
        /// </summary>
        public DateTime DataDeCadastro { get; private set; }

        /// <summary>
        /// Data de alteração da reserva
        /// </summary>
        public DateTime DataDeAlteracao { get; private set; }

        /// <summary>
        /// Informa se a reserva esta na lixeira
        /// </summary>
        public bool Lixeira { get; private set; }

        /// <summary>
        /// Id(Guid) da área comum para qual a reserva foi solicitada
        /// </summary>
        public Guid AreaComumId { get; private set; }

        /// <summary>
        /// Nome da área comum para qual a reserva foi solicitada
        /// </summary>
        public string NomeAreaComum { get; private set; }

        /// <summary>
        /// Id(Guid) do Condomínio ao qual a área comum pertence
        /// </summary>
        public Guid CondominioId { get; private set; }

        /// <summary>
        /// Nome do Condomínio ao qual a área comum pertence
        /// </summary>
        public string NomeCondominio { get; private set; }

        /// <summary>
        /// Capacidade da área comum para qual a reserva foi solicitada
        /// </summary>
        public int Capacidade { get; private set; }        

        /// <summary>
        /// Observações sobre a reserva
        /// </summary>
        public string Observacao { get; private set; }

        /// <summary>
        /// Id(Guid) da unidade a qual o solicitante da reserva pertence
        /// </summary>
        public Guid UnidadeId { get; private set; }

        /// <summary>
        /// Número da unidade a qual o solicitante da reserva pertence
        /// </summary>
        public string NumeroUnidade { get; private set; }

        /// <summary>
        /// Andar da unidade a qual o solicitante da reserva pertence
        /// </summary>
        public string AndarUnidade { get; private set; }

        /// <summary>
        /// Grupo da unidade a qual o solicitante da reserva pertence
        /// </summary>
        public string DescricaoGrupoUnidade { get; private set; }

        /// <summary>
        /// Id(Guid) do morador que solicitou a reserva
        /// </summary>
        public Guid MoradorId { get; private set; }

        /// <summary>
        /// Nome do morador que solicitou a reserva
        /// </summary>
        public string NomeMorador { get; private set; }

        /// <summary>
        /// Data para a qual a reserva foi solicitada
        /// </summary>
        public DateTime DataDeRealizacao { get; private set; }

        /// <summary>
        /// Horário de inicio da reserva
        /// </summary>
        public string HoraInicio { get; private set; }

        /// <summary>
        /// Horário de término da reserva
        /// </summary>
        public string HoraFim { get; private set; }        

        /// <summary>
        /// Valor de custo da reserva para o solicitante
        /// </summary>
        public decimal Preco { get; private set; }

        /// <summary>
        /// Situação da reserva: 
        /// Enum (PROCESSANDO = 0, APROVADA = 1, REPROVADA = 2,
        ///       AGUARDANDO_APROVACAO = 3, NA_FILA = 4,  CANCELADA = 5,
        ///       EXPIRADA = 6, REMOVIDA = 7)
        /// </summary>
        public StatusReserva Status { get; private set; }        

        /// <summary>
        /// Justificativa para a situação da reserva
        /// </summary>
        public string Justificativa { get; private set; }

        /// <summary>
        /// Origem da solicitação da reserva (Modelo do dispositivo/Sistema WEB)
        /// </summary>
        public string Origem { get; private set; }

        /// <summary>
        /// Informa se a reserva foi criada para a administração.
        /// </summary>
        public bool CriadaPelaAdministracao { get; private set; }

        /// <summary>
        /// Informa de a reserva foi gerada pela administração em nome de um morador
        /// </summary>
        public bool ReservadoPelaAdministracao { get; private set; }
        
        /// <summary>
        /// Descrição da situação da reserva
        /// </summary>
        public string StatusDescricao { get; private set; }

        /// <summary>
        /// Protocolo da reserva (Gerado automáticamente)
        /// </summary>
        public string Protocolo { get; private set; }

        protected ReservaFlat() { }

        public ReservaFlat(Guid id, Guid areaComumId,
            string nomeAreaComum, Guid condominioId, string nomeCondominio,int capacidade, string observacao,
            Guid unidadeId, string numeroUnidade, string andarUnidade, string descricaoGrupoUnidade, Guid moradorId,
            string nomeMorador, DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
            StatusReserva status, string justificatica, string origem, bool criadaPelaAdministracao,
            bool reservadoPelaAdministracao, string protocolo)
        {
            Id = id;           
            AreaComumId = areaComumId;
            NomeAreaComum = nomeAreaComum;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Capacidade = capacidade;
            Observacao = observacao;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            DescricaoGrupoUnidade = descricaoGrupoUnidade;
            MoradorId = moradorId;
            NomeMorador = nomeMorador;
            DataDeRealizacao = dataDeRealizacao;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Preco = preco;
            Status = status;
            Justificativa = justificatica;
            Origem = origem;
            CriadaPelaAdministracao = criadaPelaAdministracao;
            ReservadoPelaAdministracao = reservadoPelaAdministracao;
            StatusDescricao = ObterStatusDescricao();
            Protocolo = protocolo;
        }

        public string ObterStatusDescricao()
        {
            return Status switch
            {
                StatusReserva.PROCESSANDO => "PROCESSANDO",
                StatusReserva.APROVADA => "APROVADA",
                StatusReserva.REPROVADA => "REPROVADA",
                StatusReserva.AGUARDANDO_APROVACAO => "AGUARDANDO APROVAÇÃO",
                StatusReserva.NA_FILA => "FILA DE ESPERA",
                StatusReserva.CANCELADA => "CANCELADA",
                StatusReserva.EXPIRADA => "EXPIRADA",
                StatusReserva.REMOVIDA => "REMOVIDA",
                _ => "INDEFINIDO",
            };
        }



        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetDataDeRealizacao(DateTime dataDeRealizacao) => DataDeRealizacao = dataDeRealizacao;

        public void SetHoraInicioEHoraFim(string horaInicio, string horaFim)
        {
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }       

        public void SetPreco(decimal preco) => Preco = preco;

        public void SetStatus(StatusReserva status, string justificativa)
        {
            Status = status;
            Justificativa = justificativa;
            StatusDescricao = ObterStatusDescricao();
        }

        public void ColocarEmProcessamento()
        {
            Status = StatusReserva.PROCESSANDO;
            Justificativa = "Sua solicitação de reserva esta sendo processada.";
        }

        public void Aprovar(string justificativa)
        {
            Status = StatusReserva.APROVADA;
            Justificativa = justificativa;
        }

        public void Reprovar(string justificativa)
        {
            Status = StatusReserva.REPROVADA;
            Justificativa = justificativa;
        }

        public void EnviarParaFila(string justificativa)
        {
            Status = StatusReserva.NA_FILA;
            Justificativa = justificativa;
        }

        public void Cancelar(string justificativa)
        {
            Status = StatusReserva.CANCELADA;
            Justificativa = justificativa;
        }

        public void AguardarAprovacao(string justificativa)
        {
            Status = StatusReserva.AGUARDANDO_APROVACAO;
            Justificativa = justificativa;
        }

        public void MarcarComoExpirada(string justificativa)
        {
            Status = StatusReserva.EXPIRADA;
            Justificativa = justificativa;
        }

        public void Remover(string justificativa)
        {
            Status = StatusReserva.REMOVIDA;
            Justificativa = justificativa;
        }



        public void SetOrigem(string origem) => Origem = origem;

        public void SetUnidade(Guid unidadeId, string numeroUnidade, string andarUnidade, string descricaoGrupoUnidade)
        {
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            DescricaoGrupoUnidade = descricaoGrupoUnidade;
        }

        public void SetEntidadeId(Guid NovoId) => Id = NovoId;

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public int ObterHoraInicio
        {
            get
            {
                if (!string.IsNullOrEmpty(HoraInicio))
                    return Convert.ToInt32(HoraInicio.Replace(":", ""));

                return 0;
            }
        }

        public int ObterHoraFim
        {
            get
            {
                if (!string.IsNullOrEmpty(HoraFim))
                    return Convert.ToInt32(HoraFim.Replace(":", ""));

                return 0;
            }
        }        

    }
}
