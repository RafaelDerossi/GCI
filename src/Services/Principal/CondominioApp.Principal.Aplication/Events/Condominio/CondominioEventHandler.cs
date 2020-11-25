using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioEventHandler : EventHandler, INotificationHandler<CondominioCadastradoEvent>
    {
        private ICondominioQueryRepository _condominioQueryRepository;

        public CondominioEventHandler(ICondominioQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }

        public async Task Handle(CondominioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var condominioFlat = new CondominioFlat
                (notification.CondominioId, notification.DataDeCadastro, notification.DataDeAlteracao,
                notification.Lixeira, notification.Cnpj.NumeroFormatado, notification.Nome, notification.Descricao, 
                notification.LogoMarca.NomeDoArquivo, notification.Telefone.ObterNumeroFormatado,
                notification.Endereco.logradouro, notification.Endereco.complemento, 
                notification.Endereco.numero, notification.Endereco.cep, notification.Endereco.bairro,
                notification.Endereco.cidade, notification.Endereco.estado, notification.RefereciaId,
                notification.LinkGeraBoleto, notification.BoletoFolder, notification.UrlWebServer.Endereco,
                notification.Portaria, notification.PortariaMorador, notification.Classificado, 
                notification.ClassificadoMorador, notification.Mural, notification.MuralMorador, 
                notification.Chat, notification.ChatMorador, notification.Reserva, notification.ReservaNaPortaria,
                notification.Ocorrencia, notification.OcorrenciaMorador, notification.Correspondencia,
                notification.CorrespondenciaNaPortaria, notification.LimiteTempoReserva);

            _condominioQueryRepository.Adicionar(condominioFlat);

            await PersistirDados(_condominioQueryRepository.UnitOfWork);
        }      
    }
}
