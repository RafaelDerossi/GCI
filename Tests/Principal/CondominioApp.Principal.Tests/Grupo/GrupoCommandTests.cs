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
        /// EditarCommand
        /// </summary>
        [Fact(DisplayName = "Editar Grupo Válido")]
        [Trait("Categoria", "Grupo - EditarCommand")]
        public void EdicaoDeGrupo_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = GrupoCommandFactory.CriarComandoEdicaoDeGrupo();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Editar Grupo Inválido - Sem Descricao")]
        [Trait("Categoria", "Grupo - EditarCommand - Sem Descricao")]
        public void EdicaoDeGrupoSemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = GrupoCommandFactory.CriarComandoEdicaoDeGrupoSemDescricao();

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

        [Fact(DisplayName = "Editar Grupo Inválido - Sem Condominio")]
        [Trait("Categoria", "Grupo - EditarCommand - Sem Condominio")]
        public void EdicaoDeGrupoSemCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = GrupoCommandFactory.CriarComandoEdicaoDeGrupoSemCondominio();

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
