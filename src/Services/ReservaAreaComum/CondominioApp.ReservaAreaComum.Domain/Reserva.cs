using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Reserva;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaHorariosConflitantes;
using System;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain
{
    public class Reserva : Entity, IHorario
    {
        private string CorAzul = "#3333FF";
        private string CorVerde = "#009900";
        private string CorVermelho = "#CC0000";
        private string CorAmarelo = "#FFCC00";

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

        public void SetAreaComumId(Guid id) => AreaComumId = id;

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
            if (justificativa == "")
                justificativa = "Sua reserva expirou.";
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

        public void MarcarComoCriadaPelaAdministracao() => CriadaPelaAdministracao = true;


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

        public bool EstaExpirada()
        {
            var dataHj = DataHoraDeBrasilia.Get();

            var dataFimDaRealizacao =DataDeRealizacao.Date;
            dataFimDaRealizacao.AddHours(ObterAHoraDeFimDaReserva);
            dataFimDaRealizacao.AddMinutes(ObterOMinutoDeFimDaReserva);

            if (dataFimDaRealizacao < dataHj)
                return true;

            return false;
        }


        public void EnviarPush(string nomeAreaComum, Guid condominioId)
        {
            switch (Status)
            {               
                case StatusReserva.APROVADA:
                    EnviarPushReservaAprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.REPROVADA:
                    EnviarPushReservaReprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.AGUARDANDO_APROVACAO:
                    EnviarPushReservaAguardandoAprovacao(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.NA_FILA:
                    EnviarPushReservaNaFila(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.CANCELADA:
                    EnviarPushReservaCancelada(nomeAreaComum, condominioId);
                    break;
                    
                default:
                    break;
            }
        }
        
        private void EnviarPushReservaAprovada(string nomeAreaComum, Guid condominioId)
        {          
            var titulo = "Reserva APROVADA";
            var conteudo = $"Sua solicitação de reserva para a área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi aprovada.";

            EnviarPushParaMorador(titulo, conteudo);

            if (Preco > 0)
            {
                conteudo = $"Uma reserva solicitada pelo morador {NomeMorador}, unidade {NumeroUnidade}|{AndarUnidade}|{DescricaoGrupoUnidade}, para a área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi aprovada.";
                EnviarPushParaSindico(titulo, conteudo, condominioId);
            }
                

            return;
        }

        private void EnviarPushReservaAguardandoAprovacao(string nomeAreaComum, Guid condominioId)
        {           
            var titulo = "Reserva Aguardando Aprovação";
            var conteudo = $"Sua solicitação de reserva para a área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} esta aguardando aprovação pela administração do condomínio.";

            EnviarPushParaMorador(titulo, conteudo);

            conteudo = $"Uma reserva solicitada pelo morador {NomeMorador}, unidade {NumeroUnidade}|{AndarUnidade}|{DescricaoGrupoUnidade}, para a área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} esta aguardando aprovação.";

            EnviarPushParaSindico(titulo, conteudo, condominioId);

            return;
        }

        private void EnviarPushReservaReprovada(string nomeAreaComum, Guid condominioId)
        {
            var titulo = "Reserva REPROVADA";
            var conteudo = $"Sua solicitação de reserva da área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} NÃO foi aprovada! {Justificativa}";

            EnviarPushParaMorador(titulo, conteudo);

            return;
        }

        private void EnviarPushReservaNaFila(string nomeAreaComum, Guid condominioId)
        {
            var titulo = "Reserva na FILA";
            var conteudo = $"Sua solicitação de reserva da área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi encaminhada para a fila de espera!";

            EnviarPushParaMorador(titulo, conteudo);

            if (Preco > 0)
            {
                conteudo = $"Uma reserva solicitada pelo morador {NomeMorador}, unidade {NumeroUnidade}|{AndarUnidade}|{DescricaoGrupoUnidade}, da área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi encaminhada para a fila de espera!";
                EnviarPushParaSindico(titulo, conteudo, condominioId);
            }                

            return;
        }

        private void EnviarPushReservaCancelada(string nomeAreaComum, Guid condominioId)
        {
            var titulo = "Reserva CANCELADA";
            var conteudo = $"Sua solicitação de reserva da área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi CANCELADA! {Justificativa}";

            EnviarPushParaMorador(titulo, conteudo);

            if (Preco > 0)
            {
                conteudo = $"Uma reserva solicitada pelo morador {NomeMorador}, unidade {NumeroUnidade}|{AndarUnidade}|{DescricaoGrupoUnidade}, da área comum {nomeAreaComum} para o dia: {DataDeRealizacao.ToShortDateString()}, no horário: {HoraInicio}-{HoraFim} foi CANCELADA! {Justificativa}";
                EnviarPushParaSindico(titulo, conteudo, condominioId);
            }                

            return;
        }

        public void EnviarPushReservaRetiradaDaFila(string nomeAreaComum, Guid condominioId)
        {
            switch (Status)
            {
                case StatusReserva.APROVADA:
                    EnviarPushReservaAprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.REPROVADA:
                    EnviarPushReservaReprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.AGUARDANDO_APROVACAO:
                    EnviarPushReservaAguardandoAprovacao(nomeAreaComum, condominioId);
                    break;               
             
                default:
                    break;
            }            
        }

        private void EnviarPushParaMorador(string titulo, string conteudo)
        {
            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, conteudo));
        }

        private void EnviarPushParaSindico(string titulo, string conteudo, Guid condominioId)
        {
            AdicionarEvento
                (new EnviarPushParaSindicoIntegrationEvent(condominioId, titulo, conteudo));
        }


        public void EnviarEmail(string nomeAreaComum, Guid condominioId)
        {
            switch (Status)
            {
                case StatusReserva.APROVADA:
                    EnviarEmailReservaAprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.REPROVADA:
                    EnviarEmailReservaReprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.AGUARDANDO_APROVACAO:
                    EnviarEmailReservaAguardandoAprovacao(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.NA_FILA:
                    EnviarEmailReservaNaFila(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.CANCELADA:
                    EnviarEmailReservaCancelada(nomeAreaComum, condominioId);
                    break;

                default:
                    break;
            }
        }

        private void EnviarEmailReservaAprovada(string nomeAreaComum, Guid condominioId)
        {
            var corFundoTitulo = CorVerde;
            var titulo = "Reserva APROVADA";

            EnviarEmailParaMorador(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            if (Preco>0)
                EnviarEmailParaSindico(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            return;
        }

        private void EnviarEmailReservaReprovada(string nomeAreaComum, Guid condominioId)
        {
            var corFundoTitulo = CorVermelho;
            var titulo = "Reserva REPROVADA";

            EnviarEmailParaMorador(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            if (Preco > 0)
                EnviarEmailParaSindico(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            return;
        }

        private void EnviarEmailReservaAguardandoAprovacao(string nomeAreaComum, Guid condominioId)
        {
            var corFundoTitulo = CorAzul;
            var titulo = "Reserva Aguardando Aprovação";

            EnviarEmailParaMorador(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            EnviarEmailParaSindico(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            return;
        }

        private void EnviarEmailReservaNaFila(string nomeAreaComum, Guid condominioId)
        {
            var corFundoTitulo = CorAmarelo;
            var titulo = "Reserva na FILA";

            EnviarEmailParaMorador(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            if (Preco > 0)
                EnviarEmailParaSindico(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            return;
        }

        private void EnviarEmailReservaCancelada(string nomeAreaComum, Guid condominioId)
        {
            var corFundoTitulo = CorVermelho;
            var titulo = "Reserva CANCELADA";

            EnviarEmailParaMorador(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            if (Preco > 0)
                EnviarEmailParaSindico(titulo, nomeAreaComum, condominioId, corFundoTitulo);

            return;
        }

        public void EnviarEmailReservaRetiradaDaFila(string nomeAreaComum, Guid condominioId)
        {
            switch (Status)
            {
                case StatusReserva.APROVADA:
                    EnviarEmailReservaAprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.REPROVADA:
                    EnviarEmailReservaReprovada(nomeAreaComum, condominioId);
                    break;

                case StatusReserva.AGUARDANDO_APROVACAO:
                    EnviarEmailReservaAguardandoAprovacao(nomeAreaComum, condominioId);
                    break;

                default:
                    break;
            }
        }

        
        private void EnviarEmailParaMorador(string titulo, string nomeAreaComum, Guid condominioId, string corFundoTitulo)
        {
            AdicionarEvento
           (new EnviarEmailReservaParaMoradorIntegrationEvent
           (titulo, nomeAreaComum, DataDeRealizacao.ToShortDateString(),
            HoraInicio, HoraFim, MoradorId, $"{NumeroUnidade}|{AndarUnidade}|{DescricaoGrupoUnidade}",
            Preco.ToString(), Observacao, Justificativa, DataDeCadastroFormatada, condominioId,
            UnidadeId, corFundoTitulo));
        }

        private void EnviarEmailParaSindico(string titulo, string nomeAreaComum, Guid condominioId, string corFundoTitulo)
        {
            AdicionarEvento
           (new EnviarEmailReservaParaSindicoIntegrationEvent
           (titulo, nomeAreaComum, DataDeRealizacao.ToShortDateString(),
            HoraInicio, HoraFim, MoradorId, $"{NumeroUnidade}|{AndarUnidade}|{DescricaoGrupoUnidade}",
            Preco.ToString(), Observacao, Justificativa, DataDeCadastroFormatada, condominioId,
            UnidadeId, corFundoTitulo));
        }
    }
}
