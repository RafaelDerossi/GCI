using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class UnidadeEventHandler : EventHandler,
        INotificationHandler<UnidadeCadastradaEvent>,
        INotificationHandler<UnidadeEditadaEvent>,
        INotificationHandler<CodigoUnidadeResetadoEvent>,
        INotificationHandler<UnidadeRemovidaEvent>,
        INotificationHandler<VagaDeUnidadeEditadaEvent>,
        System.IDisposable
    {
        private IPrincipalQueryRepository _condominioQueryRepository;

        public UnidadeEventHandler(IPrincipalQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }      

        public async Task Handle(UnidadeCadastradaEvent notification, CancellationToken cancellationToken)
        {
            var unidadeFlat = new UnidadeFlat
                (notification.UnidadeId, 
                 false, notification.Codigo, notification.Numero, notification.Andar,
                 notification.Vaga, notification.Telefone, notification.Ramal, notification.Complemento,
                 notification.GrupoId, notification.GrupoDescricao, notification.CondominioId, 
                 notification.CondominioCnpj, notification.CondominioNome, notification.CondominioLogoMarca);

            _condominioQueryRepository.AdicionarUnidade(unidadeFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(UnidadeEditadaEvent notification, CancellationToken cancellationToken)
        {
            var unidadeFlat = await _condominioQueryRepository.ObterUnidadePorId(notification.UnidadeId);
            
            unidadeFlat.SetNumero(notification.Numero);
            unidadeFlat.SetAndar(notification.Andar);
            unidadeFlat.SetVagas(notification.Vaga);
            unidadeFlat.SetTelefone(notification.Telefone);
            unidadeFlat.SetRamal(notification.Ramal);
            unidadeFlat.SetComplemento(notification.Complemento);
            
            _condominioQueryRepository.AtualizarUnidade(unidadeFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(CodigoUnidadeResetadoEvent notification, CancellationToken cancellationToken)
        {
            var unidadeFlat = await _condominioQueryRepository.ObterUnidadePorId(notification.UnidadeId);

            unidadeFlat.SetCodigo(notification.Codigo);          

            _condominioQueryRepository.AtualizarUnidade(unidadeFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(UnidadeRemovidaEvent notification, CancellationToken cancellationToken)
        {
            var unidadeFlat = await _condominioQueryRepository.ObterUnidadePorId(notification.UnidadeId);
           
            unidadeFlat.EnviarParaLixeira();

            _condominioQueryRepository.AtualizarUnidade(unidadeFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(VagaDeUnidadeEditadaEvent notification, CancellationToken cancellationToken)
        {
            var unidadeFlat = await _condominioQueryRepository.ObterUnidadePorId(notification.UnidadeId);
            if (unidadeFlat != null)
            {
                unidadeFlat.SetVagas(notification.Vaga);
             
                _condominioQueryRepository.AtualizarUnidade(unidadeFlat);

                await PersistirDados(_condominioQueryRepository.UnitOfWork);
            }            
        }

        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}
