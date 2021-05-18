using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using CondominioApp.ArquivoDigital.App.Models;

namespace CondominioApp.ArquivoDigital.App.Tests
{
   public class PastaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly PastaCommandHandler _pastaCommandCommandHandler;

        public PastaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _pastaCommandCommandHandler = _mocker.CreateInstance<PastaCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Pasta Raíz Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task AdicionarPastaRaiz_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            var comando = PastaCommandFactory.CriarComando_CadastroDePastaRaiz();                        

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Adicionar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar SubPasta Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task AdicionarSubPasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            var comando = PastaCommandFactory.CriarComando_CadastroDeSubPasta();
            var pasta = PastaFactoryTests.Criar_Pasta_raiz_Valida();
            pasta.SetEntidadeId((Guid)comando.PastaMaeId);


            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId((Guid)comando.PastaMaeId))
               .Returns(Task.FromResult(pasta));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Adicionar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Pasta de Sistema Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task AdicionarPastaDeSistema_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            var comando = PastaCommandFactory.CriarComando_CadastroDePastaDeSistema();

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Adicionar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }



        [Fact(DisplayName = "Editar Pasta Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task EditarPasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = PastaCommandFactory.CriarComando_EdicaoDePasta();
            var pasta = PastaFactoryTests.Criar_Pasta_raiz_Valida();
            pasta.SetEntidadeId(comando.Id);           
            

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId(comando.Id))
               .Returns(Task.FromResult(pasta));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Atualizar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Marcar Pasta Como Publica Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task MarcarPastaComoPublica_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = PastaCommandFactory.CriarComandoMarcarPastaComoPublica();
            var pasta =PastaFactoryTests.Criar_Pasta_raiz_Valida();
            pasta.SetEntidadeId(comando.Id);
                       

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId(comando.Id))
               .Returns(Task.FromResult(pasta));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Atualizar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Marcar Pasta Como Privada Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task MarcarPastaComoPrivada_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = PastaCommandFactory.CriarComandoMarcarPastaComoPrivada();
            var pasta = PastaFactoryTests.Criar_Pasta_raiz_Valida();
            pasta.SetEntidadeId(comando.Id);


            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId(comando.Id))
               .Returns(Task.FromResult(pasta));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Atualizar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Mover Pasta para Raíz Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task MoverPastaParaRaiz_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = PastaCommandFactory.CriarComando_MoverPastaParaRaiz();
            var pasta = PastaFactoryTests.Criar_Pasta_raiz_Valida();
            pasta.SetEntidadeId(comando.Id);


            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId(comando.Id))
               .Returns(Task.FromResult(pasta));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Atualizar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Mover SubPasta Válido")]
        [Trait("Categoria", "Pasta - PastaCommandHandler")]
        public async Task MoverSubPasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = PastaCommandFactory.CriarComando_MoverParaSubPasta();
            var pasta = PastaFactoryTests.Criar_SubPasta_Valida();
            pasta.SetEntidadeId(comando.Id);
            var pastaMae = PastaFactoryTests.Criar_Pasta_raiz_Valida();
            pastaMae.SetEntidadeId((Guid)comando.PastaMaeId);

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId(comando.Id))
               .Returns(Task.FromResult(pasta));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId((Guid)comando.PastaMaeId))
               .Returns(Task.FromResult(pastaMae));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _pastaCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.Atualizar(It.IsAny<Pasta>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
