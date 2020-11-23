using System.ComponentModel;
using Xunit;

namespace CondominioAppMarketplace.Tests.Domain
{
    public class PaceiroTests
    {
        [Fact(DisplayName = "Parceiro Pre Cadastro Válido")]
        [Trait("Categoria", "Parceiros - Pré Cadastro válido")]
        public void Criar_parceiro_pre_cadastro_valido()
        {
            //Arrange
            var paceiro = ParceiroFactory.CriarParceiroPrecadastro();

            //act
            var result = paceiro.Validar();

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Parceiro Cadastro Válido")]
        [Trait("Categoria", "Parceiros - Cadastro válido")]
        public void Criar_parceiro_cadastro_valido()
        {
            //Arrange
            var paceiro = ParceiroFactory.CriarParceiroCadastroEfetivo();

            //act
            var result = paceiro.Validar();

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Parceiro nome e sobrenome")]
        [Trait("Categoria", "Parceiros - Nome")]
        public void ObterNome_valido()
        {
            //Arrange
            var paceiro = ParceiroFactory.CriarParceiroCadastroEfetivo();

            //act
            var nome = paceiro.Nome;

            //assert
            Assert.True(nome == "Alexandre");
        }

        [Fact(DisplayName = "Parceiro contratar vendedor")]
        [Trait("Categoria", "Parceiros - contratar vendedor")]
        public void Contratar_vendedor_deveEstarValido()
        {
            //Arrange
            var parceiro = ParceiroFactory.CriarParceiroCadastroEfetivo();
            var vendedor = VendedorFactory.CriarVendedorValido();

            //act
            var result = parceiro.Contratar(vendedor);
            
            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Parceiro contratar vendedor duplicado")]
        [Trait("Categoria", "Parceiros - contratar vendedor duplicado")]
        public void Contratar_vendedor_naoDeveEstarValido()
        {
            //Arrange
            var parceiro = ParceiroFactory.CriarParceiroCadastroEfetivo();
            var vendedor = VendedorFactory.CriarVendedorValido();
            var vendedor2 = VendedorFactory.CriarVendedorValido();
            var result = parceiro.Contratar(vendedor);

            //act
            var resultFinal = parceiro.Contratar(vendedor2);

            //assert
            Assert.False(resultFinal.IsValid);
        }
    }
}