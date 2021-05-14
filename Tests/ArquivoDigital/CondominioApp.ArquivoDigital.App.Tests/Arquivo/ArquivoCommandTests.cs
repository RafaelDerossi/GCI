using System;
using Xunit;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class ArquivoCommandTests
    {
        [Fact(DisplayName = "Adicionar Arquivo - Válido")]
        [Trait("Categoria", "CadastrarArquivoCommand")]
        public void CadastroDeArquivo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ArquivoCommandFactory.CriarComando_CadastroDeArquivo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Arquivo Com NomeOriginal Sem Extensao - Inválido")]
        [Trait("Categoria", "CadastrarArquivoCommand")]
        public void CadastroDeArquivo_ComNomeOriginalSemExtensao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = ArquivoCommandFactory.CriarComando_CadastroDeArquivo_NomeOroginalDoArquivoSemExtensao();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Arquivo Sem NomeOriginal - Inválido")]
        [Trait("Categoria", "CadastrarArquivoCommand")]
        public void CadastroDeArquivo_SemNomeOriginal_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = ArquivoCommandFactory.CriarComando_CadastroDeArquivo_SemNomeArquivo();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Arquivo Sem Tamanho - Inválido")]
        [Trait("Categoria", "CadastrarArquivoCommand")]
        public void CadastroDeArquivo_SemTamanho_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = ArquivoCommandFactory.CriarComando_CadastroDeArquivo_SemTamanho();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }        

        [Fact(DisplayName = "Adicionar Arquivo Sem PastaId - Inválido")]
        [Trait("Categoria", "CadastrarArquivoCommand")]
        public void CadastroDeArquivo_SemPastaId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = ArquivoCommandFactory.CriarComando_CadastroDeArquivo_SemPastaId();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "Editar Arquivo - Válido")]
        [Trait("Categoria", "EditarArquivoCommand")]
        public void EdicaoDeArquivo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ArquivoCommandFactory.CriarComando_EdicaoDeArquivo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        


        [Fact(DisplayName = "Alterar Pasta do Arquivo - Válido")]
        [Trait("Categoria", "AlterarPastaDoArquivoCommand")]
        public void AlteracaoDaPastaDoArquivo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ArquivoCommandFactory.CriarComando_AlterarPastaDoArquivo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Alterar Pasta do Arquivo Sem PastaId- Inválido")]
        [Trait("Categoria", "AlterarPastaDoArquivoCommand")]
        public void AlteracaoDaPastaDoArquivo_SemPastaId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ArquivoCommandFactory.CriarComando_AlterarPastaDoArquivo_SemPastaId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Marcar Arquivo Como Publico - Válido")]
        [Trait("Categoria", "MarcarArquivoComoPublicoCommand")]
        public void MarcacaoDoArquivoComoPublico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ArquivoCommandFactory.CriarComando_MarcarArquivoComoPublico();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Marcar Arquivo Como Privado - Válido")]
        [Trait("Categoria", "MarcarArquivoComoPublicoCommand")]
        public void MarcacaoDoArquivoComoPrivado_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ArquivoCommandFactory.CriarComando_MarcarArquivoComoPrivado();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

    }
}