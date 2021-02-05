using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class VeiculoEventHandler : EventHandler,        
        INotificationHandler<VeiculoCadastradoEvent>,
        INotificationHandler<VeiculoEditadoComTrocaDeUsuarioEvent>,
        System.IDisposable
    {
        private IVeiculoQueryRepository _veiculoQueryRepository;

        public VeiculoEventHandler(IVeiculoQueryRepository veiculoQueryRepository)
        {
            _veiculoQueryRepository = veiculoQueryRepository;
        }

        public async Task Handle(VeiculoCadastradoEvent notification, CancellationToken cancellationToken)
        {            
            var veiculoFlat = new VeiculoFlat
                (notification.Id, notification.VeiculoId, notification.Placa, notification.Modelo,
                 notification.Cor, notification.UsuarioId, notification.NomeUsuario, notification.UnidadeId,
                 notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
                 notification.CondominioId, notification.NomeCondominio);

            _veiculoQueryRepository.Adicionar(veiculoFlat);

            await PersistirDados(_veiculoQueryRepository.UnitOfWork);
        }

        public async Task Handle(VeiculoEditadoComTrocaDeUsuarioEvent notification, CancellationToken cancellationToken)
        {
            var veiculos = await _veiculoQueryRepository.Obter(v=>v.VeiculoId == notification.VeiculoId);
            foreach (VeiculoFlat veiculo in veiculos)
            {
                _veiculoQueryRepository.Remover(veiculo);
            }
            
            var unidade = await _veiculoQueryRepository.ObterUnidadePorId(notification.UnidadeId);
            var veiculoFlat = new VeiculoFlat
                (notification.Id, notification.VeiculoId, notification.Placa, notification.Modelo,
                 notification.Cor, notification.UsuarioId, notification.NomeUsuario, unidade.Id,
                 unidade.Numero, unidade.Andar, unidade.GrupoDescricao, notification.CondominioId);

            _veiculoQueryRepository.AdicionarVeiculoFlat(veiculoFlat);

            await PersistirDados(_veiculoQueryRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _veiculoQueryRepository?.Dispose();
        }
    }
}
