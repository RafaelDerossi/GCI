using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioAppMarketplace.Domain.Events;
using CondominioAppMarketplace.Domain.Interfaces;
using CondominioAppMarketplace.Infra.EmailServices;
using MediatR;

namespace CondominioAppMarketplace.Infra.EventHandler
{
    public class NotificarVendedorEventHandler : INotificationHandler<NotificarVendedorEvent>, IDisposable
    {

        private readonly IItemDeVendaRepository _ItemDeVendaRepository;

        private readonly IParceiroRepository _parceiroRepository;

        private readonly IProdutoRepository _produtoRepository;

        public NotificarVendedorEventHandler(IItemDeVendaRepository itemDeVendaRepository, 
                                             IParceiroRepository parceiroRepository, 
                                             IProdutoRepository produtoRepository)
        {
            _ItemDeVendaRepository = itemDeVendaRepository;
            _parceiroRepository = parceiroRepository;
            _produtoRepository = produtoRepository;
        }


        public async Task Handle(NotificarVendedorEvent notification, CancellationToken cancellationToken)
        {
            var Lead = await _ItemDeVendaRepository.ObterLeadPorId(notification.AggregateId);

            var vendedor = await _parceiroRepository.ObterVendedorPorId(notification.VendedorId);

            var produto = await _produtoRepository.ObterPorId(Lead.ItemDeVenda.ProdutoId);

            Lead.ItemDeVenda.setVendedor(vendedor);
            Lead.ItemDeVenda.setProduto(produto);

            var disparadorDeEmail = new DisparadorDeEmails(new EmailDeNotificacaoDeNovoLead(Lead, "Novo Lead para você!"));

            await disparadorDeEmail.Disparar();
        }

        public void Dispose()
        {
            _ItemDeVendaRepository?.Dispose();
            _parceiroRepository?.Dispose();
            _produtoRepository?.Dispose();
        }
    }
}