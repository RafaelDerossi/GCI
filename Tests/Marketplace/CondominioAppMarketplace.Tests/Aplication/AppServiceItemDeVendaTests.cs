using System;
using System.Threading.Tasks;
using CondominioAppMarketplace.App;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Interfaces;
using CondominioAppMarketplace.Infra.Repositories;
using CondominioAppMarketplace.Tests.Domain;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace CondominioAppMarketplace.Tests.Aplication
{
    public class AppServiceItemDeVendaTests
    {
        private readonly AutoMocker _mocker;
        private readonly AppServiceItemDeVenda _appServiceItemDeVenda;

        public AppServiceItemDeVendaTests()
        {
            _mocker = new AutoMocker();
            _appServiceItemDeVenda = _mocker.CreateInstance<AppServiceItemDeVenda>();
        }

        [Fact(DisplayName = "Remover Item da Vitrine")]
        [Trait("Categoria", "Item de Venda - AppServiceItemDeVenda")]
        public async Task Remover_da_vitrine()
        {
            //Arrange
            Guid ItemDeVendaId = Guid.NewGuid();
            _mocker.GetMock<IItemDeVendaRepository>().Setup(r => r.ObterPorId(ItemDeVendaId))
                .Returns(Task.FromResult(ItemDeVendaFactory.CriarItemDeVendaValido()));

            _mocker.GetMock<IItemDeVendaRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _appServiceItemDeVenda.RemoverDaVitrine(ItemDeVendaId);

            //Assert
            Assert.True(result);
            _mocker.GetMock<IItemDeVendaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Expor produto na vitrine")]
        [Trait("Categoria", "Item de Venda - AppServiceItemDeVenda")]
        public async Task Expor_na_vitrine()
        {
            //Arrange
            Guid ParceiroId = Guid.NewGuid();
            Guid ProdutoId = Guid.NewGuid();
            Guid VendedorId = Guid.NewGuid();

            var ItemDeVenda = new ItemDeVendaViewModel()
            {
                ParceiroId = ParceiroId,
                ProdutoId = ProdutoId,
                VendedorId = VendedorId,
                DataDeInicioDaExposicao = new DateTime(2020,05,10),
                DataDeFinalDaExposicao = new DateTime(2020,10,31),
                PorcentagemDeDesconto = 10,
                PrecoDoProduto = 100
            };

            _mocker.GetMock<IItemDeVendaRepository>().Setup(r => r.VerificarExistenciaDoItemDeVenda(ItemDeVenda.ProdutoId, ItemDeVenda.ParceiroId))
                .Returns(false);

            _mocker.GetMock<IItemDeVendaRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _appServiceItemDeVenda.ExporItemNaVitrine(ItemDeVenda);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IItemDeVendaRepository>().Verify(r => r.Adicionar(It.IsAny<ItemDeVenda>()), Times.Once);
            _mocker.GetMock<IItemDeVendaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}