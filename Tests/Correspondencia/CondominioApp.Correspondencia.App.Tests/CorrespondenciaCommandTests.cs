using System;
using Xunit;

namespace CondominioApp.Correspondencias.App.Tests
{
    public class CorrespondenciaCommandTests
    {
        [Fact(DisplayName = "Adicionar Correspondencia Válido")]
        [Trait("Categoria", "Correspondencia - CadastrarCorrespondenciaCommand")]
        public void CadastroDeCorrespondencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondencia();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Correspondencia Inválido - Sem Condominio")]
        [Trait("Categoria", "Correspondencia - CadastrarCorrespondenciaCommand")]
        public void CadastroDeCorrespondenciaSemCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondenciaSemCondominio();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Correspondencia Inválido - Sem UnidadeId")]
        [Trait("Categoria", "Correspondencia - CadastrarCorrespondenciaCommand")]
        public void CadastroDeCorrespondenciaSemUnidadeId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondenciaSemUnidadeId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Correspondencia Inválido - Sem Numero da Unidade")]
        [Trait("Categoria", "Correspondencia - CadastrarCorrespondenciaCommand")]
        public void CadastroDeCorrespondenciaSemNumeroUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondenciaSemNumeroUnidade();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Correspondencia Inválido - Sem Bloco")]
        [Trait("Categoria", "Correspondencia - CadastrarCorrespondenciaCommand")]
        public void CadastroDeCorrespondenciaSemBloco_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondenciaSemBloco();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Correspondencia Inválido - Sem UsuarioId")]
        [Trait("Categoria", "Correspondencia - CadastrarCorrespondenciaCommand")]
        public void CadastroDeCorrespondenciaSemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondenciaSemFuncionarioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Correspondencia Inválido - Sem Nome do Usuario")]
        [Trait("Categoria", "Correspondencia - CadastrarCorrespondenciaCommand")]
        public void CadastroDeCorrespondenciaSemNomeUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondenciaSemNomeFuncionario();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Marcar Correspondencia Vista Valido")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaVistaCommand")]
        public void MarcarCorrespondenciaVista_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaVista();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }




        [Fact(DisplayName = "Marcar Correspondencia Retirada Valido")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaRetiradaCommand")]
        public void MarcarCorrespondenciaRetirada_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaRetirada();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Marcar Correspondencia Retirada Invalido - Sem Nome do Retirante")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaRetiradaCommand")]
        public void MarcarCorrespondenciaRetiradaSemNomeDoRetirante_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaRetiradaSemNomeDoRetirante();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Marcar Correspondencia Retirada Invalido - Sem UsuarioId")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaRetiradaCommand")]
        public void MarcarCorrespondenciaRetiradaSemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaRetiradaSemUsuarioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Marcar Correspondencia Retirada Invalido - Sem Nome do Usuario")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaRetiradaCommand")]
        public void MarcarCorrespondenciaRetiradaSemNomeDoUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaRetiradaSemNomeDoUsuario();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Marcar Correspondencia Devolvida Valido")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaDevolvidaCommand")]
        public void MarcarCorrespondenciaDevolvida_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaDevolvida();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Marcar Correspondencia Devolvida Invalido - Sem UsuarioId")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaDevolvidaCommand")]
        public void MarcarCorrespondenciaDevolvidasemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaDevolvidaSemUsuarioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Marcar Correspondencia Devolvida Invalido - Sem Nome do Usuario")]
        [Trait("Categoria", "Correspondencia - MarcarCorrespondenciaDevolvidaCommand")]
        public void MarcarCorrespondenciaDevolvidasemNomeDoUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaDevolvidaSemNomeDoUsuario();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Disparar Alerta De Correspondencia Valido")]
        [Trait("Categoria", "Correspondencia - DispararAlertaDeCorrespondenciaCommand")]
        public void DispararAlertaDeCorrespondencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoDispararAlertaDeCorrespondencia();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }



        [Fact(DisplayName = "Gerar Excel De Correspondencia Valido")]
        [Trait("Categoria", "Correspondencia -GerarExcelCorrespondenciaCommand")]
        public void GerarExcelCorrespondencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandGerarExcelDeCorrespondencia();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }
    }

}