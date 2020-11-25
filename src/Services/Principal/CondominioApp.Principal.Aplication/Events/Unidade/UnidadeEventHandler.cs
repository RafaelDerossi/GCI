using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class UnidadeEventHandler : EventHandler, INotificationHandler<UnidadeCadastradaEvent>
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
                 notification.Lixeira, notification.Codigo, notification.Numero, notification.Andar,
                 notification.Vaga, notification.Telefone, notification.Ramal, notification.Complemento,
                 notification.GrupoId, notification.GrupoDescricao, notification.CondominioId, 
                 notification.CondominioCnpj, notification.CondominioNome, notification.CondominioLogoMarca);

            _condominioQueryRepository.AdicionarUnidade(unidadeFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }      
    }
}
