using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.ValueObjects;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MoradorEventHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly MoradorEventHandler _moradorEventHandler;

        public MoradorEventHandlerTests()
        {
            _mocker = new AutoMocker();
            _moradorEventHandler = _mocker.CreateInstance<MoradorEventHandler>();
        }

        [Fact(DisplayName = "Adicionar Morador Válido")]
        [Trait("Categoria", "Moradores - MoradorEventHandler")]
        public async Task AdicionarMoradorEvent_Valido()
        {
            //Arrange
           var usuario = new Usuario("Nome", "sobrenome", "52145256", new Telefone("(21) 99796-7038"),
               new Email("alexandre@techdog.com.br"), new Foto("Foto.jpg"));

            var evento = MoradorEventFactory.CriarEventoCadastroDeMorador();

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(evento.UsuarioId))
                .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IMoradorQueryRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            await _moradorEventHandler.Handle(evento, CancellationToken.None);

            //Assert
            Assert.True(true);
            _mocker.GetMock<IMoradorQueryRepository>().Verify(r => r.Adicionar(It.IsAny<MoradorFlat>()), Times.Once);
            _mocker.GetMock<IMoradorQueryRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}