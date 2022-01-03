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
    public class ClienteCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly AcaoCommandHandler _clienteCommandHandler;

        public ClienteCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _clienteCommandHandler = _mocker.CreateInstance<AcaoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Cliente Válido")]
        [Trait("Categoria", "Cliente - ClienteCommandHandler")]
        public async Task AdicionarCliente_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = ClienteCommandFactory.CriarComandoAdicionarCliente();

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.VerificaCodigoJaCadastrado(Command.Email.Endereco))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _clienteCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IAcaoRepository>().Verify(r => r.Adicionar(It.IsAny<Acao>()), Times.Once);
            _mocker.GetMock<IAcaoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Cliente Inválido - E-mail ja cadastrado")]
        [Trait("Categoria", "Cliente - ClienteCommandHandler")]
        public async Task AdicionarCliente_CommandoInvalido_EmailJaCadastrado_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ClienteCommandFactory.CriarComandoAdicionarCliente();

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.VerificaCodigoJaCadastrado(Command.Email.Endereco))
                .Returns(Task.FromResult(true));

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _clienteCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);            
        }


        [Fact(DisplayName = "Adicionar Cliente Inválido - Sem E-mail")]
        [Trait("Categoria", "Cliente - ClienteCommandHandler")]
        public async Task AdicionarCliente_CommandoInvalido_SemEmail_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ClienteCommandFactory.CriarComandoAdicionarClienteSemEmail();

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.VerificaCodigoJaCadastrado(Command.Email.Endereco))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IAcaoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _clienteCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }
    }
}
