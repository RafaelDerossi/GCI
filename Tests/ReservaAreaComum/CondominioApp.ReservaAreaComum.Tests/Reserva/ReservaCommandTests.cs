using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.ReservaAreaComum.Tests
{
   public class ReservaCommandTests
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
        [Fact(DisplayName = "Adicionar Reserva Válida")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem areaComumId")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemAreaComumId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemAreaComumIdComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem unidadeId")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemUnidadeId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemUnidadeIdComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem Numero da Unidade")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemNumeroDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemNumeroDaUnidadeComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem Andar da Unidade")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemAndarDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemAndarDaUnidadeComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem Descricao do Grupo")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemDescricaoDoGrupo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemGrupoDaUnidadeComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem UsuarioId")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemUsuarioIdComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem Nome do Usuario")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemNomeDoUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemNomeDoUsuarioComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem Horario de Inicio")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemHoraDeInicio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemHoraInicioComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Com Horario de Inicio Invalido")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_ComHoraDeInicioInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaComHoraInicioInvalidoComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Sem Horario de Fim")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_SemHoraDeFim_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaSemHoraFimComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Reserva Inválida - Com Horario de Fim Invalido")]
        [Trait("Categoria", "Reserva - CadastrarCommand")]
        public void CadastroDeReserva_ComHoraDeFimInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ReservaCommandFactory.CriarComandoSolicitacaoDeReservaComHoraFimInvalidoComoMorador();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

    }
}
