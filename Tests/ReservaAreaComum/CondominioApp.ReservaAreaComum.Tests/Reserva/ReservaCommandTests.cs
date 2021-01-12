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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReserva();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemAreaComumId();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemUnidadeId();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemNumeroDaUnidade();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemAndarDaUnidade();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemGrupoDaUnidade();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemUsuarioId();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemNomeDoUsuario();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemHoraInicio();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaComHoraInicioInvalido();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaSemHoraFim();

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
            var Command = ReservaCommandFactory.CriarComandoCadastroDeReservaComHoraFimInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }
    }
}
