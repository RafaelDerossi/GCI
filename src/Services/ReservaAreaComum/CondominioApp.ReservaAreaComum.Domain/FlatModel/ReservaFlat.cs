using System;

namespace CondominioApp.ReservaAreaComum.Domain.FlatModel
{
    public class ReservaFlat
    {
        public const int Max = 200;

        public Guid Id { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDeAlteracao { get; private set; }
        public bool Lixeira { get; private set; }

        public Guid AreaComumId { get; private set; }
        public string NomeAreaComum { get; private set; }       
        public Guid CondominioId { get; private set; }
        public string NomeCondominio { get; private set; }
        public int Capacidade { get; private set; }        
        public string Observacao { get; private set; }
        public Guid UnidadeId { get; private set; }
        public string NumeroUnidade { get; private set; }
        public string AndarUnidade { get; private set; }
        public string DescricaoGrupoUnidade { get; private set; }
        public Guid UsuarioId { get; private set; }
        public string NomeUsuario { get; private set; }
        public DateTime DataDeRealizacao { get; private set; }
        public string HoraInicio { get; private set; }
        public string HoraFim { get; private set; }
        public bool Ativa { get; private set; }
        public decimal Preco { get; private set; }
        public bool EstaNaFila { get; private set; }
        public bool Cancelada { get; private set; }
        public string Justificativa { get; private set; }
        public string Origem { get; private set; }
        public bool ReservadoPelaAdministracao { get; private set; }


        protected ReservaFlat() { }

        public ReservaFlat(Guid id, Guid areaComumId,
            string nomeAreaComum, Guid condominioId, string nomeCondominio,int capacidade, string observacao,
            Guid unidadeId, string numeroUnidade, string andarUnidade, string descricaoGrupoUnidade, Guid usuarioId,
            string nomeUsuario, DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
            bool estaNaFila, string origem, bool reservadoPelaAdministracao)
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
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            DataDeRealizacao = dataDeRealizacao;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Preco = preco;
            EstaNaFila = estaNaFila;
            Origem = origem;
            ReservadoPelaAdministracao = reservadoPelaAdministracao;           
        }
             

        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetDataDeRealizacao(DateTime dataDeRealizacao) => DataDeRealizacao = dataDeRealizacao;

        public void SetHoraInicioEHoraFim(string horaInicio, string horaFim)
        {
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }

        public void Aprovar() => Ativa = true;

        public void Reprovar() => Ativa = false;

        public void SetPreco(decimal preco) => Preco = preco;

        public void EnviarParaFila() => EstaNaFila = true;

        public void RemoverDaFila() => EstaNaFila = false;

        public void Cancelar(string justificativa)
        {
            Justificativa = justificativa;
            Cancelada = true;
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
