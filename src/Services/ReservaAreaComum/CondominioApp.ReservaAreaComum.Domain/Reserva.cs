using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain
{
   public class Reserva : Entity, IHorario
    {
        public Guid AreaComumId { get; private set; }

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

        public string StatusDescricao
        {
            get
            {
                switch (Status)
                {
                    case StatusReserva.PROCESSANDO:
                        return "PROCESSANDO";

                    case StatusReserva.APROVADA:
                        return "APROVADA";

                    case StatusReserva.REPROVADA:
                        return "REPROVADA";

                    case StatusReserva.AGUARDANDO_APROVACAO:
                        return "AGUARDANDO APROVAÇÃO";

                    case StatusReserva.NA_FILA:
                        return "FILA DE ESPERA";

                    case StatusReserva.CANCELADA:
                        return "CANCELADA";

                    case StatusReserva.EXPIRADA:
                        return "EXPIRADA";

                    case StatusReserva.REMOVIDA:
                        return "REMOVIDA";

                    default:
                        return "INDEFINIDO";
                }                                  

            }
        }

        protected Reserva() { }

        public Reserva(Guid areaComumId, string observacao, Guid unidadeId, string numeroUnidade, 
            string andarUnidade, string descricaoGrupoUnidade, Guid moradorId, string nomeMorador,
            DateTime dataDeRealizacao, string horaInicio, string horaFim, decimal preco,
            string origem, bool criadaPelaAdministracao, bool reservadoPelaAdministracao)
        {
            AreaComumId = areaComumId;
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
            Origem = origem;
            CriadaPelaAdministracao = criadaPelaAdministracao;
            ReservadoPelaAdministracao = reservadoPelaAdministracao;
        }


        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetDataDeRealizacao(DateTime dataDeRealizacao) => DataDeRealizacao = dataDeRealizacao;
        
        public void SetHoraInicioEHoraFim(string horaInicio, string horaFim)
        {
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }

        public void SetPreco(decimal preco) => Preco = preco;

        public void ColocarEmProcessamento()
        {
            Status = StatusReserva.PROCESSANDO;
            Justificativa = "Sua solicitação de reserva esta sendo processada.";
        }

        public void Aprovar(string justificativa)
        {
            Status = StatusReserva.APROVADA;
            if (justificativa == "")
                justificativa = "Sua reserva foi aprovada.";
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
            if (justificativa == "")
                justificativa = "Sua reserva está aguardando ser aprovada pela administração do condomínio.";
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

        public void SetUnidade(Guid unidadeId,string numeroUnidade,string andarUnidade, string descricaoGrupoUnidade)
        {
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            DescricaoGrupoUnidade = descricaoGrupoUnidade;
        }

        public void SetMorador(Guid id, string nome)
        {
            MoradorId = id;
            NomeMorador = nome;            
        }


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

                

        public DateTime ObterDataHoraInicioDaRealizacao()
        {
            return DataDeRealizacao
                   .AddHours(ObterAHoraDeInicioDaReserva)
                   .AddMinutes(ObterOMinutoDeInicioDaReserva);
        }

        public DateTime ObterDataHoraFimDaRealizacao()
        {
            return DataDeRealizacao
                   .AddHours(ObterAHoraDeFimDaReserva)
                   .AddMinutes(ObterOMinutoDeFimDaReserva);
        }

        private int ObterAHoraDeInicioDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraInicio))
                    return 0;

                string[] array = HoraInicio.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[0]);

                return 0;
            }
        }
        private int ObterOMinutoDeInicioDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraInicio))
                    return 0;

                string[] array = HoraInicio.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[1]);

                return 0;
            }
        }
        private int ObterAHoraDeFimDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraFim))
                    return 0;

                string[] array = HoraFim.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[0]);

                return 0;
            }
        }
        private int ObterOMinutoDeFimDaReserva
        {
            get
            {
                if (string.IsNullOrEmpty(HoraFim))
                    return 0;

                string[] array = HoraFim.Split(':');
                if (array.Count() > 1)
                    return int.Parse(array[1]);

                return 0;
            }
        }



        public void EnviarPushReservaAprovada(string nomeAreaComum)
        {
            var titulo = "Reserva APROVADA";
            var conteudo = $"Sua solicitação de reserva da(o) {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi aprovada.";
            
            AdicionarEvento
            (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, conteudo));

            return;
        }

        public void EnviarPushReservaAguardandoAprovacao(string nomeAreaComum)
        {
            var titulo = "Reserva Aguardando Aprovação";
            var conteudo = $"Sua solicitação de reserva da(o) {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} esta aguardando aprovação pela administração do condomínio.";

            AdicionarEvento
            (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, conteudo));

            return;
        }

        public void EnviarPushReservaReprovada(string nomeAreaComum)
        {
            var titulo = "Reserva REPROVADA";
            var conteudo = $"Sua solicitação de reserva da(o) {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} NÃO foi aprovada! {Justificativa}";

            AdicionarEvento
            (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, conteudo));

            return;
        }

        public void EnviarPushReservaNaFila(string nomeAreaComum)
        {
            var titulo = "Reserva na FILA";
            var conteudo = $"Sua solicitação de reserva da(o) {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi encaminhada para a fila de espera!";

            AdicionarEvento
            (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, conteudo));

            return;
        }

        public void EnviarPushReservaCancelada(string nomeAreaComum)
        {
            var titulo = "Reserva CANCELADA";
            var conteudo = $"Sua solicitação de reserva da(o) {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi CANCELADA! {Justificativa}";

            AdicionarEvento
            (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, conteudo));

            return;
        }

        public void EnviarPushReservaRetiradaDaFila(string nomeAreaComum)
        {
            switch (Status)
            {
                case StatusReserva.APROVADA:
                    EnviarPushReservaAprovada(nomeAreaComum);
                    break;

                case StatusReserva.REPROVADA:
                    EnviarPushReservaReprovada(nomeAreaComum);
                    break;

                case StatusReserva.AGUARDANDO_APROVACAO:
                    EnviarPushReservaAguardandoAprovacao(nomeAreaComum);
                    break;               
             
                default:
                    break;
            }            
        }
    }
}
