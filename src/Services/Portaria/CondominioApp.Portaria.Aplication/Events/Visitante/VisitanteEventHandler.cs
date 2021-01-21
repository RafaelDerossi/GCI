using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.Interfaces;
using MediatR;


namespace CondominioApp.Portaria.Aplication.Events
{
    public class VisitanteEventHandler : EventHandler,
        INotificationHandler<VisitanteCadastradoEvent>,
        INotificationHandler<VisitanteEditadoEvent>,
        INotificationHandler<VisitanteRemovidoEvent>,
        System.IDisposable
    {        
        private IVisitanteQueryRepository _visitanteQueryRepository;
        public VisitanteEventHandler(
            IVisitanteQueryRepository visitanteQueryRepository)
        {
            _visitanteQueryRepository = visitanteQueryRepository;            
        }


        public async Task Handle(VisitanteCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = VisitanteFlatFactory(notification);                

            _visitanteQueryRepository.Adicionar(visitanteFlat);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }

        public async Task Handle(VisitanteEditadoEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = await _visitanteQueryRepository.ObterPorId(notification.Id);

            visitanteFlat.SetNome(notification.Nome);
            visitanteFlat.SetTipoDeDocumento(notification.TipoDeDocumento);
            visitanteFlat.SetCpf(notification.Cpf.Numero);
            visitanteFlat.SetRg(notification.Rg.Numero);
            visitanteFlat.SetEmail(notification.Email.Endereco);
            visitanteFlat.SetFoto(notification.Foto.NomeDoArquivo);
            
            visitanteFlat.MarcarVisitanteComoTemporario();
            if (notification.VisitantePermanente)
                visitanteFlat.MarcarVisitanteComoPermanente();

            visitanteFlat.SetTipoDeVisitante(notification.TipoDeVisitante);
            visitanteFlat.SetNomeEmpresa(notification.NomeEmpresa);

           
            if (notification.TemVeiculo)
            {
                visitanteFlat.MarcarTemVeiculo();
                visitanteFlat.SetPlacaVeiculo(notification.Veiculo.Placa);
                visitanteFlat.SetModeloVeiculo(notification.Veiculo.Modelo);
                visitanteFlat.SetCorVeiculo(notification.Veiculo.Cor);
            }
            else
            {
                visitanteFlat.MarcarNaoTemVeiculo();
                visitanteFlat.SetPlacaVeiculo("");
                visitanteFlat.SetModeloVeiculo("");
                visitanteFlat.SetCorVeiculo("");
            }               


            _visitanteQueryRepository.Atualizar(visitanteFlat);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }

        public async Task Handle(VisitanteRemovidoEvent notification, CancellationToken cancellationToken)
        {
            var visitanteFlat = await _visitanteQueryRepository.ObterPorId(notification.Id);

            visitanteFlat.EnviarParaLixeira();
            
            _visitanteQueryRepository.Atualizar(visitanteFlat);

            await PersistirDados(_visitanteQueryRepository.UnitOfWork);
        }


        private VisitanteFlat VisitanteFlatFactory(VisitanteEvent notification)
        {
            return new VisitanteFlat
               (notification.Id, notification.Nome, notification.TipoDeDocumento, notification.Rg.Numero,
               notification.Cpf.Numero, notification.Email.Endereco, notification.Foto.NomeDoArquivo,
               notification.CondominioId, notification.NomeCondominio, notification.UnidadeId,
               notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
               notification.VisitantePermanente, notification.QrCode, notification.TipoDeVisitante,
               notification.NomeEmpresa, notification.TemVeiculo, notification.Veiculo.Placa,
               notification.Veiculo.Modelo, notification.Veiculo.Cor);
        }


        public void Dispose()
        {
            _visitanteQueryRepository?.Dispose();
        }        

    }
}
