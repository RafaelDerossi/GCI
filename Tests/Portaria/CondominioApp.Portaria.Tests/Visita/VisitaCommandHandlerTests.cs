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
   public class VisitaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly VisitaCommandHandler _visitaCommandHandler;

        public VisitaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _visitaCommandHandler = _mocker.CreateInstance<VisitaCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Porteiro")]
        [Trait("Categoria", "Visita -VisitaCommandHandler")]
        public async Task AdicionarVisita_Porteiro_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria();
            var visitante = VisitanteFactoryTest.CriarVisitanteValido_ComCPF();            
            visitante.SetEntidadeId(command.VisitanteId);

            _mocker.GetMock<IPortariaRepository>().Setup(r => r.ObterPorId(command.VisitanteId))
               .Returns(Task.FromResult(visitante));

            _mocker.GetMock<IPortariaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _visitaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPortariaRepository>().Verify(r => r.AdicionarVisita(It.IsAny<Visita>()), Times.Once);                       
            _mocker.GetMock<IPortariaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Visita Válida -Porteiro - Visitante Novo")]
        [Trait("Categoria", "Visita -VisitaCommandHandler")]
        public async Task AdicionarVisita_Porteiro_VisitanteNovo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_VisitanteNovo();
            var visitante = VisitanteFactoryTest.CriarVisitanteValido_ComCPF();
            visitante.SetEntidadeId(command.VisitanteId);

            _mocker.GetMock<IPortariaRepository>().Setup(r => r.ObterPorId(command.VisitanteId))
               .Returns(Task.FromResult(visitante));


            _mocker.GetMock<IPortariaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _visitaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPortariaRepository>().Verify(r => r.AdicionarVisita(It.IsAny<Visita>()), Times.Once);
            _mocker.GetMock<IPortariaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
