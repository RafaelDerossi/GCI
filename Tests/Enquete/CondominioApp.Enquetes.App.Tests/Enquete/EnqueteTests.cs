using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    
    public class EnqueteTests
    {
        [Fact(DisplayName = "Criar uma Enquete")]       
        public void Criar_Enquete_Valida()
        {
            //Arrange            
           
            //Act
            var enquete = new Enquete(
                "Sim ou Nao", DateTime.Now,DateTime.Now.AddDays(30),Guid.NewGuid(),
                "Nome do Condominio",false, Guid.NewGuid(), "Nome do Usuario");
        }
    }
}
