using System;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    public class EnqueteCommandTests
    {
        [Fact(DisplayName = "Adicionar Enquete Válido")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnquete();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Enquete - Com Menos de Duas Alternativas")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnqueteComMenosDeDuasAlternativas_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnqueteComMenosDeDuasAlternativas();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Enquete - Sem Alternativas")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnqueteSemAlternativas_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnqueteSemAlternativas();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Enquete - Ja Terminada")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnqueteJaTerminada_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnqueteJaTerminada();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Enquete - Com Data Inicial Posterior a Final")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnqueteComDataInicialPosteriorAFinal_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnqueteComDataInicialPosteriorAFinal();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Enquete - Sem Descricao")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnqueteSemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnqueteSemDescricao();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Enquete - Sem CondominioId")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnqueteSemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnqueteSemCondominioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }
       

        [Fact(DisplayName = "Adicionar Enquete - Sem UsuarioId")]
        [Trait("Categoria", "Enquete - CadastrarEnqueteCommand")]
        public void CadastroDeEnqueteSemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoCadastroDeEnqueteSemFuncionarioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }       

        [Fact(DisplayName = "Editar Enquete Valido")]
        [Trait("Categoria", "Enquete - EditarEnqueteCommand")]
        public void EdicaoDeEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = EnqueteCommandFactory.CriarComandoEdicaoDeEnquete();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }
    }
}