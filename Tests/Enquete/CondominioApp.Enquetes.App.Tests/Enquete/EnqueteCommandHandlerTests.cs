using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.Models;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
   public class EnqueteCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly EnqueteCommandHandler _enqueteCommandCommandHandler;

        public EnqueteCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _enqueteCommandCommandHandler = _mocker.CreateInstance<EnqueteCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Enquete Válido")]
        [Trait("Categoria", "Enquetes - EnqueteCommandHandler")]
        public async Task AdicionarEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnquete();          
           
            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _enqueteCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.Adicionar(It.IsAny<Enquete>()), Times.Once);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Editar Enquete Válido")]
        [Trait("Categoria", "Enquetes - EnqueteCommandHandler")]
        public async Task EditarEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoEdicaoDeEnquete();           
            
            var enquete = new Enquete(
                "Sim ou Nao", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", false, Guid.NewGuid(), "Nome do Usuario");


            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(enquete));

            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.UnitOfWork.Commit())
             .Returns(Task.FromResult(true));

            //Act
            var result = await _enqueteCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.Atualizar(It.IsAny<Enquete>()), Times.Once);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
        
    }
}
