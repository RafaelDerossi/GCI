using System;
using Xunit;

namespace CondominioAppMarketplace.Tests.Domain
{
    public class CampanhaTests
    {
        [Fact(DisplayName = "Campanha Cadastro válida")]
        [Trait("Categoria", "Campanhas - Cadastro válido")]
        public void Criar_campanha_cadastro_valido()
        {
            //Arrange
            var campanha = CampanhaFactory.CriarCampanhaValida();

            //act
            var result = campanha.Validar();

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Campanha Cadastro Inválida")]
        [Trait("Categoria", "Campanhas - Cadastro Inválido")]
        public void Criar_campanha_cadastro_invalido()
        {
            //Arrange
            var campanha = CampanhaFactory.CriarCampanhaInValida();

            //act
            var result = campanha.Validar();

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Campanha intervalo válido")]
        [Trait("Categoria", "Campanhas - intervalo válido")]
        public void Configuracao_de_intervalo_valido()
        {
            //Arrange
            var campanha = CampanhaFactory.CriarCampanhaInValida();

            //act
            var result = campanha.ConfigurarIntervalo(new DateTime(2020, 02, 01),
                new DateTime(2020, 08, 30));

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Campanha intervalo Inválido")]
        [Trait("Categoria", "Campanhas - intervalo Inválido")]
        public void Configuracao_de_intervalo_invalido()
        {
            //Arrange
            var campanha = CampanhaFactory.CriarCampanhaInValida();

            //act
            var result = campanha.ConfigurarIntervalo(new DateTime(2020, 03, 01),
                new DateTime(2020, 01, 30));

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Campanha contar cliques")]
        [Trait("Categoria", "Campanhas - contar cliques")]
        public void contar_cliques()
        {
            //Arrange
            var campanha = CampanhaFactory.CriarCampanhaInValida();

            //act
            campanha.ContaCliques();

            //assert
            Assert.True(campanha.NumeroDeCliques == 1);
        }

        [Fact(DisplayName = "Campanha desativar")]
        [Trait("Categoria", "Campanhas - desativar campanha")]
        public void desativar_campanha()
        {
            //Arrange
            var campanha = CampanhaFactory.CriarCampanhaInValida();

            //act
            campanha.Desativar();

            //assert
            Assert.False(campanha.Ativo);
        }
    }
}