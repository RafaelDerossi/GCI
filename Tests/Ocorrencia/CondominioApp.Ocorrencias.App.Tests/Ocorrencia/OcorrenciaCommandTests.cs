using System;
using Xunit;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class OcorrenciaCommandTests
    {
        [Fact(DisplayName = "Adicionar Ocorrencia - Válido")]
        [Trait("Categoria", "CadastrarOcorrenciaCommand")]
        public void CadastroDeOcorrencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_CadastroDeOcorrencia_Privada();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar Ocorrencia Sem Descrição - Inválido")]
        [Trait("Categoria", "CadastrarOcorrenciaCommand")]
        public void CadastroDeOcorrencia_SemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_CadastroDeOcorrencia_SemDescricao();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar Ocorrencia Sem Foto - Válido")]
        [Trait("Categoria", "CadastrarOcorrenciaCommand")]
        public void CadastroDeOcorrencia_SemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_CadastroDeOcorrencia_SemFoto();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar Ocorrencia Sem Unidade - Inválido")]
        [Trait("Categoria", "CadastrarOcorrenciaCommand")]
        public void CadastroDeOcorrencia_SemUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_CadastroDeOcorrencia_SemUnidade();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar Ocorrencia Sem Usuario - Inválido")]
        [Trait("Categoria", "CadastrarOcorrenciaCommand")]
        public void CadastroDeOcorrencia_SemUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_CadastroDeOcorrencia_SemUsuario();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "Editar Ocorrencia - Válido")]
        [Trait("Categoria", "EditarOcorrenciaCommand")]
        public void EdicaoDeOcorrencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_EdicaoDeOcorrencia_Privada();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Editar Ocorrencia Sem Descrição - Inválido")]
        [Trait("Categoria", "EditarOcorrenciaCommand")]
        public void EdicaoDeOcorrencia_SemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_EdicaoDeOcorrencia_SemDescricao();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Editar Ocorrencia Sem Foto - Válido")]
        [Trait("Categoria", "EditarOcorrenciaCommand")]
        public void EdicaoDeOcorrencia_SemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = OcorrenciaCommandFactory.CriarComando_EdicaoDeOcorrencia_SemFoto();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }

    }
}