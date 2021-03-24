using System;
using Xunit;

namespace CondominioApp.Ocorrencias.App.Tests
{
    public class RespostaOcorrenciaCommandTests
    {
        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Sindico - Válido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Sindico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaSindico();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Sindico - Sem Descricao - Inválido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Sindico_SemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaSindico_SemDescricao();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Sindico - Sem Usuario - Inválido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Sindico_SemUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaSindico_SemUsuario();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Sindico - Sem Foto - Válido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Sindico_SemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaSindico_SemFoto();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Sindico - Resolvido - Válido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Sindico_Resolvido_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaSindico_Resolvido();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }




        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Morador - Válido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Morador_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaMorador();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Morador - Sem Descricao - Inválido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Morador_SemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaMorador_SemDescricao();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Morador - Sem Usuario - Inválido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Morador_SemUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaMorador_SemUsuario();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar RespostaOcorrencia - Morador - Sem Foto - Válido")]
        [Trait("Categoria", "CadastrarRespostaOcorrenciaCommand")]
        public void CadastroDeRespostaOcorrencia_Morador_SemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var comando = RespostaOcorrenciaCommandFactory.CriarComando_CadastroDeRespostaOcorrenciaMorador_SemFoto();

            //Act
            var result = comando.EstaValido();

            //Assert
            Assert.True(result);
        }
    }
}