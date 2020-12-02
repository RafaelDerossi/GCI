using CondominioApp.Enquetes.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
    public class AlternativaEnqueteCommandFactory
    {
        public static EditarAlternativaCommand CriarComandoEdicaoDeAlternativaEnquete()
        {
            //Act
            return new EditarAlternativaCommand(Guid.NewGuid(), "COM CERTEZA");
        }
    }
}