using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.Interfaces;
using MediatR;


namespace CondominioApp.Portaria.Aplication.Events
{
    public class VisitanteEventHandler : EventHandler,
        INotificationHandler<VisitanteAdicionadoEvent>,
        INotificationHandler<VisitanteAtualizadoEvent>,
        INotificationHandler<VisitanteApagadoEvent>,
        System.IDisposable
    {        
        private readonly IPortariaQueryRepository _visitanteQueryRepository;
        public VisitanteEventHandler(
            IPortariaQueryRepository visitanteQueryRepository)
        {
            _visitanteQueryRepository = visitanteQueryRepository;            
        }


        public async Task Handle(VisitanteAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = VisitanteFlatFactory(notification);                

            _visitanteQueryRepository.Adicionar(visitanteFlat);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }

        public async Task Handle(VisitanteAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = await _visitanteQueryRepository.ObterPorId(notification.Id);

            visitanteFlat.SetNome(notification.Nome);
            visitanteFlat.SetDocumento(notification.Documento, notification.TipoDeDocumento);            
            visitanteFlat.SetEmail(notification.Email.Endereco);
            visitanteFlat.SetFoto(notification.Foto.NomeDoArquivo, notification.Foto.NomeOriginal);
            
            visitanteFlat.MarcarVisitanteComoTemporario();
            if (notification.VisitantePermanente)
                visitanteFlat.MarcarVisitanteComoPermanente();

            visitanteFlat.SetTipoDeVisitante(notification.TipoDeVisitante);
            visitanteFlat.SetNomeEmpresa(notification.NomeEmpresa);

            visitanteFlat.MarcarNaoTemVeiculo();
            if (notification.TemVeiculo)
                visitanteFlat.MarcarTemVeiculo();

            _visitanteQueryRepository.Atualizar(visitanteFlat);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }

        public async Task Handle(VisitanteApagadoEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = await _visitanteQueryRepository.ObterPorId(notification.Id);            
            
            _visitanteQueryRepository.Apagar(x=>x.Id == visitanteFlat.Id);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }


        private VisitanteFlat VisitanteFlatFactory(VisitanteEvent notification)
        {
            return new VisitanteFlat
               (notification.Id, notification.Nome, notification.TipoDeDocumento, notification.Documento,
               notification.Email.Endereco, notification.Foto.NomeDoArquivo, notification.Foto.NomeOriginal,
               notification.CondominioId, notification.NomeCondominio, notification.UnidadeId,
               notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
               notification.VisitantePermanente, notification.TipoDeVisitante,
               notification.NomeEmpresa, notification.TemVeiculo, notification.CriadorId, 
               notification.NomeDoCriador, notification.TipoDeUsuarioDoCriador);
        }


        public void Dispose()
        {
            _visitanteQueryRepository?.Dispose();
        }        

    }
}
