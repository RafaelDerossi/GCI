using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    
    public class AlternativaEnqueteTests
    {
        [Fact(DisplayName = "Criar uma AlternativaEnquete")]       
        public void Criar_AlternativaEnquete_Valida()
        {
            //Act
            var alternativa = new AlternativaEnquete("COM CERTEZA", 1, Guid.NewGuid());
        }
    }
}
