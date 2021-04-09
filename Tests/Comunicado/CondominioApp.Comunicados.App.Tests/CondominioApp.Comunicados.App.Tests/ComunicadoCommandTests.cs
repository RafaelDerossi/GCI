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
            var command = ComunicadoCommandFactory.CriarComando_CadastroDeComunicado_Publico();

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
            var command = ComunicadoCommandFactory.CriarComando_CadastroDeComunicado_Proprietario();

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
            var command = ComunicadoCommandFactory.CriarComando_CadastroDeComunicado_Unidade();

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
            var command = ComunicadoCommandFactory.CriarComando_CadastroDeComunicado_ProprietarioUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Comunicado Publico com descricao grande demais Inválido")]
        [Trait("Categoria", "Comunicado - CadastrarComunicadoCommand")]
        public void CadastroDeComunicadoPublico_DescricaoGrandeDemais_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComando_CadastroDeComunicado_ComDescricaoGrandeDemais();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "Editar Comunicado Publico Válido")]
        [Trait("Categoria", "Comunicado - EditarComunicadoCommand")]
        public void EdicaoDeComunicadoPublico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComando_EdicaoDeComunicado_Publico();

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
            var command = ComunicadoCommandFactory.CriarComando_EdicaoDeComunicado_Proprietario();

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
            var command = ComunicadoCommandFactory.CriarComando_EdicaoDeComunicado_Unidade();

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
            var command = ComunicadoCommandFactory.CriarComando_EdicaoDeComunicado_ProprietarioUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Comunicado Publico com descricao grande demais Inválido")]
        [Trait("Categoria", "Comunicado - EditarComunicadoCommand")]
        public void EdicaoDeComunicadoPublico_DescricaoGrandeDemais_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComando_EdicaoDeComunicado_ComDescricaoGrandeDemais();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }
    }

}