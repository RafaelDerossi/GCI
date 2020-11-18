using CondominioApp.Principal.Domain;
using CondominioApp.Core.ValueObjects;
using System;
using Xunit;


namespace CondominioApp.Principal.Tests
{
   
    public class CondominioTests
    {
        [Fact(DisplayName = "Criar um Condominio")]
        public void Criar_Condominio_Valido()
        {
            //Act   
            try
            {
                var condominio = new Condominio(new Cnpj("26585345000148"), "Condominio TU",
                "Condominio Teste Unitario", new Foto("Foto.jpg", "Foto.jpg"), new Telefone("(21) 99796-7038"),
                 new Endereco("Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ"),
                0, null, null, null, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
            
        }

        [Fact(DisplayName = "Criar um Condominio Sem Foto")]
        public void Criar_Condominio_Valido_SemFoto()
        {
            //Act
            try
            {
                var condominio = new Condominio(new Cnpj("26.585.345/0001-48"), "Condominio TU",
                               "Condominio Teste Unitario", null, new Telefone("(21) 99796-7038"),
                                new Endereco("Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ"),
                               0, null, null, null, false, false, false, false, false, false, false, false, false, false, false,
                               false, false, false, false);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
                        
           
        }

        [Fact(DisplayName = "Criar um Condominio Sem Telefone")]
        public void Criar_Condominio_Valido_SemTelefone()
        {
            //Act
            try
            {
                var condominio = new Condominio(new Cnpj("26585345000148"), "Condominio TU",
                               "Condominio Teste Unitario", null, null,
                                new Endereco("Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ"),
                               0, null, null, null, false, false, false, false, false, false, false, false, false, false, false,
                               false, false, false, false);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
           
        }


        [Fact(DisplayName = "Criar um Condominio Sem CNPJ")]
        public void Criar_Condominio_Invalido_SemCNPJ()
        {
            //Act
            try
            {
                var condominio = new Condominio(null, "Condominio TU",
                                "Condominio Teste Unitario", null, null,
                                 new Endereco("Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ"),
                                0, null, null, null, false, false, false, false, false, false, false, false, false, false, false,
                                false, false, false, false);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }            
            
        }

        [Fact(DisplayName = "Criar um Condominio Com CNPJ invalido")]
        public void Criar_Condominio_Invalido_ComCNPJInvalido()
        {
            //Act
            try
            {
                var condominio = new Condominio(new Cnpj("26585345000147"), "Condominio TU",
               "Condominio Teste Unitario", null, null,
                new Endereco("Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ"),
               0, null, null, null, false, false, false, false, false, false, false, false, false, false, false,
               false, false, false, false);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }          
           
        }
    }
}
