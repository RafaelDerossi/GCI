using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Portaria.Tests
{
   public class VisitanteCommandTests
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
        [Fact(DisplayName = "Adicionar Visitante Válido - Com CPF")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_ComCpf_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Válido - Com RG")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_ComRg_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_ComRG();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Válido - Sem Documento")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemDocumento_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemDocumento();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Válido - Sem Email")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemEmail_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemEmail();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Válido - Sem Foto")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemFoto_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemFoto();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem CondominioId")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemCondominioId();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem Nome do Condominio")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemNomeCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemNomeDoCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem UnidadeId")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemUnidadeId_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemUnidadeId();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem Numero da Unidade")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemNumeroUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemNumeroUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem Andar da Unidade")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemAndarUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemAndarUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem Grupo da Unidade")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemGrupoUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemGrupoUnidade();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem Tipo de Visitante")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemTipoDeVisitante_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemTipoDeVisitante();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Válido - Sem Placa do Veiculo")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemPlacaVeiculo_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemPlacaVeiculo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem Modelo Veiculo")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemModeloVeiculo_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemModeloVeiculo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Sem Cor do Veiculo")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemCorDoVeiculo_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemCorVeiculo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Válido - Sem Veiculo")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_SemVeiculo_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_SemVeiculo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }
    }
}
