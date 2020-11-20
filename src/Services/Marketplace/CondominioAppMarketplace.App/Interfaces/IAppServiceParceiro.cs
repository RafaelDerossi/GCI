using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioAppMarketplace.App.Model;
using CondominioAppMarketplace.App.ViewModel;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App.Interfaces
{
    public interface IAppServiceParceiro : IDisposable
    {
        Task<IEnumerable<ParceiroViewModel>> ObterTodos();

        Task<IEnumerable<ParceiroViewModel>> ObterAtivos();

        Task<IEnumerable<VendedorViewModel>> ObterTodosVendedores();

        Task<IEnumerable<VendedorViewModel>> ObterVendedoresDoParceiro(Guid ParceiroId);

        Task<ParceiroViewModel> ObterPorId(Guid Id);

        Task<ValidationResult> Adicionar(ParceiroViewModel ViewModel);

        Task<ValidationResult> ContratarVendedor(VendedorViewModel ViewModel);
        
        Task<ValidationResult> AtualizarVendedor(VendedorAlterarViewModel ViewModel);

        Task<ValidationResult> DesativarPreCadastro(Guid ParceiroId);

        Task<ValidationResult> Atualizar(ParceiroViewModel ViewModel);

        Task<ValidationResult> AtualizarContrato(ContratoModel Model);

        Task<ValidationResult> AtualizarCnpj(ParceiroCnpjModel Model);

        Task<ValidationResult> AtualizarLogoMarca(ParceiroLogoMarcaModel Model);

        Task<ValidationResult> LimparLogoMarca(Guid ParceiroId);

        Task<bool> RemoverParceiro(Guid ParceiroId);

        Task<ValidationResult> DesativarLoja(Guid ParceiroId);

        Task<ValidationResult> ReativarLoja(Guid ParceiroId);

    }
}
