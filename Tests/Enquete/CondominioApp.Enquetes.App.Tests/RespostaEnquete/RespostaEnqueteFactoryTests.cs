using CondominioApp.Enquetes.App.Models;
using System;

namespace CondominioApp.Enquetes.App.Tests
{
    
    public class RespostaEnqueteFactoryTests
    {        
        public RespostaEnquete Criar_RespostaEnquete_Valida()
        {
            //Act
           return new RespostaEnquete(
                Guid.NewGuid(),"101","Bloco Um", Guid.NewGuid(),"Nome do usuario","CLIENTE", Guid.NewGuid());
        }
    }
}
