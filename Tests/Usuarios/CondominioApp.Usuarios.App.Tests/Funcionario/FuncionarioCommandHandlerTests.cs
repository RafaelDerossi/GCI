using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Models;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class FuncionarioCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly FuncionarioCommandHandler _funcionarioCommandHandler;

        public FuncionarioCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _funcionarioCommandHandler = _mocker.CreateInstance<FuncionarioCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Funcionario Sindico Válido")]
        [Trait("Categoria", "Funcionarios - FuncionarioCommandHandler")]
        public async Task AdicionarFuncionarioSindico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var usuario = UsuarioFactoryTests.Criar_Usuario_Valido();            
            var Command = FuncionarioCommandFactory.CriarComandoCadastroDeSindico();
            usuario.SetEntidadeId(Command.UsuarioId);
            Funcionario funcionario = null;

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(Command.UsuarioId))
                .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterFuncionarioPorUsuarioIdECondominioId(Command.UsuarioId, Command.CondominioId))
               .Returns(Task.FromResult(funcionario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _funcionarioCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarFuncionario(It.IsAny<Funcionario>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Funcionario Porteiro Válido")]
        [Trait("Categoria", "Funcionarios - FuncionarioCommandHandler")]
        public async Task AdicionarFuncionarioPorteiro_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var usuario = UsuarioFactoryTests.Criar_Usuario_Valido();
            var Command = FuncionarioCommandFactory.CriarComandoCadastroDePorteiro();
            usuario.SetEntidadeId(Command.UsuarioId);
            Funcionario funcionario = null;

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(Command.UsuarioId))
                .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterFuncionarioPorUsuarioIdECondominioId(Command.UsuarioId, Command.CondominioId))
               .Returns(Task.FromResult(funcionario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _funcionarioCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarFuncionario(It.IsAny<Funcionario>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Editar Funcionario Válido")]
        [Trait("Categoria", "Funcionarios - FuncionarioCommandHandler")]
        public async Task EditarFuncionario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            var Command = FuncionarioCommandFactory.CriarComandoEdicaoDeFuncionario();
            Funcionario funcionario = FuncionarioFactoryTests.Criar_Funcionario_Porteiro_Valido();
            funcionario.SetEntidadeId(Command.Id);

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterFuncionarioPorId(Command.Id))
               .Returns(Task.FromResult(funcionario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _funcionarioCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarFuncionario(It.IsAny<Funcionario>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


    }
}