using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Portaria.Tests
{
   public class VisitanteCommandTests
    {        
        /// CadastrarCommand
        [Fact(DisplayName = "Adicionar Visitante Válido - Por Morador Com CPF")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_PorMorador_ComCpf_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitantePorMorador_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Válido - Por Porteiro Com CPF")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_PorPorteiro_ComCpf_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitantePorPorteiro_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Visitante Inválido - Com CPF Inválido")]
        [Trait("Categoria", "Visitante - CadastrarCommand")]
        public void CadastroDeVisitante_ComCpfInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoCadastroDeVisitante_ComCPFInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
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
        

        



        ///EditarVisitanteCommand
        [Fact(DisplayName = "Editar Visitante Válido - Por Morador Com CPF")]
        [Trait("Categoria", "Visitante - EditarCommand")]
        public void EdicaoDeVisitante_PorMoradorComCpf_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoEdicaoDeVisitantePorMorador_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Visitante Válido - Por Porteiro Com CPF")]
        [Trait("Categoria", "Visitante - EditarCommand")]
        public void EdicaoDeVisitante_PorPorteiroComCpf_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoEdicaoDeVisitantePorPorteiro_ComCPF();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Visitante Inválido - Com CPF Inválido")]
        [Trait("Categoria", "Visitante - EditarCommand")]
        public void EdicaoDeVisitante_ComCpfInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoEdicaoDeVisitante_ComCPFInvalido();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Editar Visitante Válido - Com RG")]
        [Trait("Categoria", "Visitante - EditarCommand")]
        public void EdicaoDeVisitante_ComRG_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoEdicaoDeVisitante_ComRG();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Visitante Válido - Sem Documento")]
        [Trait("Categoria", "Visitante - EditarCommand")]
        public void EdicaoDeVisitante_SemDocumento_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = VisitanteCommandFactory.CriarComandoEdicaoDeVisitante_SemDocumento();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        

    }
}
