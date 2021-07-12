using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Correspondencias.App.Models;
using MediatR;


namespace CondominioApp.Correspondencias.Aplication.Events
{
    public class HistoricoEventHandler : EventHandler,
        INotificationHandler<RegistraHistoricoEvent>,
        INotificationHandler<MarcarComoVistoEvent>,
        System.IDisposable
    {
       
        private readonly ICorrespondenciaRepository _correspondenciaRepository;        

        public HistoricoEventHandler(ICorrespondenciaRepository correspondenciaRepository)
        {
            _correspondenciaRepository = correspondenciaRepository;            
        }


        public async Task Handle(RegistraHistoricoEvent notification, CancellationToken cancellationToken)
        {
            var historico = new HistoricoCorrespondencia
                (notification.CorrespondenciaId, notification.Acao, notification.FuncionarioId,
                 notification.NomeFuncionario, notification.Visto);

            _correspondenciaRepository.AdicionarHistorico(historico);                         

            await PersistirDados(_correspondenciaRepository.UnitOfWork);
        }

        public async Task Handle(MarcarComoVistoEvent notification, CancellationToken cancellationToken)
        {
            var historicos = await _correspondenciaRepository.ObterHistoricoPorCorrespondenciaId(notification.CorrespondenciaId);

            foreach (var item in historicos)
            {
                item.SetVisto();
                _correspondenciaRepository.AtualizarHistorico(item);
            }           

            await PersistirDados(_correspondenciaRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _correspondenciaRepository?.Dispose();
        }        
    }
}
