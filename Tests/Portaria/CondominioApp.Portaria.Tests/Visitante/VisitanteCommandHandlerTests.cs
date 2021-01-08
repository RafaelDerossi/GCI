using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.Portaria.Aplication.Commands;

namespace CondominioApp.Portaria.Tests
{
   public class VisitanteCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly VisitanteCommandHandler _visitanteCommandHandler;

        public VisitanteCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _visitanteCommandHandler = _mocker.CreateInstance<VisitanteCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Visitante Válido")]
        [Trait("Categoria", "Visitante -VisitanteCommandHandler")]
        public async Task AdicionarVisitante_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();           
         
            var command =   new CadastrarReservaCommand
                (areaComum.Id, "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);

            
            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(command.AreaComumId))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _visitanteCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.AdicionarReserva(It.IsAny<Reserva>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

       

    }
}
