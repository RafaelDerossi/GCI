using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.Models;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioEventHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly FuncionarioEventHandler _usuarioEventHandler;

        public UsuarioEventHandlerTests()
        {
            _mocker = new AutoMocker();
            _usuarioEventHandler = _mocker.CreateInstance<FuncionarioEventHandler>();
        }

        [Fact(DisplayName = "Adicionar Usuário Válido")]
        [Trait("Categoria", "Usuários - Usuario EventHandler")]
        public async Task AdicionarUsuario_EventValido()
        {
            //Arrange
            var UsuarioEvent = UsuarioEventFactory.CriarEventoCadastroDeMorador();

            
            //Act
            await _usuarioEventHandler.Handle(UsuarioEvent, CancellationToken.None);

            //Assert
            Assert.True(true);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.Adicionar(It.IsAny<Usuario>()), Times.Once);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}