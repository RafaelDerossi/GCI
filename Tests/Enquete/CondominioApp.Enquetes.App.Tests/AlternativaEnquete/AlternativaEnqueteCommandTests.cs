using System;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    public class AlternativaEnqueteCommandTests
    {
        [Fact(DisplayName = "Editar AlternativaEnquete Válido")]
        [Trait("Categoria", "Enquete - AlterarAlternativaCommand")]
        public void EdicaoDeAlternativaDeEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = AlternativaEnqueteCommandFactory.CriarComandoEdicaoDeAlternativaEnquete();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

    }
}