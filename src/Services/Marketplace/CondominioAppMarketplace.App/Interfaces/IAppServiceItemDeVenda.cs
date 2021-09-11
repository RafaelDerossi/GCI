using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioAppMarketplace.App.ViewModel;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App.Interfaces
{
    public interface IAppServiceItemDeVenda : IDisposable
    {
        Task<IEnumerable<ItemDaVitrineViewModel>> ObterTodos();

        Task<IEnumerable<ItemDaVitrineViewModel>> ObterPorParceiroId(Guid ParceiroId);

        Task<IEnumerable<ItemDaVitrineViewModel>> ObterPorVendedorId(Guid VendedorId);

        Task<ItemDaVitrineViewModel> ObterItemDaVitrine(Guid ItemDeVendaId);

        Task<ValidationResult> ExporItemNaVitrine(ItemDeVendaViewModel ViewModel);

        Task<ValidationResult> AlterarPreco(Guid ItemDeVendaId, decimal novoPreco);

        Task<ValidationResult> RemoverDaVitrine(Guid ItemDeVendaId);

        Task<ItemDaVitrineViewModel> ProdutoAleatorioDaVitrine();

        Task<ValidationResult> ContarClique(Guid ItemDeVendaId);

        Task<ValidationResult> RestauraProdutosDaVitrine(Guid ParceiroId);

        Task<ValidationResult> ReconfigurarIntervalos(Guid ItemDeVendaId, DateTime DataDeInicio, DateTime DataDeFim);

        Task<ValidationResult> AtualizarItemDeVenda(AtualizaItemDeVendaViewModel viewModel);
    }
}