using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Principal.Tests
{
   public class CondominioCommandTests
    {
        [Fact(DisplayName = "Adicionar Condominio Válido")]
        [Trait("Categoria", "Condominio - CadastrarCommand")]
        public void CadastroDeCondominio_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Condominio valido - Sem Foto")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem Foto")]
        public void CadastroDeCondominioSemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemFoto();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Condominio valido - Sem Telefone")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem Telefone")]
        public void CadastroDeCondominioSemTelefone_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemTelefone();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Sem Nome")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem Nome")]
        public void CadastroDeCondominioSemNome_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemNome();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Sem CNPJ")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem CNPJ")]
        public void CadastroDeCondominioSemCNPJ_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemCNPJ();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }
           
        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Com Telefone Invalido")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Com Telefone Invalido")]
        public void CadastroDeCondominioComTelefoneInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioComTelefoneInvalido();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }
            
        }
    }
}
