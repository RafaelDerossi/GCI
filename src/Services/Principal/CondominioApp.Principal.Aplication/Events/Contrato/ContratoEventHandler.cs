using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoEventHandler : EventHandler,
        INotificationHandler<ContratoCadastradoEvent>,
        INotificationHandler<ContratoEditadoEvent>,
        INotificationHandler<ContratoRemovidoEvent>,
        System.IDisposable
    {
        private IPrincipalQueryRepository _condominioQueryRepository;

        public ContratoEventHandler(IPrincipalQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }
       

        public async Task Handle(ContratoCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);
            if (notification.Ativo || condominioFlat.ContratoId == System.Guid.Empty)
            {
                var contrato = new Contrato
                               (notification.CondominioId, notification.DataAssinatura, notification.TipoPlano,
                               notification.DescricaoContrato, notification.Ativo, notification.LinkContrato);
                contrato.SetEntidadeId(notification.Id);

                condominioFlat.SetContrato(contrato);

                _condominioQueryRepository.Atualizar(condominioFlat);

                await PersistirDados(_condominioQueryRepository.UnitOfWork);
            }           
        }

        public async Task Handle(ContratoEditadoEvent notification, CancellationToken cancellationToken)
        {
            var condominioFlat = await _condominioQueryRepository.ObterPorId(notification.CondominioId);
            if (notification.Ativo || condominioFlat.ContratoId == System.Guid.Empty || condominioFlat.ContratoId == notification.Id)
            {
                var contrato = new Contrato
                               (notification.Id, notification.DataAssinatura, notification.TipoPlano,
                               notification.DescricaoContrato, notification.Ativo, notification.LinkContrato);
                contrato.SetEntidadeId(notification.Id);

                condominioFlat.SetContrato(contrato);

                _condominioQueryRepository.Atualizar(condominioFlat);

                await PersistirDados(_condominioQueryRepository.UnitOfWork);
            }
        }

        public async Task Handle(ContratoRemovidoEvent notification, CancellationToken cancellationToken)
        {
            var condominioFlat = await _condominioQueryRepository.ObterPorContratoId(notification.Id);
            if (condominioFlat != null)
            {
                var contrato = new Contrato(notification.CondominioId, System.DateTime.Today.Date, 0, "", false, "");
                contrato.SetEntidadeId(System.Guid.Empty);

                condominioFlat.SetContrato(contrato);

                _condominioQueryRepository.Atualizar(condominioFlat);

                await PersistirDados(_condominioQueryRepository.UnitOfWork);
            }
        }



        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}
