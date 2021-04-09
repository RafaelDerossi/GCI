using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.Models;
using CondominioApp.Enquetes.App.ViewModels;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
    public class EnqueteCommandFactory
    {
        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas()
        {
            //Arrange            
            var alternativas = new List<AlternativaEnquete>();
            alternativas.Add(new AlternativaEnquete("SIM", 1));
            alternativas.Add(new AlternativaEnquete("NAO", 2));

            //Act
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }
        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteFactory_SemAlternativas()
        {
            return new CadastrarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, null);
        }



        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnquete()
        {
            return CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteComMenosDeDuasAlternativas()
        {
            var alternativas = new List<AlternativaEnquete>();
            alternativas.Add(new AlternativaEnquete("SIM", 1));

            var comando = CriarComandoCadastroDeEnqueteFactory_SemAlternativas();
            comando.SetAlternativas(alternativas);

            return comando;
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemAlternativas()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_SemAlternativas();
            return comando;
        }
       

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteJaTerminada()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetDataInicio(DateTime.Now.AddDays(-3));
            comando.SetDataFim(DateTime.Now.AddDays(-2));
            return comando;
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteComDataInicialPosteriorAFinal()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetDataInicio(DateTime.Now.AddDays(3));
            comando.SetDataFim(DateTime.Now.AddDays(-2));
            return comando;
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemDescricao()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetDescricao("");            
            return comando;
        }

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemCondominioId()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }       

        public static CadastrarEnqueteCommand CriarComandoCadastroDeEnqueteSemFuncionarioId()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetFuncionarioId(Guid.Empty);
            return comando;
        }
        

        public static EditarEnqueteCommand CriarComandoEdicaoDeEnquete()
        {
            var alternativas = new List<AlternativaEnquete>();
            alternativas.Add(new AlternativaEnquete("SIM", 1));
            alternativas.Add(new AlternativaEnquete("NAO", 2));

            return new EditarEnqueteCommand
                (Guid.NewGuid(), "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30),
                false, alternativas);
        }
    }
}