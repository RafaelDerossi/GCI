using CondominioAppMarketplace.App;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Interfaces;
using CondominioAppMarketplace.Tests.Domain;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CondominioAppMarketplace.Tests.Aplication
{
    public class AppServiceCampanhaTests
    {
        private readonly AutoMocker _mocker;
        private readonly AppServiceCampanha _appServiceCampanha;

        public AppServiceCampanhaTests()
        {
            _mocker = new AutoMocker();
            _appServiceCampanha = _mocker.CreateInstance<AppServiceCampanha>();
        }

        [Fact(DisplayName = "Configurar intervalo da campanha")]
        [Trait("Categoria", "Campanha - AppServiceCampanha")]
        public async Task Configurar_intervalo_da_campanha()
        {
            //Arrange
            Guid campanhaId = Guid.NewGuid();
            var IntervaloDeCampanha = new IntervaloDeCampanhaViewModel()
            {
                CampanhaId = campanhaId,
                NovaDataDeInicio = new DateTime(2020, 05, 10),
                NovaDataDeFinal = new DateTime(2020, 08, 01)
            };

            _mocker.GetMock<ICampanhaRepository>().Setup(r => r.ObterPorId(campanhaId))
                .Returns(Task.FromResult(CampanhaFactory.CriarCampanhaValida()));

            _mocker.GetMock<ICampanhaRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _appServiceCampanha.ReconfigurarIntervalos(IntervaloDeCampanha);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.Atualizar(It.IsAny<Campanha>()), Times.Once);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Contar cliques")]
        [Trait("Categoria", "Campanha - AppServiceCampanha")]
        public async Task Contar_cliques()
        {
            //Arrange
            Guid campanhaId = Guid.NewGuid();
            _mocker.GetMock<ICampanhaRepository>().Setup(r => r.ObterPorId(campanhaId))
                .Returns(Task.FromResult(CampanhaFactory.CriarCampanhaValida()));

            _mocker.GetMock<ICampanhaRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _appServiceCampanha.ContabilizarCliques(campanhaId);

            //Assert
            Assert.True(result);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.Atualizar(It.IsAny<Campanha>()), Times.Once);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Iniciar uma campanha")]
        [Trait("Categoria", "Campanha - AppServiceCampanha")]
        public async Task Iniciar_campanha()
        {
            //Arrange
            Guid campanhaId = Guid.NewGuid();
            var CampanhaNova = new CampanhaNovaViewModel()
            {
                Descricao = "Nova Campanha",
                Ativo = true,
                Banner = "Campanha.jpg",
                ItemDeVendaId = Guid.NewGuid(),
                Titulo = "Titulo da campanha",
                DataDeInicio = new DateTime(2020, 05, 10),
                DataDeFim = new DateTime(2020, 08, 01)
            };

            _mocker.GetMock<ICampanhaRepository>()
                .Setup(c => c.VerificaExistenciaDaCampanha(CampanhaNova.ItemDeVendaId))
                .Returns(false);

            _mocker.GetMock<ICampanhaRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _appServiceCampanha.IniciarCampanha(CampanhaNova);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.Adicionar(It.IsAny<Campanha>()), Times.Once);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Desativar campanha")]
        [Trait("Categoria", "Campanha - AppServiceCampanha")]
        public async Task Destivar_campanha()
        {
            //Arrange
            Guid campanhaId = Guid.NewGuid();
            _mocker.GetMock<ICampanhaRepository>().Setup(r => r.ObterPorId(campanhaId))
                .Returns(Task.FromResult(CampanhaFactory.CriarCampanhaValida()));

            _mocker.GetMock<ICampanhaRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _appServiceCampanha.DeclinarCampanha(campanhaId);

            //Assert
            Assert.True(result);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.Atualizar(It.IsAny<Campanha>()), Times.Once);
            _mocker.GetMock<ICampanhaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}