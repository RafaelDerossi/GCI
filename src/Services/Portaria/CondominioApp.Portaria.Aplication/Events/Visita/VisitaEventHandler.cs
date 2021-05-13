using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.Interfaces;
using MediatR;

namespace CondominioApp.Portaria.Aplication.Events
{
    public class VisitaEventHandler : EventHandler,
        INotificationHandler<VisitaAdicionadaEvent>,
        INotificationHandler<VisitaAtualizadaEvent>,
        INotificationHandler<VisitaApagadaEvent>,
        INotificationHandler<VisitaAprovadaEvent>,
        INotificationHandler<VisitaReprovadaEvent>,
        INotificationHandler<VisitaIniciadaEvent>,
        INotificationHandler<VisitaTerminadaEvent>,
        System.IDisposable
    {        

        private readonly IPortariaQueryRepository _visitanteQueryRepository;
        public VisitaEventHandler(
            IPortariaQueryRepository visitanteQueryRepository)
        {
            _visitanteQueryRepository = visitanteQueryRepository;
        }


        public async Task Handle(VisitaAdicionadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = VisitaFlatFactory(notification);
            
            _visitanteQueryRepository.AdicionarVisita(visitaFlat);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }

        public async Task Handle(VisitaAtualizadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.SetObservacao(notification.Observacao);
                visitaFlat.SetNomeVisitante(notification.NomeVisitante);
                visitaFlat.SetDocumentoVisitante(notification.DocumentoVisitante, notification.TipoDeDocumentoVisitante);               
                visitaFlat.SetEmailVisitante(notification.EmailVisitante.Endereco);
                visitaFlat.SetFotoVisitante(notification.FotoVisitante.NomeDoArquivo);
                visitaFlat.SetTipoDeVisitante(notification.TipoDeVisitante);
                visitaFlat.SetNomeEmpresaVisitante(notification.NomeEmpresaVisitante);
                visitaFlat.SetUnidadeId(notification.UnidadeId);
                visitaFlat.SetNumeroUnidade(notification.NumeroUnidade);
                visitaFlat.SetAndarUnidade(notification.AndarUnidade);
                visitaFlat.SetGrupoUnidade(notification.GrupoUnidade);

                visitaFlat.MarcarNaoTemVeiculo();
                if (notification.TemVeiculo)
                    visitaFlat.MarcarTemVeiculo();

                visitaFlat.SetPlacaVeiculo(notification.Veiculo.Placa);
                visitaFlat.SetModeloVeiculo(notification.Veiculo.Modelo);
                visitaFlat.SetCorVeiculo(notification.Veiculo.Cor);

                visitaFlat.SetUsuario(notification.UsuarioId, notification.NomeUsuario);

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);
               
            }

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);

        }

        public async Task Handle(VisitaApagadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if(visitaFlat != null)
            {
                _visitanteQueryRepository.ApagarVisita(x=>x.Id == visitaFlat.Id);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }

        public async Task Handle(VisitaAprovadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.AprovarVisita();

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }           
        }

        public async Task Handle(VisitaReprovadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.ReprovarVisita();

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }

        public async Task Handle(VisitaIniciadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.IniciarVisita(notification.DataDeEntrada);

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }

        public async Task Handle(VisitaTerminadaEvent notification, CancellationToken cancellationToken)
        {
            var visitaFlat = await _visitanteQueryRepository.ObterVisitaPorId(notification.Id);
            if (visitaFlat != null)
            {
                visitaFlat.TerminarVisita(notification.DataDeSaida);

                _visitanteQueryRepository.AtualizarVisita(visitaFlat);

                await PersistirDados(_visitanteQueryRepository.UnitOfWork);
            }            
        }


        private VisitaFlat VisitaFlatFactory(VisitaEvent notification)
        {
           var visita = new VisitaFlat
                (notification.Id, notification.DataDeEntrada, notification.Observacao,
                 notification.VisitanteId, notification.NomeVisitante, notification.TipoDeDocumentoVisitante,
                 notification.DocumentoVisitante, notification.EmailVisitante.Endereco, 
                 notification.FotoVisitante.NomeDoArquivo, notification.TipoDeVisitante,
                 notification.NomeEmpresaVisitante, notification.CondominioId, notification.NomeCondominio,
                 notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
                 notification.TemVeiculo, notification.Veiculo.Placa, notification.Veiculo.Modelo, 
                 notification.Veiculo.Cor, notification.UsuarioId, notification.NomeUsuario);

            
            visita.MarcarVisitaComoPendente();

            if (notification.Status == StatusVisita.APROVADA)
                visita.AprovarVisita();            

            return visita;
        }

        public void Dispose()
        {
            _visitanteQueryRepository?.Dispose();            
        }        

    }
}
