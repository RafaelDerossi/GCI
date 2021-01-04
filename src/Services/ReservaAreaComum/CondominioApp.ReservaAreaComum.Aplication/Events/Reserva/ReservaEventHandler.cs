using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using MediatR;


namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class ReservaEventHandler : EventHandler, 
        INotificationHandler<ReservaCanceladaEvent>,       
        System.IDisposable
    {

        private IAreaComumRepository _areaComumRepository;

        public ReservaEventHandler(IAreaComumRepository areaComumRepository)
        {
            _areaComumRepository = areaComumRepository;
        }

        public async Task Handle(ReservaCanceladaEvent notification, CancellationToken cancellationToken)
        {
            var areaComum = await _areaComumRepository.ObterPorId(await _areaComumRepository.ObterAreaComumIdPorReservaId(notification.Id));
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return;
            }           

            //Retirar proxima da fila
            var reservaCancelada = areaComum.ObterReserva(notification.Id);
            var reservaRetiradaDaFila = areaComum.RetirarProximaReservaDaFila(reservaCancelada);
                       

            await PersistirDados(_areaComumRepository.UnitOfWork);
        }

       
        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }        
    }
}
