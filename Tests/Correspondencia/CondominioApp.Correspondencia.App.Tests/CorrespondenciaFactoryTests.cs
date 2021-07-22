using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Models;
using System;

namespace CondominioApp.Correspondencias.App.Tests
{
    
    public class CorrespondenciaFactoryTests
    {        
        public static Correspondencia Criar_Correspondencia_Valida()
        {
            //Act
          return new Correspondencia(
                DataHoraDeBrasilia.Get(), Guid.NewGuid(), Guid.NewGuid(), 
                "101", "Bloco 1", Guid.NewGuid(), "Rafael", "", null, "",
                "", "", true);
        }
    }
}
