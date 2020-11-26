using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CondominioApp.Core.ValueObjects;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.ProdutoFactory;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain.Interfaces;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App
{
    public class AppServiceProduto : AppService, IAppServiceProduto
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public AppServiceProduto(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ValidationResult> AtualizarPreco(Guid ItemDeVendaId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoViewModel>> ExibirCatalogo()
        {
            var produtos = await _repository.Obter(p => !p.Lixeira && p.Ativo, true, 250);

            return await Task.FromResult(_mapper.Map<IEnumerable<ProdutoViewModel>>(produtos));
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid Id)
        {
            return await Task.FromResult(_mapper.Map<ProdutoViewModel>(
                await _repository.ObterPorId(Id)
                ));
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutoDoParceiro(Guid parceiroId)
        {
            var produtos = await _repository.Obter(p => !p.Lixeira && p.ParceiroId == parceiroId, true, 250);

            return await Task.FromResult(_mapper.Map<IEnumerable<ProdutoViewModel>>(produtos));
        }


        public async Task<ValidationResult> Adicionar(ProdutoViewModel ViewModel)
        {
            FabricaDeProdutos FabricaDeProdutos;

            if (ViewModel.LinkExternoDeFotos)
                FabricaDeProdutos = new FabricaDeProdutos(new ProdutoComLinkExternoDeFotos());
            else
                FabricaDeProdutos = new FabricaDeProdutos(new ProdutoComFotosNoArquivo());

            var ProdutoNovo = FabricaDeProdutos.CriarProduto(ViewModel);

            _repository.Adicionar(ProdutoNovo);

            return await PersistirDados(_repository.UnitOfWork);
        }


        public async Task<ValidationResult> MarcarFotoPrincipal(FotoPrincipalViewModel ViewModel)
        {
            var produto = _repository.Obter(x => x.Id == ViewModel.ProdutoId, false, 1).Result.FirstOrDefault();

            produto.MarcarFotoPrincipal(ViewModel.FotoDoProdutoId);

            _repository.Atualizar(produto);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Atualizar(ProdutoViewModel ViewModel)
        {
            var produto = await _repository.ObterPorId(ViewModel.ProdutoId);

            produto.setNome(ViewModel.Nome);
            produto.setChamada(ViewModel.Chamada);
            produto.setDescricao(ViewModel.Descricao);
            produto.setEspecificacaoTecnica(ViewModel.EspecificacaoTecnica);
            produto.setUrl(new Url(ViewModel.LinkDoProduto));

            _repository.Atualizar(produto);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
