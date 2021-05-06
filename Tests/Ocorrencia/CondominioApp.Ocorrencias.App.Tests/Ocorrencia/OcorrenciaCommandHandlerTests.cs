using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.Aplication.Commands;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class OcorrenciaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly OcorrenciaCommandHandler _ocorrenciaCommandCommandHandler;

        public OcorrenciaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _ocorrenciaCommandCommandHandler = _mocker.CreateInstance<OcorrenciaCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Ocorrencia Privada Válido")]
        [Trait("Categoria", "Ocorrencias - OcorrenciaCommandHandler")]
        public async Task AdicionarOcorrenciaPrivada_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = OcorrenciaCommandFactory.CriarComando_CadastroDeOcorrencia_Privada();          
           
            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _ocorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.Adicionar(It.IsAny<Ocorrencia>()), Times.Once);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
       


        [Fact(DisplayName = "Editar Ocorrencia - Privada - Pendente - Válido")]
        [Trait("Categoria", "Ocorrencias - OcorrenciaCommandHandler")]
        public async Task EditarOcorrencia_Privada_Pendente_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var ocorrencia = OcorrenciaFactoryTests.Criar_Ocorrencia_Valida();

            var command = OcorrenciaCommandFactory.CriarComando_EdicaoDeOcorrencia_Privada();

            ocorrencia.SetEntidadeId(command.Id);
                        

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(ocorrencia));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _ocorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.Atualizar(It.IsAny<Ocorrencia>()), Times.Once);
            _mocker.GetMock<IOcorrenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);

        }


        [Fact(DisplayName = "Editar Ocorrencia - Privada - Em Andamento - Inválido")]
        [Trait("Categoria", "Ocorrencias - OcorrenciaCommandHandler")]
        public async Task EditarOcorrencia_Privada_EmAndamento_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var ocorrencia = OcorrenciaFactoryTests.Criar_Ocorrencia_EmAndamento_Valido();

            var command = OcorrenciaCommandFactory.CriarComando_EdicaoDeOcorrencia_Privada();

            ocorrencia.SetEntidadeId(command.Id);


            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(ocorrencia));

            _mocker.GetMock<IOcorrenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _ocorrenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }


    }
}
