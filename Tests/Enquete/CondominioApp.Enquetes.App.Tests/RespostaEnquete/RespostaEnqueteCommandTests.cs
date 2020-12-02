using System;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    public class RespostaEnqueteCommandTests
    {
        [Fact(DisplayName = "Cadastrar RespostaEnquete Válido")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnquete();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Cadastrar RespostaEnquete Sem UnidadeId")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnqueteSemUnidadeId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnqueteSemUnidadeId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Cadastrar RespostaEnquete Sem Unidade")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnqueteSemUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnqueteSemUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Cadastrar RespostaEnquete Sem Bloco")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnqueteSemBloco_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnqueteSemBloco();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Cadastrar RespostaEnquete Sem UsuarioId")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnqueteSemUsusarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnqueteSemUsuarioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Cadastrar RespostaEnquete Sem Usuario")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnqueteSemUsusario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnqueteSemUsuario();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Cadastrar RespostaEnquete Sem Tipo Usuario")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnqueteSemTipoUsusario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnqueteSemTipoDeUsuario();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Cadastrar RespostaEnquete Sem AlternativaId")]
        [Trait("Categoria", "RespostaEnquete - CadastrarRespostaCommand")]
        public void CadastroDeRespostaEnqueteSemAlternativaId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = RespostaEnqueteCommandFactory.CriarComandoCadastrarRespostaEnqueteSemAlternativaId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }
    }
}