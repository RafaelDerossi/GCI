using System;
using Xunit;

namespace CondominioApp.ArquivoDigital.App.Tests
{
    public class PastaCommandTests
    {
        [Fact(DisplayName = "Adicionar Pasta Raíz - Válido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePastaRaiz();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Pasta Raíz Sem Título - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePasta_SemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePastaRaiz_SemTitulo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Pasta Raíz Sem CodominioId - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePasta_SemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePastaRaiz_SemCondominioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "Adicionar SubPasta - Válido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDeSubPasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDeSubPasta();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar SubPasta Sem Título - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDeSubPasta_SemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDeSubPasta_SemTitulo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar SubPasta Sem PastaMaeId - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDeSubPasta_SemPastaMaeId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDeSubPasta_SemPastaMaeId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Adicionar Pasta de Sistema - Válido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePastaDeSistema_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePastaDeSistema();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Pasta de Sistema Sem Tiutlo - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePastaDeSistema_SemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePastaDeSistema_SemTitulo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Pasta de Sistema Sem CodominioId - Inválido")]
        [Trait("Categoria", "CadastrarPastaCommand")]
        public void CadastroDePastaDeSistema_SemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_CadastroDePastaDeSistema_SemCondominioId();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Editar Pasta - Válido")]
        [Trait("Categoria", "EditarPastaCommand")]
        public void EdicaoDePasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_EdicaoDePasta();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Pasta Sem Titulo- Inválido")]
        [Trait("Categoria", "EditarPastaCommand")]
        public void EdicaoDePasta_SemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_EdicaoDePasta_SemTitulo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Marcar Como Pasta Publica - Válido")]
        [Trait("Categoria", "MarcarPastaComoPublicaCommand")]
        public void MarcarPastaComoPublica_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComandoMarcarPastaComoPublica();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Marcar Como Pasta Privada - Válido")]
        [Trait("Categoria", "MarcarPastaComoPrivadaCommand")]
        public void MarcarPastaComoPrivada_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComandoMarcarPastaComoPrivada();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Mover Pasta para raíz- Válido")]
        [Trait("Categoria", "EditarPastaCommand")]
        public void MoverPastaParaRaiz_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_MoverPastaParaRaiz();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Mover para SubPasta- Válido")]
        [Trait("Categoria", "EditarPastaCommand")]
        public void MoverParaSubPasta_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = PastaCommandFactory.CriarComando_MoverParaSubPasta();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }

    }
}