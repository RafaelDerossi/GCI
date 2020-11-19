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
   public class UnidadeCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly UnidadeCommandHandler _unidadeCommandHandler;

        public UnidadeCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _unidadeCommandHandler = _mocker.CreateInstance<UnidadeCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Unidade Válido")]
        [Trait("Categoria", "Unidades - UnidadeCommandHandler")]
        public async Task AdicionarUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = UnidadeCommandFactory.CriarComandoCadastroDeUnidade();

            var grupo = new Grupo("Bloco 1", command.GrupoId);


            _mocker.GetMock<ICondominioRepository>().Setup(r => r.CondominioExiste(command.CondominioId))
              .Returns(Task.FromResult(true));

            _mocker.GetMock<ICondominioRepository>().Setup(r => r.ObterGrupoPorId(command.GrupoId))
              .Returns(Task.FromResult(grupo));           


            _mocker.GetMock<ICondominioRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _unidadeCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICondominioRepository>().Verify(r => r.AdicionarUnidade(It.IsAny<Unidade>()), Times.Once);
            _mocker.GetMock<ICondominioRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}
