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

        Task<IEnumerable<ItemDaVitrineViewModel>> ObterPorCondominioId(Guid CondominioId);

        Task<IEnumerable<ItemDaVitrineViewModel>> ObterPorParceiroId(Guid ParceiroId);

        Task<IEnumerable<ItemDaVitrineViewModel>> ObterPorVendedorId(Guid VendedorId);

        Task<ItemDaVitrineViewModel> ObterItemDaVitrine(Guid ItemDeVendaId);

        Task<ValidationResult> ExporItemNaVitrine(ItemDeVendaViewModel ViewModel);

        Task<ValidationResult> AlterarPreco(Guid ItemDeVendaId, decimal novoPreco);

        Task<bool> RemoverDaVitrine(Guid ItemDeVendaId);

        Task<ItemDaVitrineViewModel> ProdutoAleatorioDaVitrine();

        Task<bool> ContarClique(Guid ItemDeVendaId);

        Task<ValidationResult> RestauraProdutosDaVitrine(Guid ParceiroId);

        Task<ValidationResult> ReconfigurarIntervalos(Guid ItemDeVendaId, DateTime DataDeInicio, DateTime DataDeFim);
    }
}