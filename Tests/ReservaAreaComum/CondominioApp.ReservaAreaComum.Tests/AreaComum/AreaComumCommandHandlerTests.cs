using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Domain;

namespace CondominioApp.ReservaAreaComum.Tests
{
   public class AreaComumCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly AreaComumCommandHandler _areaComumCommandHandler;

        public AreaComumCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _areaComumCommandHandler = _mocker.CreateInstance<AreaComumCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AdicionarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum();

                     
            _mocker.GetMock<IAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.Adicionar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Editar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task EditarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum();

            _mocker.GetMock<IAreaComumRepository>().Setup(r => r.ObterPorId(command.AreaComumId))
                .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.Atualizar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Ativar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AtivarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            areaComum.DesativarAreaComun();

            var command = AreaComumCommandFactory.CriarComandoAtivacaoDeAreaComum();

            _mocker.GetMock<IAreaComumRepository>().Setup(r => r.ObterPorId(command.AreaComumId))
                .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.Atualizar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Desativar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task DesativarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            areaComum.AtivarAreaComun();

            var command = AreaComumCommandFactory.CriarComandoDesativacaoDeAreaComum();

            _mocker.GetMock<IAreaComumRepository>().Setup(r => r.ObterPorId(command.AreaComumId))
                .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.Atualizar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


    }
}
