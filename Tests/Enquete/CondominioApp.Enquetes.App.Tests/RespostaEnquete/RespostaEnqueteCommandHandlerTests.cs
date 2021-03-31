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
   public class RespostaEnqueteCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly RespostaEnqueteCommandHandler _respostaEnqueteCommandCommandHandler;

        public RespostaEnqueteCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _respostaEnqueteCommandCommandHandler = _mocker.CreateInstance<RespostaEnqueteCommandHandler>();
        }    


        [Fact(DisplayName = "Cadastrar RespostaEnquete Válido")]
        [Trait("Categoria", "RespostaEnquete - RespostaEnqueteCommandHandler")]
        public async Task CadastrarRespostaEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnquete();

            var alternativa = new AlternativaEnquete("COM CERTEZA", 1);
            alternativa.SetEntidadeId(command.AlternativaId);
            
            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.ObterAlternativaPorId(command.AlternativaId))
               .Returns(Task.FromResult(alternativa));
                        
            _mocker.GetMock<IEnqueteRepository>().Setup(r => r.UnitOfWork.Commit())
             .Returns(Task.FromResult(true));

            //Act
            var result = await _respostaEnqueteCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.AdicionarResposta(It.IsAny<RespostaEnquete>()), Times.Once);
            _mocker.GetMock<IEnqueteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
        
    }
}
