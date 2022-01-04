using Moq;
using Moq.AutoMock;
using GCI.Acoes.Aplication.Commands;
using GCI.Acoes.Domain;
using GCI.Acoes.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GCI.Acoes.Tests
{
    public class AcaoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly AcaoCommandHandler _acaoCommandHandler;

        public AcaoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _acaoCommandHandler = _mocker.CreateInstance<AcaoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Acao Válida")]
        [Trait("Categoria", "Acao - AcaoCommandHandler")]
        public async Task AdicionarAcao_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = AcaoCommandFactory.CriarComandoAdicionarAcao();

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.VerificaCodigoJaCadastrado(Command.Codigo))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _acaoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IAcaoRepository>().Verify(r => r.Adicionar(It.IsAny<Acao>()), Times.Once);
            _mocker.GetMock<IAcaoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }        


        [Fact(DisplayName = "Adicionar Acao Inválida - Sem Codigo")]
        [Trait("Categoria", "Acao - AcaoCommandHandler")]
        public async Task AdicionarAcao_CommandoInvalido_SemCodigo_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AcaoCommandFactory.CriarComandoAdicionarAcaoSemCodigo();

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.VerificaCodigoJaCadastrado(Command.Codigo))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _acaoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }
    }
}
