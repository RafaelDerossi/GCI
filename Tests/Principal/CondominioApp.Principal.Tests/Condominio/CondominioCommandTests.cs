﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioApp.Principal.Tests
{
   public class CondominioCommandTests
    {

        /// <summary>
        /// CadastrarCommand
        /// </summary>
        [Fact(DisplayName = "Adicionar Condominio Válido")]
        [Trait("Categoria", "Condominio - CadastrarCommand")]
        public void CadastroDeCondominio_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Condominio valido - Sem Foto")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem Foto")]
        public void CadastroDeCondominioSemFoto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemFoto();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Condominio valido - Sem Telefone")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem Telefone")]
        public void CadastroDeCondominioSemTelefone_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemTelefone();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Sem Nome")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem Nome")]
        public void CadastroDeCondominioSemNome_CommandoInvalido_NaoDevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemNome();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Sem CNPJ")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Sem CNPJ")]
        public void CadastroDeCondominioSemCNPJ_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioSemCNPJ();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }
           
        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Com CNPJ Invalido")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Com CNPJ Invalido")]
        public void CadastroDeCondominioComCNPJInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioComCNPJInvalido();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }

        }

        [Fact(DisplayName = "Adicionar Condominio Invalido - Com Telefone Invalido")]
        [Trait("Categoria", "Condominio - CadastrarCommand - Com Telefone Invalido")]
        public void CadastroDeCondominioComTelefoneInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoCadastroDeCondominioComTelefoneInvalido();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }
            
        }



        /// <summary>
        /// AlterarCommand
        /// </summary>
        [Fact(DisplayName = "Alterar Condominio Válido")]
        [Trait("Categoria", "Condominio - AlterarCommand")]
        public void AlteracaoDeCondominio_CommandoValido_DevePassarNaValidacao()
        {

            //Arrange
            var Command = CondominioCommandFactory.CriarComandoAlteracaoDeCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }


        [Fact(DisplayName = "Alterar Condominio Inválido - Sem CNPJ")]
        [Trait("Categoria", "Condominio - AlterarCommand - Sem CNPJ")]
        public void AlteracaoDeCondominioSemCNPJ_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoAlteracaoDeCondominioSemCNPJ();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }
           
        }


        [Fact(DisplayName = "Alterar Condominio Inválido - Com CNPJ Invalido")]
        [Trait("Categoria", "Condominio - AlterarCommand - Com CNPJ Invalido")]
        public void AlteracaoDeCondominioComCNPJInvalido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoAlteracaoDeCondominioComCNPJInvalido();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }
            
        }

        [Fact(DisplayName = "Alterar Condominio Inválido - Sem Nome")]
        [Trait("Categoria", "Condominio - AlterarCommand - Sem Nome")]
        public void AlteracaoDeCondominioSemNome_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            try
            {
                //Arrange
                var Command = CondominioCommandFactory.CriarComandoAlteracaoDeCondominioSemNome();

                //Act
                var result = Command.EstaValido();

                //Assert
                Assert.False(result);
            }
            catch (Exception)
            {
                Assert.False(false);
            }

        }


        /// <summary>
        /// AlterarConfiguracaoCommand
        /// </summary>
        [Fact(DisplayName = "Alterar Configuracao de Condominio Válido")]
        [Trait("Categoria", "Condominio - AlterarConfiguracaoCommand")]
        public void AlteracaoDeConfiguracaoDeCondominio_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = CondominioCommandFactory.CriarComandoAlteracaoDeConfiguracaoDoCondominio();

            //Act
            var result = Command.EstaValido();

            //Assert
            Assert.True(result);
        }
    }
}
