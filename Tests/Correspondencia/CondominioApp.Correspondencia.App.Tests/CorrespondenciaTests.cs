using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Correspondencias.App.Tests
{
    
    public class CorrespondenciaTests
    {
        [Fact(DisplayName = "Criar uma Correspondencia")]       
        public void Criar_Correspondencia_Valida()
        {
            //Act
            var correspondencia = new Correspondencia(
                Guid.NewGuid(),Guid.NewGuid(),"101","Bloco 1",false,null,null,
                DataHoraDeBrasilia.Get(),Guid.NewGuid(),"Rafael",null,null, 
                DataHoraDeBrasilia.Get(),1,null, StatusCorrespondencia.PENDENTE);
        }
    }
}
