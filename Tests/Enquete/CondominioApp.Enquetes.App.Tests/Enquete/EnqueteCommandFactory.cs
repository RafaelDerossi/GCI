using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.ViewModels;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
    public class EnqueteCommandFactory
    {
        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnquete()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(), 
                "Nome do Condominio", Guid.NewGuid(),"Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteComMenosDeDuasAlternativas()
        {
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemAlternativas()
        {
            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, null);
        }
       

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteJaTerminada()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-2), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteComDataInicialPosteriorAFinal()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now.AddDays(3), DateTime.Now.AddDays(-2), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemDescricao()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
               "", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemCondominioId()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.Empty,
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemNomeDoCondominio()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemUsuarioId()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.Empty, "Nome do Usuario", false, alternativas);
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemNomeDoUsuario()
        {
            //Arrange            
            var alternativas = new List<CadastraAlternativaEnqueteViewModel>();
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("SIM", 1));
            alternativas.Add(new CadastraAlternativaEnqueteViewModel("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "", false, alternativas);
        }

        public static EditarEnqueteCommand CriarComandoEdicaoDeEnquete()
        {           
            //Act
            return new EditarEnqueteCommand(Guid.NewGuid(), "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), false);
        }
    }
}