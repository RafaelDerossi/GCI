using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.Models;
using CondominioApp.Enquetes.App.ViewModels;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Tests
{
    public class EnqueteCommandFactory
    {
        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas()
        {
            //Arrange            
            var alternativas = new List<AlternativaEnquete>
            {
                new AlternativaEnquete("SIM", 1),
                new AlternativaEnquete("NAO", 2)
            };

            //Act
            return new AdicionarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, alternativas);
        }
        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteFactory_SemAlternativas()
        {
            return new AdicionarEnqueteCommand(
                "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30), Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", false, null);
        }



        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnquete()
        {
            return CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
        }

        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteComMenosDeDuasAlternativas()
        {
            var alternativas = new List<AlternativaEnquete>
            {
                new AlternativaEnquete("SIM", 1)
            };

            var comando = CriarComandoCadastroDeEnqueteFactory_SemAlternativas();
            comando.SetAlternativas(alternativas);

            return comando;
        }

        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteSemAlternativas()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_SemAlternativas();
            return comando;
        }
       

        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteJaTerminada()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetDataInicio(DateTime.Now.AddDays(-3));
            comando.SetDataFim(DateTime.Now.AddDays(-2));
            return comando;
        }

        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteComDataInicialPosteriorAFinal()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetDataInicio(DateTime.Now.AddDays(3));
            comando.SetDataFim(DateTime.Now.AddDays(-2));
            return comando;
        }

        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteSemDescricao()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetDescricao("");            
            return comando;
        }

        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteSemCondominioId()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetCondominioId(Guid.Empty);
            return comando;
        }       

        public static AdicionarEnqueteCommand CriarComandoCadastroDeEnqueteSemFuncionarioId()
        {
            var comando = CriarComandoCadastroDeEnqueteFactory_ComDuasAlternativas();
            comando.SetFuncionarioId(Guid.Empty);
            return comando;
        }
        

        public static AtualizarEnqueteCommand CriarComandoEdicaoDeEnquete()
        {
            var alternativas = new List<AlternativaEnquete>
            {
                new AlternativaEnquete("SIM", 1),
                new AlternativaEnquete("NAO", 2)
            };

            return new AtualizarEnqueteCommand
                (Guid.NewGuid(), "SIM ou NAO?", DateTime.Now, DateTime.Now.AddDays(30),
                false, alternativas);
        }
    }
}