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
                Guid.NewGuid(),Guid.NewGuid(),"101","Bloco 1",null,
                Guid.NewGuid(),"Rafael",null,null,DataHoraDeBrasilia.Get(),
                null, null, true);
        }
    }
}
