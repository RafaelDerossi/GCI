using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Domain;
using CondominioApp.Core.ValueObjects;
using System;

namespace CondominioApp.Principal.Tests
{
   public class CondominioCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly CondominioCommandHandler _condominioCommandHandler;

        public CondominioCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _condominioCommandHandler = _mocker.CreateInstance<CondominioCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Condominio Válido")]
        [Trait("Categoria", "Condominios - CondominioCommandHandler")]
        public async Task AdicionarCondominio_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CondominioCommandFactory.CriarComandoCadastroDeCondominio();

            _mocker.GetMock<ICondominioRepository>().Setup(r => r.CnpjCondominioJaCadastrado(command.Cnpj, command.CondominioId))
                .Returns(Task.FromResult(false)); 
                

           
            _mocker.GetMock<ICondominioRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _condominioCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICondominioRepository>().Verify(r => r.Adicionar(It.IsAny<Condominio>()), Times.Once);
            _mocker.GetMock<ICondominioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}
