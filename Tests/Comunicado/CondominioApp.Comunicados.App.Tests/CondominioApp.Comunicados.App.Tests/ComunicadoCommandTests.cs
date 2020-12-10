using System;
using Xunit;

namespace CondominioApp.Comunicados.App.Tests
{
    public class ComunicadoCommandTests
    {
        [Fact(DisplayName = "Adicionar Comunicado Publico Válido")]
        [Trait("Categoria", "Comunicado - CadastrarComunicadoCommand")]
        public void CadastroDeComunicadoPublico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoPublico();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Comunicado Proprietario Válido")]
        [Trait("Categoria", "Comunicado - CadastrarComunicadoCommand")]
        public void CadastroDeComunicadoProprietario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoProprietario();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Comunicado Unidade Válido")]
        [Trait("Categoria", "Comunicado - CadastrarComunicadoCommand")]
        public void CadastroDeComunicadoUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Comunicado Proprietario-Unidade Válido")]
        [Trait("Categoria", "Comunicado - CadastrarComunicadoCommand")]
        public void CadastroDeComunicadoProprietarioUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoProprietarioUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }




        [Fact(DisplayName = "Editar Comunicado Publico Válido")]
        [Trait("Categoria", "Comunicado - EditarComunicadoCommand")]
        public void EdicaoDeComunicadoPublico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoPublico();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Comunicado Proprietario Válido")]
        [Trait("Categoria", "Comunicado - EditarComunicadoCommand")]
        public void EdicaoDeComunicadoProprietario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoProprietario();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Comunicado Unidade Válido")]
        [Trait("Categoria", "Comunicado - EditarComunicadoCommand")]
        public void EdicaoDeComunicadoUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Comunicado Proprietario-Unidade Válido")]
        [Trait("Categoria", "Comunicado - EditarComunicadoCommand")]
        public void EdicaoDeComunicadoProprietarioUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoProprietarioUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }


    }

}