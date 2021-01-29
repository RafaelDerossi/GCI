using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class VeiculoEventHandler : EventHandler,        
        INotificationHandler<UnidadeVeiculoCadastradaIntegrationEvent>,
        INotificationHandler<VeiculoEditadoComTrocaDeUsuarioIntegrationEvent>,
        System.IDisposable
    {
        private ICondominioQueryRepository _condominioQueryRepository;

        public VeiculoEventHandler(ICondominioQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }

        public async Task Handle(UnidadeVeiculoCadastradaIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var unidade = await _condominioQueryRepository.ObterUnidadePorId(notification.UnidadeId);
            var veiculoFlat = new VeiculoFlat
                (notification.Id, notification.VeiculoId, notification.Placa, notification.Modelo,
                 notification.Cor, notification.UsuarioId, notification.NomeUsuario, unidade.Id,
                 unidade.Numero, unidade.Andar, unidade.GrupoDescricao, notification.CondominioId);

            _condominioQueryRepository.AdicionarVeiculoFlat(veiculoFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(VeiculoEditadoComTrocaDeUsuarioIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var veiculos = await _condominioQueryRepository.ObterVeiculos(notification.VeiculoId);
            foreach (VeiculoFlat veiculo in veiculos)
            {
                _condominioQueryRepository.RemoverVeiculoFlat(veiculo);
            }
            
            var unidade = await _condominioQueryRepository.ObterUnidadePorId(notification.UnidadeId);
            var veiculoFlat = new VeiculoFlat
                (notification.Id, notification.VeiculoId, notification.Placa, notification.Modelo,
                 notification.Cor, notification.UsuarioId, notification.NomeUsuario, unidade.Id,
                 unidade.Numero, unidade.Andar, unidade.GrupoDescricao, notification.CondominioId);

            _condominioQueryRepository.AdicionarVeiculoFlat(veiculoFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}
