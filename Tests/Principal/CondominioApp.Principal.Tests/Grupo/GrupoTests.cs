using CondominioApp.Principal.Domain;
using System;
using Xunit;


namespace CondominioApp.Principal.Tests
{
   
    public class GrupoTests
    {
        [Fact(DisplayName = "Criar um Grupo")]
        public void Criar_Grupo_Valido()
        {
            //Act   
            try
            {
                var grupo = new Grupo("Bloco 1", Guid.NewGuid());
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }            
        }


        [Fact(DisplayName = "Criar um Grupo sem Descricao")]
        public void Criar_Grupo_Invalido_SemDescricao()
        {
            //Act   
            try
            {
                var grupo = new Grupo("", Guid.NewGuid());
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }


        [Fact(DisplayName = "Criar um Grupo sem Condominio")]
        public void Criar_Grupo_Invalido_SemCondominio()
        {
            //Act   
            try
            {
                var grupo = new Grupo("Bloco 1", Guid.Empty);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }
}
