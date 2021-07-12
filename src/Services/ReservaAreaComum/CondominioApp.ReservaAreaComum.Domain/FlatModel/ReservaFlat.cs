﻿using CondominioApp.Core.Enumeradores;
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

        public Guid MoradorId { get; private set; }

        public string NomeMorador { get; private set; }

        public DateTime DataDeRealizacao { get; private set; }

        public string HoraInicio { get; private set; }

        public string HoraFim { get; private set; }        

        public decimal Preco { get; private set; }

        public StatusReserva Status { get; private set; }        

        public string Justificativa { get; private set; }

        public string Origem { get; private set; }

        public bool CriadaPelaAdministracao { get; private set; }

        public bool ReservadoPelaAdministracao { get; private set; }
        
        public string StatusDescricao { get; private set; }

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
