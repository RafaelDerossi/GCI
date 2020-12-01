using CondominioApp.Enquetes.App.Aplication.Commands;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
    public class AlternativaEnqueteCommandFactory
    {
        public static AlterarAlternativaCommand CriarComandoAlteracaoDeAlternativaEnquete()
        {
            //Act
            return new AlterarAlternativaCommand(Guid.NewGuid(), "COM CERTEZA");
        }
    }
}