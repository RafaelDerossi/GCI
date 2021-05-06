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
        INotificationHandler<ReservaCadastradaPeloUsuarioEvent>,
        INotificationHandler<ReservaCadastradaPelaAdmEvent>,
        INotificationHandler<ReservaAprovadaAutomaticamenteEvent>,
        INotificationHandler<ReservaAprovadaPelaAdministracaoEvent>,
        INotificationHandler<ReservaEnviadaParaAguardarAprovacaoEvent>,
        INotificationHandler<ReservaEnviadaParaFilaEvent>,
        INotificationHandler<ReservaCanceladaPeloUsuarioEvent>,
        INotificationHandler<ReservaCanceladaPelaAdmEvent>,
        INotificationHandler<ReservaReprovadaAutomaticamenteEvent>,
        INotificationHandler<ReservaReprovadaPelaAdmEvent>,
        INotificationHandler<ReservaMarcadaComoExpiradaEvent>,
        INotificationHandler<ReservaRetiradaDaFilaEvent>,
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


        public async Task Handle(ReservaCadastradaPeloUsuarioEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = new ReservaFlat
                (notification.Id, notification.AreaComumId, notification.NomeAreaComum,
                 notification.CondominioId, notification.NomeCondominio, notification.Capacidade,
                 notification.Observacao, notification.UnidadeId, notification.NumeroUnidade,
                 notification.AndarUnidade, notification.DescricaoGrupoUnidade, notification.MoradorId,
                 notification.NomeMorador, notification.DataDeRealizacao, notification.HoraInicio,
                 notification.HoraFim, notification.Preco, StatusReserva.PROCESSANDO,
                 notification.Justificativa, notification.Origem, false,
                 notification.ReservadoPelaAdministracao);

            _reservaAreaComumQueryRepository.AdicionarReserva(reservaFlat);

            var historico = new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, notification.MoradorId, notification.NomeMorador,
                 TipoDoAutor.MORADOR, notification.Origem);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }

        public async Task Handle(ReservaCadastradaPelaAdmEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = new ReservaFlat
                (notification.Id, notification.AreaComumId, notification.NomeAreaComum,
                 notification.CondominioId, notification.NomeCondominio, notification.Capacidade,
                 notification.Observacao, notification.UnidadeId, notification.NumeroUnidade,
                 notification.AndarUnidade, notification.DescricaoGrupoUnidade, notification.MoradorId,
                 notification.NomeMorador, notification.DataDeRealizacao, notification.HoraInicio,
                 notification.HoraFim, notification.Preco, StatusReserva.PROCESSANDO,
                 notification.Justificativa, notification.Origem, true,
                 notification.ReservadoPelaAdministracao);

            _reservaAreaComumQueryRepository.AdicionarReserva(reservaFlat);

            var historico = new HistoricoReservaFlat
                (notification.Id, AcoesReserva.SOLICITADA, notification.FuncionarioId, notification.NomeFuncionario,
                 TipoDoAutor.ADMINISTRACAO, notification.Origem);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }
    
        public async Task Handle(ReservaAprovadaAutomaticamenteEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.APROVADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaAcaoDoSistemaFactory(notification.Id, AcoesReserva.APROVADA);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }
    
        public async Task Handle(ReservaAprovadaPelaAdministracaoEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.APROVADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = new HistoricoReservaFlat
                (notification.Id, AcoesReserva.APROVADA, notification.FuncionarioId, notification.NomeFuncionario,
                 TipoDoAutor.ADMINISTRACAO, notification.Origem);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }
       
        public async Task Handle(ReservaEnviadaParaAguardarAprovacaoEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.AGUARDANDO_APROVACAO, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaAcaoDoSistemaFactory(notification.Id, AcoesReserva.AGUARDAR_APROVACAO);
         

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }

        public async Task Handle(ReservaEnviadaParaFilaEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.NA_FILA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaAcaoDoSistemaFactory(notification.Id, AcoesReserva.ENVIADA_PARA_FILA);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);

        }

        public async Task Handle(ReservaCanceladaPeloUsuarioEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.CANCELADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = new HistoricoReservaFlat
                (notification.Id, AcoesReserva.CANCELADA, notification.MoradorId, notification.NomeMorador,
                 TipoDoAutor.MORADOR, notification.Origem);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }

        public async Task Handle(ReservaCanceladaPelaAdmEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.CANCELADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = new HistoricoReservaFlat
                (notification.Id, AcoesReserva.CANCELADA, notification.FuncionarioId, notification.NomeFuncionario,
                 TipoDoAutor.ADMINISTRACAO, notification.Origem);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }

        public async Task Handle(ReservaReprovadaAutomaticamenteEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.REPROVADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaAcaoDoSistemaFactory(notification.Id, AcoesReserva.REPROVADA);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }

        public async Task Handle(ReservaReprovadaPelaAdmEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.REPROVADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = new HistoricoReservaFlat
                (notification.Id, AcoesReserva.CANCELADA, notification.FuncionarioId, notification.NomeFuncionario,
                 TipoDoAutor.ADMINISTRACAO, notification.Origem);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }

        public async Task Handle(ReservaMarcadaComoExpiradaEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(StatusReserva.EXPIRADA, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico = HistoricoReservaAcaoDoSistemaFactory(notification.Id, AcoesReserva.EXPIRADA);

            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }

        public async Task Handle(ReservaRetiradaDaFilaEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;

            reservaFlat.SetStatus(notification.Status, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            var historico1 = HistoricoReservaAcaoDoSistemaFactory(notification.Id, AcoesReserva.RETIRADA_DA_FILA);
            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico1);

            var historico2 = HistoricoReservaPorStatusFactory(notification.Id, notification.Status);
            _reservaAreaComumQueryRepository.AdicionarHistoricoReserva(historico2);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }
        private HistoricoReservaFlat HistoricoReservaPorStatusFactory(System.Guid reservaId, StatusReserva status)
        {
            return status switch
            {
                StatusReserva.PROCESSANDO => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.SOLICITADA),
                StatusReserva.APROVADA => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.APROVADA),
                StatusReserva.REPROVADA => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.REPROVADA),
                StatusReserva.AGUARDANDO_APROVACAO => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.AGUARDAR_APROVACAO),
                StatusReserva.NA_FILA => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.ENVIADA_PARA_FILA),
                StatusReserva.CANCELADA => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.CANCELADA),
                StatusReserva.EXPIRADA => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.EXPIRADA),
                StatusReserva.REMOVIDA => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.REMOVIDA),
                _ => HistoricoReservaAcaoDoSistemaFactory(reservaId, AcoesReserva.SOLICITADA),
            };
        }


        private HistoricoReservaFlat HistoricoReservaAcaoDoSistemaFactory(System.Guid reservaId, AcoesReserva acao)
        {
            return new HistoricoReservaFlat
                (reservaId, acao, System.Guid.Empty, "Ação Automática",
                 TipoDoAutor.SISTEMA, "Sistema");
        }

        public void Dispose()
        {
            _reservaAreaComumRepository?.Dispose();
            _reservaAreaComumQueryRepository?.Dispose();
        }        
    }
}
