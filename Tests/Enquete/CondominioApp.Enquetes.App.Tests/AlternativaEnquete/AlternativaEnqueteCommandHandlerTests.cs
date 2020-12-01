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
   public class AlternativaEnqueteCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly AlternativaEnqueteCommandHandler _alternativaEnqueteCommandCommandHandler;

        public AlternativaEnqueteCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _alternativaEnqueteCommandCommandHandler = _mocker.CreateInstance<AlternativaEnqueteCommandHandler>();
        }    


        [Fact(DisplayName = "Alterar AlternativaEnquete Válido")]
        [Trait("Categoria", "AlternativasEnquete - AlternativaEnqueteCommandHandler")]
        public async Task AlterarAlternativaEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = AlternativaEnqueteCommandFactory.CriarComandoAlteracaoDeAlternativaEnquete();

            var alternativa = new AlternativaEnquete("COM CERTEZA", Guid.NewGuid());
            

            var alternativas = new List<string>();
            alternativas.Add("SIM");
            alternativas.Add("NAO");
            var enquete = new Enquete(
                "Sim ou Nao", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", false, Guid.NewGuid(), "Nome do Usuario", alternativas);

            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.ObterAlternativaPorId(command.Id))
               .Returns(Task.FromResult(alternativa));

            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.ObterPorId(alternativa.EnqueteId))
                .Returns(Task.FromResult(enquete));

            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.UnitOfWork.Commit())
             .Returns(Task.FromResult(true));

            //Act
            var result = await _alternativaEnqueteCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.Atualizar(It.IsAny<Enquete>()), Times.Once);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
        
    }
}
