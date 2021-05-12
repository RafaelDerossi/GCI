using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoEventHandler : EventHandler,
        INotificationHandler<GrupoCadastradoEvent>,
        INotificationHandler<GrupoEditadoEvent>,
        INotificationHandler<GrupoApagadoEvent>,
        System.IDisposable
    {
        private readonly IPrincipalQueryRepository _condominioQueryRepository;

        public GrupoEventHandler(IPrincipalQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }
       

        public async Task Handle(GrupoCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var grupoFlat = new GrupoFlat
                (notification.GrupoId, 
                false, notification.Descricao, notification.CondominioId, 
                notification.CondominioCnpj, notification.CondominioNome, notification.CondominioLogoMarca);

            _condominioQueryRepository.AdicionarGrupo(grupoFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(GrupoEditadoEvent notification, CancellationToken cancellationToken)
        {

            //Atualizar no GrupoFlat
            var grupoFlat = await _condominioQueryRepository.ObterGrupoPorId(notification.GrupoId);
           
            grupoFlat.SetDescricao(notification.Descricao);

            _condominioQueryRepository.AtualizarGrupo(grupoFlat);

            //Atualizar no UnidadeFlat
            var unidadesDoCondominio = await _condominioQueryRepository.ObterUnidadesPorGrupo(notification.GrupoId);
            foreach (UnidadeFlat unidade in unidadesDoCondominio)
            {
                unidade.SetGrupoDescricao(notification.Descricao);               

                _condominioQueryRepository.AtualizarUnidade(unidade);
            }

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }

        public async Task Handle(GrupoApagadoEvent notification, CancellationToken cancellationToken)
        {
            //Atualizar no GrupoFlat
            var grupoFlat = await _condominioQueryRepository.ObterGrupoPorId(notification.GrupoId);            

            _condominioQueryRepository.ApagarGrupo(x=>x.Id == grupoFlat.Id);
            
            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }



        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}
