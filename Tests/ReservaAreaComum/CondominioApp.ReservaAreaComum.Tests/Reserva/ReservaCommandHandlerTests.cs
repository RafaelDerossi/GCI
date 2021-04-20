using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy;

namespace CondominioApp.ReservaAreaComum.Tests
{
   public class ReservaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly ReservaCommandHandler _reservaCommandHandler;
        private readonly RegrasDeReserva _reagrasDeReserva;

        public ReservaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _reservaCommandHandler = _mocker.CreateInstance<ReservaCommandHandler>();
            _reagrasDeReserva = _mocker.CreateInstance<RegrasDeReserva>();
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
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaValidaMobile();
            reserva.SetAreaComumId(areaComum.Id);
            reserva.AguardarAprovacao("");
            areaComum.AdicionarReserva(reserva);

            var command = new AprovarReservaPelaAdministracaoCommand(reserva.Id);
            
            

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(command.Id))
               .Returns(Task.FromResult(reserva));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva.AreaComumId))
               .Returns(Task.FromResult(areaComum));

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
            reserva.SetAreaComumId(areaComum.Id);

            var command = new CancelarReservaComoUsuarioCommand
                (reserva.Id, "Justificativa");

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(reserva.Id))
              .Returns(Task.FromResult(reserva));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva.AreaComumId))
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
            reserva.SetAreaComumId(areaComum.Id);

            var command = new CancelarReservaComoAdministradorCommand
                (reserva.Id, "Justificativa");

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(reserva.Id))
              .Returns(Task.FromResult(reserva));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva.AreaComumId))
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
            reserva1.SetAreaComumId(areaComum.Id);
            reserva1.Cancelar("Justificativa");

            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            reserva2.SetAreaComumId(areaComum.Id);
            reserva2.EnviarParaFila("");

            areaComum.AdicionarReserva(reserva1);
            areaComum.AdicionarReserva(reserva2);

            var command = new RetirarReservaDaFilaCommand(reserva1.Id);

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(reserva1.Id))
              .Returns(Task.FromResult(reserva1));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva1.AreaComumId))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid && reserva2.Status != StatusReserva.NA_FILA);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
