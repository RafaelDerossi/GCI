using System;
using CondominioApp.Usuarios.App.Aplication.Commands;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MobileCommandTests
    {
        [Fact(DisplayName = "Adicionar mobile Válido")]
        [Trait("Categoria", "Mobile - CadastrarMobileCommand")]
        public void CadastroDeMobile_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = MobileCommandFactory.CriarComandoCadastroDeMobile();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar mobile Inválido - Sem DeviceKey")]
        [Trait("Categoria", "Mobile - CadastrarMobileCommand")]
        public void CadastroDeMobile_SemDeviceKey_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = MobileCommandFactory.CriarComandoCadastroDeMobile_SemDeviceKey();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar mobile Inválido - Sem MobileId")]
        [Trait("Categoria", "Mobile - CadastrarMobileCommand")]
        public void CadastroDeMobile_SemMobileId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = MobileCommandFactory.CriarComandoCadastroDeMobile_SemMobileId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar mobile Inválido - Sem UsuarioId")]
        [Trait("Categoria", "Mobile - CadastrarMobileCommand")]
        public void CadastroDeMobile_SemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = MobileCommandFactory.CriarComandoCadastroDeMobile_SemUsuarioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

    }
}