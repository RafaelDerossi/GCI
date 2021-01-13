using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Portaria.Tests
{
   public class VisitaCommandTests
    {

        
        /// CadastrarCommand
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




        ///EditarVisitaCommand
        [Fact(DisplayName = "Editar Visita Válida - Com CPF")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_ComCpf_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Visita Inválida - Com CPF Inválido")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_ComCpfInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_ComCPFInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Visita Válida - Com RG")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_ComRG_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_ComRG();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Visita Válida - Sem Documento")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemDocumento_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemDocumento();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Visita Inválida - Sem UnidadeId")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemUnidadeId_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemUnidadeId();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Visita Inválida - Sem Numero da Unidade")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemNumeroDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemNumeroUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Visita Inválida - Sem Andar da Unidade")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemAndarDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemAndarUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Visita Inválida - Sem Grupo da Unidade")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemGrupoDaUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemGrupoUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Visita Válida - Sem Veiculo")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemVeiculo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemVeiculo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Visita Válida - Sem Placa")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemPlaca_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemPlaca();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }
        
        [Fact(DisplayName = "Editar Visita Inválida - Sem Modelo")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemModelo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemModelo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Visita Inválida - Sem Cor")]
        [Trait("Categoria", "Visita - EditarCommand")]
        public void EdicaoDeVisita_SemCor_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitaCommandFactory.CriarComandoEdicaoDeVisita_SemCor();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

    }
}
