using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Principal.Tests
{
   public class CondominioCommandTests
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
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

        [Fact(DisplayName = "Adicionar Condominio Invalido - Com CNPJ Invalido")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Com CNPJ Invalido")]
        public void CadastroDeCondominioComCNPJInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioComCNPJInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);            
        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Com Telefone Invalido")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Com Telefone Invalido")]
        public void CadastroDeCondominioComTelefoneInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioComTelefoneInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Condominio Válido - Sem Contrato")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem Contrato")]
        public void CadastroDeCondominio_SemContrato_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemContrato();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);            
        }


        /// <summary>
        /// EditarCommand
        /// </summary>
        [Fact(DisplayName = "Editar Condominio Válido")]
        [Trait("Categoria", "Condominio - EditarCommand")]
        public void EdicaoDeCondominio_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoEdicaoDeCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Editar Condominio Inválido - Sem CNPJ")]
        [Trait("Categoria", "Condominio - EditarCommand - Sem CNPJ")]
        public void EdicaoDeCondominioSemCNPJ_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoEdicaoDeCondominioSemCNPJ();

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


        [Fact(DisplayName = "Editar Condominio Inválido - Com CNPJ Invalido")]
        [Trait("Categoria", "Condominio - EditarCommand - Com CNPJ Invalido")]
        public void EdicaoDeCondominioComCNPJInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoEdicaoDeCondominioComCNPJInvalido();

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

        [Fact(DisplayName = "Editar Condominio Inválido - Sem Nome")]
        [Trait("Categoria", "Condominio - EditarCommand - Sem Nome")]
        public void EdicaoDeCondominioSemNome_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoEdicaoDeCondominioSemNome();

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


        /// <summary>
        /// EdicaoConfiguracaoCommand
        /// </summary>
        [Fact(DisplayName = "Editar Configuracao de Condominio Válido")]
        [Trait("Categoria", "Condominio - EditarConfiguracaoCommand")]
        public void EdicaoDeConfiguracaoDeCondominio_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = CondominioCommandFactory.CriarComandoEdicaoDeConfiguracaoDoCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }
    }
}
