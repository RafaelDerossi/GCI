using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using CondominioApp.ArquivoDigital.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using FluentValidation.Results;
using System;

namespace CondominioApp.ArquivoDigital.App.Tests
{
   public class ArquivoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly ArquivoCommandHandler _arquivoCommandCommandHandler;        

        public ArquivoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _arquivoCommandCommandHandler = _mocker.CreateInstance<ArquivoCommandHandler>();            
        }

        [Fact(DisplayName = "Adicionar Arquivo Válido")]
        [Trait("Categoria", "Arquivo - ArquivoCommandHandler")]
        public async Task AdicionarArquivo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var pasta = PastaFactoryTests.Criar_Pasta_raiz_Valida();
            var comando = ArquivoCommandFactory.CriarComando_CadastroDeArquivo();
            pasta.SetEntidadeId(comando.PastaId);
            
            var retornoDoSubirArquivo = new ValidationResult();

            
            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId(comando.PastaId))
               .Returns(Task.FromResult(pasta));           

            _mocker.GetMock<IAzureStorageService>().Setup(r => r.SubirArquivo(comando.Arquivo, $"{pasta.CondominioId}/{comando.Id}.pdf"))
                .Returns(Task.FromResult(retornoDoSubirArquivo));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _arquivoCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.AdicionarArquivo(It.IsAny<Arquivo>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Editar Arquivo Válido")]
        [Trait("Categoria", "Arquivo - ArquivoCommandHandler")]
        public async Task EditarArquivo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var arquivo = ArquivoFactoryTests.Criar_Arquivo_Valido();
            var comando = ArquivoCommandFactory.CriarComando_EdicaoDeArquivo();
            arquivo.SetEntidadeId(comando.PastaId);

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterArquivoPorId(comando.Id))
               .Returns(Task.FromResult(arquivo));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _arquivoCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.AtualizarArquivo(It.IsAny<Arquivo>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Alterar Pasta do Arquivo Válido")]
        [Trait("Categoria", "Arquivo - ArquivoCommandHandler")]
        public async Task AlterarPastaDoArquivo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = ArquivoCommandFactory.CriarComando_EdicaoDeArquivo();
            var pasta = PastaFactoryTests.Criar_Pasta_raiz_Valida();
            pasta.SetEntidadeId(comando.PastaId);
            var arquivo = ArquivoFactoryTests.Criar_Arquivo_Valido();            
            arquivo.SetEntidadeId(comando.Id);

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterPorId(comando.PastaId))
              .Returns(Task.FromResult(pasta));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterArquivoPorId(comando.Id))
               .Returns(Task.FromResult(arquivo));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _arquivoCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.AtualizarArquivo(It.IsAny<Arquivo>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Marcar Arquivo Como Publico Válido")]
        [Trait("Categoria", "Arquivo - ArquivoCommandHandler")]
        public async Task MarcarArquivoComoPublico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = ArquivoCommandFactory.CriarComando_MarcarArquivoComoPublico();
            var arquivo = ArquivoFactoryTests.Criar_Arquivo_Valido();
            arquivo.SetEntidadeId(comando.Id);
                       

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterArquivoPorId(comando.Id))
               .Returns(Task.FromResult(arquivo));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _arquivoCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.AtualizarArquivo(It.IsAny<Arquivo>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Marcar Arquivo Como Privado Válido")]
        [Trait("Categoria", "Arquivo - ArquivoCommandHandler")]
        public async Task MarcarArquivoComoPrivado_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = ArquivoCommandFactory.CriarComando_MarcarArquivoComoPrivado();
            var arquivo = ArquivoFactoryTests.Criar_Arquivo_Valido();
            arquivo.SetEntidadeId(comando.Id);


            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.ObterArquivoPorId(comando.Id))
               .Returns(Task.FromResult(arquivo));

            _mocker.GetMock<IArquivoDigitalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _arquivoCommandCommandHandler.Handle(comando, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.AtualizarArquivo(It.IsAny<Arquivo>()), Times.Once);
            _mocker.GetMock<IArquivoDigitalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
