using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoEventHandler : EventHandler, INotificationHandler<GrupoCadastradoEvent>
    {
        private ICondominioQueryRepository _condominioQueryRepository;

        public GrupoEventHandler(ICondominioQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }

        public async Task Handle(GrupoCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var grupoFlat = new GrupoFlat
                (notification.GrupoId, notification.DataDeCadastro, notification.DataDeAlteracao, 
                notification.Lixeira, notification.Descricao, notification.CondominioId, 
                notification.CondominioCnpj, notification.CondominioNome, notification.CondominioLogoMarca);

            _condominioQueryRepository.AdicionarGrupo(grupoFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }      
    }
}
