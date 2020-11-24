using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Principal.Tests
{
   public class UnidadeCommandTests
    {
        [Fact(DisplayName = "Adicionar Unidade Válido")]
        [Trait("Categoria", "Unidade - CadastrarCommand")]
        public void CadastroDeUnidade_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoCadastroDeUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Unidade Inválido")]
        [Trait("Categoria", "Unidade - CadastrarCommand")]
        public void CadastroDeUnidadeSemNumero_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoCadastroDeUnidadeSemNumero();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Unidade Inválido")]
        [Trait("Categoria", "Unidade - CadastrarCommand")]
        public void CadastroDeUnidadeSemAndar_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoCadastroDeUnidadeSemAndar();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Unidade Inválido")]
        [Trait("Categoria", "Unidade - CadastrarCommand")]
        public void CadastroDeUnidadeSemGrupo_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoCadastroDeUnidadeSemGrupo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

       
    }
}
