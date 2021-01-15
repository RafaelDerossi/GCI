using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.Portaria.Aplication.Commands;
using CondominioApp.Portaria.Domain.Interfaces;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Aplication.Factories;

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

        [Fact(DisplayName = "Adicionar Visita Válida")]
        [Trait("Categoria", "Visita -VisitaCommandHandler")]
        public async Task AdicionarVisita_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_ComCPF();

            var visitante = VisitanteFactoryTest.CriarVisitanteValido_ComCPF();

            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.ObterPorId(command.VisitanteId))
               .Returns(Task.FromResult(visitante));           

            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _visitaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.AdicionarVisita(It.IsAny<Visita>()), Times.Once);
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.Atualizar(It.IsAny<Visitante>()), Times.Once);            
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Visita Válida - Visitante Novo")]
        [Trait("Categoria", "Visita -VisitaCommandHandler")]
        public async Task AdicionarVisita_VisitanteNovo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_VisitanteNovo();

            var visitante = VisitanteFactoryTest.CriarVisitanteValido_ComCPF();

            _mocker.GetMock<IVisitanteFactory>().Setup(r => r.Fabricar(command))
               .Returns(visitante);

            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.VisitanteJaCadastradoPorCpf(command.CpfVisitante, command.VisitanteId))
               .Returns(Task.FromResult(false));

            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.VisitanteJaCadastradoPorRg(command.RgVisitante, command.VisitanteId))
               .Returns(Task.FromResult(false));

            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _visitaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.Adicionar(It.IsAny<Visitante>()), Times.Once);
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
