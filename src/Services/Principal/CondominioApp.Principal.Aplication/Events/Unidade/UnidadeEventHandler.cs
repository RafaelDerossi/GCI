using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class UnidadeEventHandler : EventHandler,
        INotificationHandler<UnidadeCadastradaEvent>,
        INotificationHandler<UnidadeEditadaEvent>,
        INotificationHandler<CodigoUnidadeResetadoEvent>,
        INotificationHandler<UnidadeRemovidaEvent>,
        System.IDisposable
    {
        private ICondominioQueryRepository _condominioQueryRepository;

        public UnidadeEventHandler(ICondominioQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }      

        public async Task Handle(UnidadeCadastradaEvent notification, CancellationToken cancellationToken)
        {
            var unidadeFlat = new UnidadeFlat
                (notification.UnidadeId, notification.DataDeCadastro, notification.DataDeAlteracao, 
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

            unidadeFlat.SetDataDeAlteracao(notification.DataDeAlteracao);
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

            unidadeFlat.SetDataDeAlteracao(notification.DataDeAlteracao);
            unidadeFlat.SetCodigo(notification.Codigo);          

            _condominioQueryRepository.AtualizarUnidade(unidadeFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(UnidadeRemovidaEvent notification, CancellationToken cancellationToken)
        {
            var unidadeFlat = await _condominioQueryRepository.ObterUnidadePorId(notification.UnidadeId);

            unidadeFlat.SetDataDeAlteracao(notification.DataDeAlteracao);
            unidadeFlat.EnviarParaLixeira();

            _condominioQueryRepository.AtualizarUnidade(unidadeFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}
