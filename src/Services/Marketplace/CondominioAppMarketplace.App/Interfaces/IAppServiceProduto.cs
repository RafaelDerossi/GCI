using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioAppMarketplace.App.ViewModel;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App.Interfaces
{
    public interface IAppServiceProduto : IDisposable
    {
        Task<ValidationResult> Adicionar(ProdutoViewModel ViewModel);

        Task<ValidationResult> MarcarFotoPrincipal(FotoPrincipalViewModel ViewModel);

        Task<ValidationResult> Atualizar(ProdutoViewModel ViewModel);

        Task<ValidationResult> AtualizarPreco(Guid ItemDeVendaId);

        Task<IEnumerable<ProdutoViewModel>> ExibirCatalogo();

        Task<ProdutoViewModel> ObterPorId(Guid Id);
    }
}
