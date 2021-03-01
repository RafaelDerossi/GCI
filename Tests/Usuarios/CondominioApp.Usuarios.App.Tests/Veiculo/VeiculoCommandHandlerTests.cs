using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Models;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class VeiculoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly VeiculoCommandHandler _veiculoCommandHandler;

        public VeiculoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _veiculoCommandHandler = _mocker.CreateInstance<VeiculoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Veiculo Válido")]
        [Trait("Categoria", "Veiculos - VeiculoCommandHandler")]
        public async Task AdicionarVeiculo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculo();
            var usuario = new Usuario("usuario", "sobrenome", "", null, null, null, TipoDeUsuario.MORADOR);
            usuario.SetEntidadeId(command.UsuarioId);
            Veiculo veiculo = null;

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(command.UsuarioId))
               .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterVeiculoPorPlaca(command.Placa))
               .Returns(Task.FromResult(veiculo));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _veiculoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarVeiculo(It.IsAny<Veiculo>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Veiculo Invalido - Ja Cadastrado na Unidade")]
        [Trait("Categoria", "Veiculos - VeiculoCommandHandler")]
        public async Task AdicionarVeiculo_JaCadastradoNaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculo();
            var usuario = new Usuario("usuario", "sobrenome", "", null, null, null, TipoDeUsuario.MORADOR);
            usuario.SetEntidadeId(command.UsuarioId);
            Veiculo veiculo = new Veiculo(command.Placa, command.Modelo, command.Cor);
            veiculo.AdicionarVeiculoCondominio(new VeiculoCondominio(veiculo.Id, command.UnidadeId, command.CondominioId, command.UsuarioId));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(command.UsuarioId))
               .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterVeiculoPorPlaca(command.Placa))
               .Returns(Task.FromResult(veiculo));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _veiculoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarVeiculoCondominio(It.IsAny<VeiculoCondominio>()), Times.Once);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarVeiculo(It.IsAny<Veiculo>()), Times.Once);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Veiculo Invalido - Ja Cadastrado no condominio")]
        [Trait("Categoria", "Veiculos - VeiculoCommandHandler")]
        public async Task AdicionarVeiculo_JaCadastradoNoCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculo();
            var usuario = new Usuario("usuario", "sobrenome", "", null, null, null, TipoDeUsuario.MORADOR);
            usuario.SetEntidadeId(command.UsuarioId);
            Veiculo veiculo = new Veiculo(command.Placa, command.Modelo, command.Cor);
            veiculo.AdicionarVeiculoCondominio(new VeiculoCondominio(veiculo.Id, Guid.NewGuid(), command.CondominioId, command.UsuarioId));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(command.UsuarioId))
               .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterVeiculoPorPlaca(command.Placa))
               .Returns(Task.FromResult(veiculo));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _veiculoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarVeiculoCondominio(It.IsAny<VeiculoCondominio>()), Times.Once);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarVeiculo(It.IsAny<Veiculo>()), Times.Once);
            //_mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Veiculo - Em outro condominio")]
        [Trait("Categoria", "Veiculos - VeiculoCommandHandler")]
        public async Task AdicionarVeiculo_EmOutroCondominio_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculo();
            var usuario = new Usuario("usuario", "sobrenome", "", null, null, null, TipoDeUsuario.MORADOR);
            usuario.SetEntidadeId(command.UsuarioId);
            Veiculo veiculo = new Veiculo(command.Placa, command.Modelo, command.Cor);
            veiculo.AdicionarVeiculoCondominio(new VeiculoCondominio(veiculo.Id, Guid.NewGuid(), Guid.NewGuid(), command.UsuarioId));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(command.UsuarioId))
               .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterVeiculoPorPlaca(command.Placa))
               .Returns(Task.FromResult(veiculo));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _veiculoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarVeiculoCondominio(It.IsAny<VeiculoCondominio>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarVeiculo(It.IsAny<Veiculo>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Veiculo - Com Troca De Usuario")]
        [Trait("Categoria", "Veiculos - VeiculoCommandHandler")]
        public async Task AdicionarVeiculo_ComTrocaDeUsuario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculo();
            var usuario = new Usuario("usuario", "sobrenome", "", null, null, null, TipoDeUsuario.MORADOR);
            usuario.SetEntidadeId(command.UsuarioId);
            Veiculo veiculo = new Veiculo(command.Placa, command.Modelo, command.Cor);
            veiculo.AdicionarVeiculoCondominio(new VeiculoCondominio(veiculo.Id, command.UnidadeId, command.CondominioId, Guid.NewGuid()));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterPorId(command.UsuarioId))
               .Returns(Task.FromResult(usuario));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterVeiculoPorPlaca(command.Placa))
               .Returns(Task.FromResult(veiculo));

            _mocker.GetMock<IUsuarioRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _veiculoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AdicionarVeiculoCondominio(It.IsAny<VeiculoCondominio>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarVeiculo(It.IsAny<Veiculo>()), Times.Once);
            _mocker.GetMock<IUsuarioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}