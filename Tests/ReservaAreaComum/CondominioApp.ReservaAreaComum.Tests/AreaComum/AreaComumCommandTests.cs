using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.ReservaAreaComum.Tests
{
   public class AreaComumCommandTests
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
        [Fact(DisplayName = "Adicionar Area Comum Válido")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Sem Nome")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_SemNome_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_SemNome();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Sem CondominioId")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_SemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_SemCondominioId();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Sem Dias Permitidos")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_SemDiasPemitidos_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_SemDiasPermitidos();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Antecedencia Maxima Em Meses Inválida")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_AntecedenciaMaximaEmMesesInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmMesesInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Antecedencia Maxima Em Dias Inválida")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_AntecedenciaMaximaEmDiasInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmDiasInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Antecedencia Minima Invalida")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_AntecedenciaMinimaInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMinimaInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Antecedencia Minima Para Cancelamento Invalida")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Numero limite de reserva por unidade Invalido")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_NumeroLimiteDeReservaPorUnidadeInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaPorUnidadeInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Numero limite de reserva sobreposta Invalido")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Numero limite de reserva sobreposta por unidade Invalido")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Válido - Periodo Pernoite")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_PeriodoPernoite_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodoPernoite();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Periodo Sem Hora Inicio")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_PeriodoSemHoraInicio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodoSemHoraInicio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Periodo Com Hora Inicio Inválida")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_PeriodoComHoraInicioInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodoComHoraInicioInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Periodo Sem Hora Fim")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_PeriodoSemHoraFim_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodoSemHoraFim();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Periodo Com Hora Fim Inválida")]
        [Trait("Categoria", "Area Comum - CadastrarCommand")]
        public void CadastroDeAreaComum_PeriodoComHoraFimInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodoComHoraFimInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }


        /// <summary>
        /// EditarCommand
        /// </summary>
        [Fact(DisplayName = "Editar Area Comum Válido")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Sem Nome")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_SemNome_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum_SemNome();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Sem Dias Permitidos")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_SemDiasPermitidos_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum_SemDiasPermitidos();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Antecedencia Maxima Em Meses Invalida")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_AntecedenciaMaximaEmMesesInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmMesesInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Antecedencia Maxima Em Dias Invalida")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_AntecedenciaMaximaEmDiasInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmDiasInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Antecedencia Minima Invalida")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_AntecedenciaMinimaInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMinimaInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Antecedencia Minima Para Cancelamento Invalida")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Numero Limite de Reserva por Unidade Invalida")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_NumeroLimiteDeReservaInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaPorUnidadeInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Numero Limite de Reserva Sobreposta Invalida")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Numero Limite de Reserva Sobreposta por Unidade Invalida")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalida_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Válido - Periodo Pernoite")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_PeriodoPernoite_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum_PeriodoPernoite();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Periodo Sem Hora Inicio")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_PeriodoSemHoraInicio_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum_PeriodoSemHoraInicio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Periodo Com Hora Inicio Inválido")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_PeriodoComHoraInicioInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum_PeriodoComHoraInicioInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Periodo Sem Hora Fim")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_PeriodoSemHoraFim_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum_PeriodoSemHoraFim();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Area Comum Inválido - Periodo Com Hora Fim Inválido")]
        [Trait("Categoria", "Area Comum - EditarCommand")]
        public void EdicaoDeAreaComum_PeriodoComHoraFimInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = AreaComumCommandFactory.CriarComandoEdicaoDeAreaComum_PeriodoComHoraFimInvalida();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

    }
}
