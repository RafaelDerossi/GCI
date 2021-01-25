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

        [Fact(DisplayName = "Adicionar Visitante Válido - CPF")]
        [Trait("Categoria", "Visitante -VisitanteCommandHandler")]
        public async Task AdicionarVisitante_Cpf_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitanteCommandFactory.CriarComandoCadastroDeVisitantePorMorador_ComCPF();

            var visitante = VisitanteFactoryTest.CriarVisitanteValido_ComCPF();            

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

        [Fact(DisplayName = "Adicionar Visitante Válido - RG")]
        [Trait("Categoria", "Visitante -VisitanteCommandHandler")]
        public async Task AdicionarVisitante_RG_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_ComRG();

            var visitante = VisitanteFactoryTest.CriarVisitanteValido_ComRG();
            
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

        [Fact(DisplayName = "Adicionar Visitante Válido - Sem Documento")]
        [Trait("Categoria", "Visitante -VisitanteCommandHandler")]
        public async Task AdicionarVisitante_SemDocumento_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemDocumento();

            var visitante = VisitanteFactoryTest.CriarVisitanteValido_SemDocumento();

            
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

        [Fact(DisplayName = "Adicionar Visitante Válido - Sem Veiculo")]
        [Trait("Categoria", "Visitante -VisitanteCommandHandler")]
        public async Task AdicionarVisitante_SemVeiculo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemVeiculo();

            var visitante = VisitanteFactoryTest.CriarVisitanteValido_SemVeiculo();

            
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



        [Fact(DisplayName = "Editar Visitante Válido")]
        [Trait("Categoria", "Visitante -VisitanteCommandHandler")]
        public async Task EditarVisitante_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange        
            var command = VisitanteCommandFactory.CriarComandoEdicaoDeVisitantePorMorador_ComCPF();

            var visitante = VisitanteFactoryTest.CriarVisitanteValido_ComCPF();

            _mocker.GetMock<IVisitanteRepository>().Setup(r => r.ObterPorId(command.Id))
              .Returns(Task.FromResult(visitante));

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
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.Atualizar(It.IsAny<Visitante>()), Times.Once);
            _mocker.GetMock<IVisitanteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
