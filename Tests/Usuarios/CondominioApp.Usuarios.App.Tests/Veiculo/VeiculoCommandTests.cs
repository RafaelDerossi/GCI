using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class VeiculoCommandTests
    {
        [Fact(DisplayName = "Adicionar Veiculo Válido")]
        [Trait("Categoria", "Veiculo - CadastrarVeiculoCommand")]
        public void CadastroDeVeiculo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Adicionar Veiculo - Com Placa inválida")]
        [Trait("Categoria", "Veiculo - CadastrarVeiculoCommand")]
        public void CadastroDeVeiculo_ComPlacaInvalida_CommandoInvalido_NaoDeveNaoPassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculoComPlacaInvalida();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar Veiculo - Sem Placa")]
        [Trait("Categoria", "Veiculo - CadastrarVeiculoCommand")]
        public void CadastroDeVeiculo_SemPlaca_CommandoInvalido_NaoDeveNaoPassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculoSemPlaca();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar Veiculo - Sem Modelo")]
        [Trait("Categoria", "Veiculo - CadastrarVeiculoCommand")]
        public void CadastroDeVeiculo_SemModelo_CommandoInvalido_NaoDeveNaoPassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculoSemModelo();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }


        [Fact(DisplayName = "Adicionar Veiculo - Sem Cor")]
        [Trait("Categoria", "Veiculo - CadastrarVeiculoCommand")]
        public void CadastroDeVeiculo_SemCor_CommandoInvalido_NaoDeveNaoPassarNaValidacao()
        {
            //Arrange
            var command = VeiculoCommandFactory.CriarComandoCadastroDeVeiculoSemCor();

            //Act
            var result = command.EstaValido();

            //Assert
            Assert.False(result);
        }

    }
}