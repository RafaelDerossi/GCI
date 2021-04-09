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
    public class MoradorCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly MoradorCommandHandler _moradorCommandHandler;

        public MoradorCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _moradorCommandHandler = _mocker.CreateInstance<MoradorCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Morador Válido")]
        [Trait("Categoria", "Moradores - MoradorCommandHandler")]
        public async Task AdicionarMorador_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var usuario = UsuarioFactoryTests.Criar_Usuario_Valido();            
            var Command = MoradorCommandFactory.CriarComandoCadastroDeMorador();
            usuario.SetEntidadeId(Command.UsuarioId);
            Morador morador = null;

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(Command.UsuarioId))
                .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterMoradorPorUsuarioIdEUnidadeId(Command.UsuarioId, Command.UnidadeId))
               .Returns(Task.FromResult(morador));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _moradorCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarMorador(It.IsAny<Morador>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Marcar como Unidade Principal Válido")]
        [Trait("Categoria", "Moradores - MoradorCommandHandler")]
        public async Task MarcarComoUnidadePrincipal_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            Morador morador = MoradorFactoryTests.Criar_Morador_Valido();
            var command = MoradorCommandFactory.CriarComandoMarcarComoUnidadePrincipal();
            morador.SetEntidadeId(command.Id);
            IEnumerable<Morador> moradores = new List<Morador>();

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterMoradorPorId(command.Id))
               .Returns(Task.FromResult(morador));


            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterMoradores(m => m.UsuarioId == morador.UsuarioId && m.Id != morador.Id, false, 0))
                .Returns(Task.FromResult(moradores));

            
            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _moradorCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarMorador(It.IsAny<Morador>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Marcar como Proprietario Válido")]
        [Trait("Categoria", "Moradores - MoradorCommandHandler")]
        public async Task MarcarComoProprietario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            Morador morador = MoradorFactoryTests.Criar_Morador_Valido();
            var command = MoradorCommandFactory.CriarComandoMarcarComoProprietario();
            morador.SetEntidadeId(command.Id);
                        

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterMoradorPorId(command.Id))
               .Returns(Task.FromResult(morador));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _moradorCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarMorador(It.IsAny<Morador>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Desmarcar como Proprietario Válido")]
        [Trait("Categoria", "Moradores - MoradorCommandHandler")]
        public async Task DesmarcarComoProprietario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            Morador morador = MoradorFactoryTests.Criar_Morador_Valido();
            var command = MoradorCommandFactory.CriarComandoDesmarcarComoProprietario();
            morador.SetEntidadeId(command.Id);


            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterMoradorPorId(command.Id))
               .Returns(Task.FromResult(morador));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _moradorCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarMorador(It.IsAny<Morador>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}