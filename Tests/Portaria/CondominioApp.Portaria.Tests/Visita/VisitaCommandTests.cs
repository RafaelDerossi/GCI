using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Portaria.Tests
{
   public class VisitaCommandTests
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
        [Fact(DisplayName = "Adicionar Visita Válida - Na portaria com CPF")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_NaPortaria_ComCpf_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita inválida - Com CPF Inválido")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_ComCpfInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_ComCPFInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Morador com CPF")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_Morador_ComCpf_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_Morador_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Na portaria com RG")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_NaPortaria_ComRg_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_ComRG();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Na portaria sem documento")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_NaPortaria_SemDocumento_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_SemDocumento();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Na portaria visitante novo")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_NaPortaria_VisitanteNovo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_VisitanteNovo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Na portaria visitante de servico")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_NaPortaria_VisitanteServico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_NaPortaria_VisitaDeServico();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Sem condominioId")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_SemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_SemCondominioId();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Sem nome do condominio")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_SemNomeDoCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_SemNomeDoCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Sem unidadeId")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_SemUnidadeId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_SemUnidadeId();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Sem numero da unidade")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_SemNumeroDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_SemNumeroUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Sem andar da unidade")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_SemAndarDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_SemAndarUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Sem Grupo da unidade")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_SemGrupoDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_SemGrupoUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Sem Veiculo")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_SemVeiculo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_SemVeiculo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita Válida - Com Veiculo sem placa")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_ComVeiculoSemPlaca_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_ComVeiculoSemPlaca();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Com Veiculo sem modelo")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_ComVeiculoSemModelo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_ComVeiculoSemModelo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visita Inválida - Com Veiculo sem cor")]
        [Trait("Categoria", "Visita - CadastrarCommand")]
        public void CadastroDeVisita_ComVeiculoSemCor_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoCadastroDeVisita_ComVeiculoSemCor();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }


    }
}
