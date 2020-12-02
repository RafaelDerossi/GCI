using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    
    public class RespostaEnqueteTests
    {
        [Fact(DisplayName = "Criar uma RespostaEnquete")]       
        public void Criar_RespostaEnquete_Valida()
        {
            //Act
            var resposta = new RespostaEnquete(
                Guid.NewGuid(),"101","Bloco Um", Guid.NewGuid(),"Nome do usuario","CLIENTE", Guid.NewGuid());
        }
    }
}
