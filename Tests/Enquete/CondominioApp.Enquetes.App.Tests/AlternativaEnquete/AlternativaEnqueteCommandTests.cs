using System;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    public class AlternativaEnqueteCommandTests
    {
        [Fact(DisplayName = "Alterar AlternativaEnquete Válido")]
        [Trait("Categoria", "Enquete - AlterarAlternativaCommand")]
        public void AlteracaoDeAlternativaDeEnquete_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = AlternativaEnqueteCommandFactory.CriarComandoAlteracaoDeAlternativaEnquete();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

    }
}