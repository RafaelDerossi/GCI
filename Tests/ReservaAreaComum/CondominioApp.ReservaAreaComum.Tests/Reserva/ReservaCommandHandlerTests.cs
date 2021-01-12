using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;

namespace CondominioApp.ReservaAreaComum.Tests
{
   public class ReservaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly ReservaCommandHandler _reservaCommandHandler;

        public ReservaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _reservaCommandHandler = _mocker.CreateInstance<ReservaCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Reserva Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task AdicionarReserva_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var command = ReservaCommandFactory.CriarComandoCadastroDeReserva();
            command.SetAreaComumId(areaComum.Id);

            
            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(command.AreaComumId))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.AdicionarReserva(It.IsAny<Reserva>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Aprovar Reserva Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task AprovarReserva_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = new AprovarReservaCommand(Guid.NewGuid());

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(command.Id))
               .Returns(Task.FromResult(ReservaFactory.CriarReservaValidaMobile()));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);            
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Cancelar Reserva Como Usuario Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task CancelarReserva_ComoUsuario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile();
            areaComum.AdicionarReserva(reserva);

            var command = new CancelarReservaComoUsuarioCommand
                (reserva.Id, "Justificativa");

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.Obter_AreaComumId_Por_ReservaId(reserva.Id))
              .Returns(Task.FromResult(areaComum.Id));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(areaComum.Id))
               .Returns(Task.FromResult(areaComum));           

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);           
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Cancelar Reserva Como Administrador Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task CancelarReserva_ComoAdministrador_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile();
            areaComum.AdicionarReserva(reserva);

            var command = new CancelarReservaComoAdministradorCommand
                (reserva.Id, "Justificativa");

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.Obter_AreaComumId_Por_ReservaId(reserva.Id))
              .Returns(Task.FromResult(areaComum.Id));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(areaComum.Id))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Retirar Reserva da Fila Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task RetirarReservaDaFila_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();              
            reserva1.Cancelar("Justificativa");

            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            reserva2.EnviarParaFila();

            areaComum.AdicionarReserva(reserva1);
            areaComum.AdicionarReserva(reserva2);

            var command = new RetirarReservaDaFilaCommand(reserva1.Id);

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.Obter_AreaComumId_Por_ReservaId(reserva1.Id))
              .Returns(Task.FromResult(areaComum.Id));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(areaComum.Id))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid && !reserva2.EstaNaFila);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
