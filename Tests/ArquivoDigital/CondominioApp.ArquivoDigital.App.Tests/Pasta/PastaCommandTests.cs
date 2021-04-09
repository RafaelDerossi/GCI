using System;
using Xunit;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class PastaCommandTests
    {
        [Fact(DisplayName = "Adicionar Pasta - Válido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePasta();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Pasta Sem Tiutlo - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePasta_SemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePasta_SemTitulo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Pasta Sem CodominioId - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePasta_SemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePasta_SemCondominioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "Editar Pasta - Válido")]
        [Trait("Categoria", "EditarPastaCommand")]
        public void EdicaoDePasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_EdicaoDePasta();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Pasta Sem Titulo- Inválido")]
        [Trait("Categoria", "EditarPastaCommand")]
        public void EdicaoDePasta_SemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_EdicaoDePasta_SemTitulo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Marcar Como Pasta Publica - Válido")]
        [Trait("Categoria", "MarcarPastaComoPublicaCommand")]
        public void MarcarPastaComoPublica_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComandoMarcarPastaComoPublica();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Marcar Como Pasta Privada - Válido")]
        [Trait("Categoria", "MarcarPastaComoPrivadaCommand")]
        public void MarcarPastaComoPrivada_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComandoMarcarPastaComoPrivada();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

    }
}