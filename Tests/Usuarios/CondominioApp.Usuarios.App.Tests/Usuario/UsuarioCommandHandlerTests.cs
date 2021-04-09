using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Models;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly UsuarioCommandHandler _usuarioCommandHandler;

        public UsuarioCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _usuarioCommandHandler = _mocker.CreateInstance<UsuarioCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Usuário Válido")]
        [Trait("Categoria", "Usuários - Usuario CommandHandler")]
        public async Task AdicionarUsuario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuario();


            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _usuarioCommandHandler.Handle(UsuarioCommand, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.Adicionar(It.IsAny<Usuario>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Editar Usuário Válido")]
        [Trait("Categoria", "Usuários - Usuario CommandHandler")]
        public async Task EditarUsuario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var usuario = UsuarioFactoryTests.Criar_Usuario_Valido();
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoEdicaoDeUsuario();
            usuario.SetEntidadeId(UsuarioCommand.UsuarioId);

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(usuario.Id))
               .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _usuarioCommandHandler.Handle(UsuarioCommand, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.Atualizar(It.IsAny<Usuario>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}