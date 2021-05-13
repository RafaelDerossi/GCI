using CondominioApp.Enquetes.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
    public class AlternativaEnqueteCommandFactory
    {
        public static AtualizarAlternativaCommand CriarComandoEdicaoDeAlternativaEnquete()
        {
            //Act
            return new AtualizarAlternativaCommand(Guid.NewGuid(), "COM CERTEZA");
        }
    }
}