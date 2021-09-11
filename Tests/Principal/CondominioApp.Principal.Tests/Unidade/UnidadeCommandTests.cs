using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Principal.Tests
{
   public class UnidadeCommandTests
    {

        //Cadastro
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

        [Fact(DisplayName = "Adicionar Unidade Inválido - Sem Numero")]
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

        [Fact(DisplayName = "Adicionar Unidade Inválido - Sem Andar")]
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

        [Fact(DisplayName = "Adicionar Unidade Inválido - Sem Grupo")]
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

        [Fact(DisplayName = "Adicionar Unidade Válido - Sem Telefone")]
        [Trait("Categoria", "Unidade - CadastrarCommand")]
        public void CadastroDeUnidadeSemTelefone_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoCadastroDeUnidadeSemTelefone();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }


        //Edicao
        [Fact(DisplayName = "Editar Unidade Válido")]
        [Trait("Categoria", "Unidade - EditarCommand")]
        public void EdicaoDeUnidade_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoEdicaoDeUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Unidade Inválido - Sem Numero")]
        [Trait("Categoria", "Unidade - EditarCommand")]
        public void EdicaoDeUnidadeSemNumero_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoEdicaoDeUnidadeSemNumero();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Unidade Inválido - Sem Andar")]
        [Trait("Categoria", "Unidade - EditarCommand")]
        public void EdicaoDeUnidadeSemAndar_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoEdicaoDeUnidadeSemAndar();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Unidade Válido - Sem Telefone")]
        [Trait("Categoria", "Unidade - EditarCommand")]
        public void EdicaoDeUnidadeSemTelefone_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = UnidadeCommandFactory.CriarComandoEdicaoDeUnidadeSemTelefone();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }


    }
}
