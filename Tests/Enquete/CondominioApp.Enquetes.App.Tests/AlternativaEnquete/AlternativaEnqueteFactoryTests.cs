using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    
    public class AlternativaEnqueteFactoryTests
    {      
        public static AlternativaEnquete Criar_AlternativaEnquete_Valida()
        {
            var alternativa = new AlternativaEnquete("COM CERTEZA", 1);
            alternativa.SetEnqueteId(Guid.NewGuid());
            return alternativa;
        }
    }
}
