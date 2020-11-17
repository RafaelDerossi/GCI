using CondominioApp.Principal.Domain;
using CondominioApp.Core.ValueObjects;
using System;
using Xunit;


namespace CondominioApp.Principal.Tests
{
   
    public class UnidadeTests
    {
        [Fact(DisplayName = "Criar uma Unidade")]
        public void Criar_Unidade_Valido()
        {
            //Act   
            try
            {
                var unidade = new Unidade("101","1",1, new Telefone("(21) 99796-7038"),"100",
                    "Perto da entrada",Guid.NewGuid(), Guid.NewGuid());
                unidade.ResetCodigo();
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
            
        }

        [Fact(DisplayName = "Criar uma unidade Sem Telefone")]
        public void Criar_Unidade_Valido_SemTelefone()
        {
            //Act
            try
            {
                var unidade = new Unidade("101", "1", 1, null, "100",
                    "Perto da entrada", Guid.NewGuid(), Guid.NewGuid());
                unidade.ResetCodigo();
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }

        }
       

        [Fact(DisplayName = "Criar uma Unidade Sem numero")]
        public void Criar_Unidade_Invalido_SemNumero()
        {
            //Act
            try
            {
                var unidade = new Unidade("", "1", 1, null, "100",
                    "Perto da entrada", Guid.NewGuid(), Guid.NewGuid());
                unidade.ResetCodigo();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }


        [Fact(DisplayName = "Criar uma Unidade Sem grupo")]
        public void Criar_Unidade_Invalido_SemGrupo()
        {
            //Act
            try
            {
                var unidade = new Unidade("101", "1", 1, new Telefone("(21) 99796-7038"), "100",
                    "Perto da entrada", Guid.Empty, Guid.NewGuid());
                unidade.ResetCodigo();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }


        [Fact(DisplayName = "Criar uma Unidade Sem condominio")]
        public void Criar_Unidade_Invalido_SemCondominio()
        {
            //Act
            try
            {
                var unidade = new Unidade("101", "1", 1, new Telefone("(21) 99796-7038"), "100",
                    "Perto da entrada", Guid.NewGuid(), Guid.Empty);
                unidade.ResetCodigo();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

    }
}
