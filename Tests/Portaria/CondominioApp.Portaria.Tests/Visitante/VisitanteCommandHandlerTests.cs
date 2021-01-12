using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.Portaria.Aplication.Commands;
using CondominioApp.Portaria.Domain.Interfaces;
using CondominioApp.Portaria.Domain;

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
            var command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_ComCPF();
                        
            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.VisitanteJaCadastradoPorCpf(command.Cpf, command.Id))
               .Returns(Task.FromResult(false));
            
            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.VisitanteJaCadastradoPorRg(command.Rg, command.Id))
               .Returns(Task.FromResult(false));

            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _visitanteCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.Adicionar(It.IsAny<Visitante>()), Times.Once);
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

       

    }
}
