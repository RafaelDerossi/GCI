using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using MediatR;


namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class ReservaEventHandler : EventHandler,
        INotificationHandler<ReservaCadastradaEvent>,
        INotificationHandler<ReservaAprovadaEvent>,
        INotificationHandler<ReservaAprovadaPelaAdministracaoEvent>,        
        System.IDisposable
    {
       
        private readonly IReservaAreaComumRepository _reservaAreaComumRepository;
        private readonly IReservaAreaComumQueryRepository _reservaAreaComumQueryRepository;

        public ReservaEventHandler(
            IReservaAreaComumRepository reservaAreaComumRepository,
            IReservaAreaComumQueryRepository reservaAreaComumQueryRepository)
        {
            _reservaAreaComumRepository = reservaAreaComumRepository;
            _reservaAreaComumQueryRepository = reservaAreaComumQueryRepository;          
        }


        public async Task Handle(ReservaCadastradaEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = new ReservaFlat
                (notification.Id,
                notification.AreaComumId, notification.NomeAreaComum, notification.CondominioId,
                notification.NomeCondominio, notification.Capacidade, notification.Observacao,
                notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade,
                notification.DescricaoGrupoUnidade, notification.MoradorId, notification.NomeMorador,
                notification.DataDeRealizacao, notification.HoraInicio, notification.HoraFim,
                notification.Preco, notification.Status, notification.Justificativa, notification.Origem,
                notification.CriadaPelaAdministracao, notification.ReservadoPelaAdministracao);

            _reservaAreaComumQueryRepository.AdicionarReserva(reservaFlat);

            var historico = HistoricoReservaSolicitadaFactory(notification);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }
        private HistoricoReservaFlat HistoricoReservaSolicitadaFactory(ReservaCadastradaEvent notification)
        {
            if (notification.CriadaPelaAdministracao)
                return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, notification.FuncionarioId, notification.NomeFuncionario,
                 TipoDoAutor.ADMINISTRACAO, notification.Origem);

            return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, notification.MoradorId, notification.NomeMorador,
                 TipoDoAutor.MORADOR, notification.Origem);

        }


        public async Task Handle(ReservaAprovadaEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.APROVADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaAprovadaFactory(notification);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }
        private HistoricoReservaFlat HistoricoReservaAprovadaFactory(ReservaAprovadaEvent notification)
        {
            return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.APROVADA, System.Guid.Empty, "Ação Automática",
                 TipoDoAutor.SISTEMA, "Sistema");
        }


        public async Task Handle(ReservaAprovadaPelaAdministracaoEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.APROVADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaAprovadaPelaAdmFactory(notification);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }
        private HistoricoReservaFlat HistoricoReservaAprovadaPelaAdmFactory(ReservaAprovadaPelaAdministracaoEvent notification)
        {
            return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.APROVADA, notification.FuncionarioId, notification.NomeFuncionario,
                 TipoDoAutor.SISTEMA, notification.Origem);
        }


        public async Task Handle(ReservaEnviadaParaAguardarAprovacaoEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.AGUARDANDO_APROVACAO, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaEnviadaParaAguardarAprovacaoFactory(notification);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }
        private HistoricoReservaFlat HistoricoReservaEnviadaParaAguardarAprovacaoFactory(ReservaEnviadaParaAguardarAprovacaoEvent notification)
        {
            return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.AGUARDAR_APROVACAO, notification.FuncionarioId, notification.NomeFuncionario,
                 TipoDoAutor.SISTEMA, notification.Origem);
        }



        private HistoricoReservaFlat HistoricoReservaAprovadaFactory(StatusDaReservaAlteradoEvent notification)
        {
            if (notification.CriadaPelaAdministracao)
                return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, System.Guid.Empty, "Administração",
                 TipoDoAutor.ADMINISTRACAO, notification.Origem);

            return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, notification.MoradorId, notification.NomeMorador,
                 TipoDoAutor.MORADOR, notification.Origem);

        }

        private HistoricoReservaFlat HistoricoReservaReprovadaFactory(StatusDaReservaAlteradoEvent notification)
        {
            switch (notification.Status)
            {
                case StatusReserva.PROCESSANDO:
                    break;
                case StatusReserva.APROVADA:
                    break;
                case StatusReserva.REPROVADA:
                    break;
                case StatusReserva.AGUARDANDO_APROVACAO:
                    break;
                case StatusReserva.NA_FILA:
                    break;
                case StatusReserva.CANCELADA:
                    break;
                case StatusReserva.EXPIRADA:
                    break;
                case StatusReserva.REMOVIDA:
                    break;
                default:
                    break;
            }

            if (notification.CriadaPelaAdministracao)
                return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, System.Guid.Empty, "Administração",
                 TipoDoAutor.ADMINISTRACAO, notification.Origem);

            return new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, notification.MoradorId, notification.NomeMorador,
                 TipoDoAutor.MORADOR, notification.Origem);

        }

        public void Dispose()
        {
            _reservaAreaComumRepository?.Dispose();
            _reservaAreaComumQueryRepository?.Dispose();
        }        
    }
}
