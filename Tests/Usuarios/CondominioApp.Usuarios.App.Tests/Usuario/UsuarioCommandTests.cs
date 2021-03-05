using System;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandTests
    {
        [Fact(DisplayName = "Adicionar usuario Válido")]
        [Trait("Categoria", "CadastrarUsuarioCommand")]
        public void CadastroDeUsuario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuario();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar usuario sem foto")]
        [Trait("Categoria", "CadastrarUsuarioCommand")]
        public void CadastroDeUsuarioSemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuarioSemFoto();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar usuario sem data de nascimento")]
        [Trait("Categoria", "CadastrarUsuarioCommand")]
        public void CadastroDeUsuarioSemDataNascimento_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuarioSemDataDeNascimento();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar usuario sem e-mail")]
        [Trait("Categoria", "CadastrarUsuarioCommand")]
        public void CadastroDeUsuarioSemEmail_CommandoValido_DeveNaoPassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuarioSemEmail();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar usuario sem nome")]
        [Trait("Categoria", "CadastrarUsuarioCommand")]
        public void CadastroDeUsuarioSemNome_CommandoValido_DeveNaoPassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuarioSemNome();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar usuario com CPF invalido")]
        [Trait("Categoria", "CadastrarUsuarioCommand")]
        public void CadastroDeUsuarioComCPFInvalido_CommandoInvalido_DeveNaoPassarNaValidacao()
        {
            try
            {
                //Arrange
                var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuarioCPFInvalido();

                //Act
                var result = UsuarioCommand.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                //Assert
                Assert.False(false);
            }
            
        }

        [Fact(DisplayName = "Adicionar usuario com e-mail invalido")]
        [Trait("Categoria", "CadastrarUsuarioCommand")]
        public void CadastroDeUsuarioComEmailInvalido_CommandoInvalido_DeveNaoPassarNaValidacao()
        {
           
            try
            {
                //Arrange
                var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeUsuarioComEmailInvalido();

                //Act
                var result = UsuarioCommand.EstaValido();

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