using System;
using CondominioApp.Usuarios.App.Aplication.Commands;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandTests
    {
        [Fact(DisplayName = "Adicionar morador Válido")]
        [Trait("Categoria", "Usuario - Morador Command")]
        public void CadastroDeMorador_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeMorador();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar morador sem foto")]
        [Trait("Categoria", "Usuario - Morador Command sem foto")]
        public void CadastroDeMoradorSemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeMoradorSemFoto();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar morador sem data de nascimento")]
        [Trait("Categoria", "Usuario - Morador Command data de nascimento")]
        public void CadastroDeMoradorSemDataNascimento_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeMoradorSemDataDeNascimento();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar morador sem e-mail")]
        [Trait("Categoria", "Usuario - Morador Command sem e-mail")]
        public void CadastroDeMoradorSemEmail_CommandoValido_DeveNaoPassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeMoradorSemEmail();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar morador sem nome")]
        [Trait("Categoria", "Usuario - Morador Command sem nome")]
        public void CadastroDeMoradorSemNome_CommandoValido_DeveNaoPassarNaValidacao()
        {
            //Arrange
            var UsuarioCommand = UsuarioCommandFactory.CriarComandoCadastroDeMoradorSemNome();

            //Act
            var result = UsuarioCommand.EstaValido();

            //Assert
            Assert.False(result);
        }
    }
}