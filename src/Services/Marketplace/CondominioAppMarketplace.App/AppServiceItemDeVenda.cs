using AutoMapper;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAppMarketplace.App
{
    public class AppServiceItemDeVenda : AppService, IAppServiceItemDeVenda
    {
        private readonly IItemDeVendaRepository _repository;

        private readonly IMapper _mapper;

        public AppServiceItemDeVenda(IItemDeVendaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDaVitrineViewModel>> ObterTodos()
        {
            DateTime Hoje = DateTime.Now.Date;

            var ItensDeVenda = await _repository.Obter(m => m.DataDeInicio.Date <= Hoje && m.DataDeFim.Date >= Hoje && !m.Lixeira, true, 100);

            ItensDeVenda = ItensDeVenda.OrderBy(x => Guid.NewGuid()).ToList();

            return await Task.FromResult(_mapper.Map<IEnumerable<ItemDaVitrineViewModel>>(ItensDeVenda));
        }

        public async Task<ValidationResult> AlterarPreco(Guid ItemDeVendaId, decimal novoPreco)
        {
            var ItemDeVenda = await _repository.ObterPorId(ItemDeVendaId);
            ItemDeVenda.SetPreco(novoPreco);

            return await PersistirDados(_repository.UnitOfWork);
        }

       
        public async Task<IEnumerable<ItemDaVitrineViewModel>> ObterPorParceiroId(Guid ParceiroId)
        {
            DateTime Hoje = DateTime.Now.Date;

            var ItensDeVenda = await _repository.Obter(m => m.DataDeInicio.Date <= Hoje &&
                                                       m.DataDeFim.Date >= Hoje &&
                                                       m.ParceiroId == ParceiroId &&
                                                       !m.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<ItemDaVitrineViewModel>>(ItensDeVenda));
        }

        public async Task<IEnumerable<ItemDaVitrineViewModel>> ObterPorVendedorId(Guid VendedorId)
        {
            DateTime Hoje = DateTime.Now.Date;

            var ItensDeVenda = await _repository.Obter(m => m.DataDeInicio.Date <= Hoje &&
                                                       m.DataDeFim.Date >= Hoje &&
                                                       m.VendedorId == VendedorId &&
                                                       !m.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<ItemDaVitrineViewModel>>(ItensDeVenda));
        }
        
        public async Task<ItemDaVitrineViewModel> ObterItemDaVitrine(Guid ItemDeVendaId)
        {
            var ItemDeVenda = _repository.Obter(x => x.Id == ItemDeVendaId, false, 1).Result.FirstOrDefault();

            return await Task.FromResult(_mapper.Map<ItemDaVitrineViewModel>(ItemDeVenda));
        }

        public async Task<ItemDaVitrineViewModel> ProdutoAleatorioDaVitrine()
        {
            var ItemDaVitrine = _repository.ObterItemDeVendaAleatorio();

            return await Task.FromResult(_mapper.Map<ItemDaVitrineViewModel>(ItemDaVitrine));
        }

        public async Task<ValidationResult> RemoverDaVitrine(Guid ItemDeVendaId)
        {
            var ItemDeVenda = await _repository.ObterPorId(ItemDeVendaId);
            ItemDeVenda.EnviarParaLixeira();

            return await PersistirDados(_repository.UnitOfWork);          
        }

        public async Task<ValidationResult> ExporItemNaVitrine(ItemDeVendaViewModel ViewModel)
        {
            //var itemDeVenda = _mapper.Map<ItemDeVenda>(ViewModel);

            var itemDeVenda = new ItemDeVenda(ViewModel.PrecoDoProduto,ViewModel.PorcentagemDeDesconto,
                ViewModel.DataDeInicioDaExposicao,ViewModel.DataDeFinalDaExposicao,
                ViewModel.ProdutoId,ViewModel.VendedorId,ViewModel.ParceiroId);

            if (_repository.VerificarExistenciaDoItemDeVenda(itemDeVenda.ProdutoId, itemDeVenda.ParceiroId))
            {
                AdicionarErro("Ja existe um item na vitrine para este produto e condomínio!");
                return ValidationResult;
            }

            _repository.Adicionar(itemDeVenda);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> ContarClique(Guid ItemDeVendaId)
        {
            var ItemDaVitrine = await _repository.ObterPorId(ItemDeVendaId);
            ItemDaVitrine.ContaCliques();

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> RestauraProdutosDaVitrine(Guid ParceiroId)
        {
            var ItensDeVenda = await _repository.ObterItensDoParceiro(ParceiroId);

            foreach (var itemDeVenda in ItensDeVenda) itemDeVenda.RestaurarDaLixeira();

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> ReconfigurarIntervalos(Guid ItemDeVendaId, DateTime DataDeInicio, DateTime DataDeFim)
        {
            var ItemDeVenda = await _repository.ObterPorId(ItemDeVendaId);

            var Resultado = ItemDeVenda.ConfigurarIntervalo(DataDeInicio, DataDeFim);

            if (!Resultado.IsValid) return Resultado;

            return await PersistirDados(_repository.UnitOfWork);
        }
        
        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
