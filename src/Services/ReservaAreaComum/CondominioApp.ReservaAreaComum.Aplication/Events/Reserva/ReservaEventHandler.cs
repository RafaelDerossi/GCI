using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using MediatR;


namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class ReservaEventHandler : EventHandler,
        INotificationHandler<ReservaCadastradaEvent>,
        INotificationHandler<StatusDaReservaAlteradoEvent>,
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

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
        }

        public async Task Handle(StatusDaReservaAlteradoEvent notification, CancellationToken cancellationToken)
        {
            var reservaFlat = await _reservaAreaComumQueryRepository.ObterReservaPorId(notification.Id);
            if (reservaFlat == null)
                return;
            
            reservaFlat.SetStatus(notification.Status, notification.Justificativa);
            reservaFlat.SetObservacao(notification.Observacao);            

            _reservaAreaComumQueryRepository.AtualizarReserva(reservaFlat);

            await PersistirDados(_reservaAreaComumQueryRepository.UnitOfWork);
                     
        }
      


        public void Dispose()
        {
            _reservaAreaComumRepository?.Dispose();
            _reservaAreaComumQueryRepository?.Dispose();
        }        
    }
}
