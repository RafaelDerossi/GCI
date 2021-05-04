using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Models;
using System;

namespace CondominioApp.Correspondencias.App.Tests
{
    
    public class CorrespondenciaFactoryTests
    {        
        public Correspondencia Criar_Correspondencia_Valida()
        {
            //Act
          return new Correspondencia(
                Guid.NewGuid(),Guid.NewGuid(),"101","Bloco 1",false,null,null,
                DataHoraDeBrasilia.Get(),Guid.NewGuid(),"Rafael",null,null, 
                DataHoraDeBrasilia.Get(),1,null, StatusCorrespondencia.PENDENTE);
        }
    }
}
