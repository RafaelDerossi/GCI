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
        INotificationHandler<VeiculoEditadoEvent>,
        INotificationHandler<UsuarioDoVeiculoNoCondominioEditadoEvent>,        
        INotificationHandler<VeiculoRemovidoEvent>,
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

        public async Task Handle(VeiculoEditadoEvent notification, CancellationToken cancellationToken)
        {
            var veiculos = await _veiculoQueryRepository.ObterPorVeiculoId(notification.VeiculoId);

            foreach (var item in veiculos)
            {
                item.SetVeiculo(notification.VeiculoId, notification.Placa, notification.Modelo, notification.Cor);
                _veiculoQueryRepository.Atualizar(item);
            }            

            await PersistirDados(_veiculoQueryRepository.UnitOfWork);
        }

        public async Task Handle(UsuarioDoVeiculoNoCondominioEditadoEvent notification, CancellationToken cancellationToken)
        {
            var veiculos = await _veiculoQueryRepository.Obter(v=>v.VeiculoId == notification.VeiculoId && v.CondominioId == notification.CondominioId);
            foreach (VeiculoFlat veiculo in veiculos)
            {
                _veiculoQueryRepository.Remover(veiculo);
            }            
            
            var veiculoFlat = new VeiculoFlat
                (notification.Id, notification.VeiculoId, notification.Placa, notification.Modelo,
                 notification.Cor, notification.UsuarioId, notification.NomeUsuario, notification.UnidadeId,
                 notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
                 notification.CondominioId, notification.NomeCondominio);

            _veiculoQueryRepository.Adicionar(veiculoFlat);

            await PersistirDados(_veiculoQueryRepository.UnitOfWork);
        }

        public async Task Handle(VeiculoRemovidoEvent notification, CancellationToken cancellationToken)
        {
            var veiculos = await _veiculoQueryRepository.Obter(v => v.VeiculoId == notification.VeiculoId && v.CondominioId == notification.CondominioId);
            foreach (VeiculoFlat veiculo in veiculos)
            {
                _veiculoQueryRepository.Remover(veiculo);
            }

            await PersistirDados(_veiculoQueryRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _veiculoQueryRepository?.Dispose();
        }
    }
}
