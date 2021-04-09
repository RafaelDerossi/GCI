using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Enquetes.App.Tests
{
    
    public class EnqueteFactoryTests
    {        
        public static Enquete Criar_Enquete_Valida()
        {
            return new Enquete(
                "Sim ou Nao", DateTime.Now,DateTime.Now.AddDays(30),Guid.NewGuid(),
                "Nome do Condominio",false, Guid.NewGuid(), "Nome do Usuario");
        }
    }
}
