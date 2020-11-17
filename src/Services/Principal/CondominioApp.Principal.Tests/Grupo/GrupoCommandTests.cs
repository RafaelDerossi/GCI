using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Principal.Tests
{
   public class GrupoCommandTests
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
        [Fact(DisplayName = "Adicionar Grupo Válido")]
        [Trait("Categoria", "Grupo - Cadastrar Command")]
        public void CadastroDeGrupo_CommandoValido_DevePassarNaValidacao()
        {
           
                //Arrange
                var Command = GrupoCommandFactory.CriarComandoCadastroDeGrupo();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.True(result);
           
           
        }

        [Fact(DisplayName = "Adicionar Grupo Invalido - Sem Descricao")]
        [Trait("Categoria", "Grupo - Cadastrar Command Sem Descricao")]
        public void CadastroDeGrupoSemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = GrupoCommandFactory.CriarComandoCadastroDeGrupoSemDescricao();
            
            //Act
            var result = Command.EstaValido();
            
            //Assert
            Assert.False(result);           
        }

        [Fact(DisplayName = "Adicionar Grupo Invalido - Sem Condominio")]
        [Trait("Categoria", "Grupo - Cadastrar Command Sem Condominio")]
        public void CadastroDeGrupoSemCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = GrupoCommandFactory.CriarComandoCadastroDeGrupoSemCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }


        /// <summary>
        /// AlterarCommand
        /// </summary>
        [Fact(DisplayName = "Alterar Grupo Válido")]
        [Trait("Categoria", "Grupo - Alterar Command")]
        public void AlteracaoDeGrupo_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = GrupoCommandFactory.CriarComandoAlteracaoDeGrupo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Alterar Grupo Inválido - Sem Descricao")]
        [Trait("Categoria", "Grupo - Alterar Command - Sem Descricao")]
        public void AlteracaoDeGrupoSemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = GrupoCommandFactory.CriarComandoAlteracaoDeGrupoSemDescricao();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                //Assert
                Assert.False(false);
            }
           
        }

        [Fact(DisplayName = "Alterar Grupo Inválido - Sem Condominio")]
        [Trait("Categoria", "Grupo - Alterar Command - Sem Condominio")]
        public void AlteracaoDeGrupoSemCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = GrupoCommandFactory.CriarComandoAlteracaoDeGrupoSemCondominio();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                //Assert
                Assert.False(false);
            }

        }
    }
}
