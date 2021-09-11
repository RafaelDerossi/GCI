using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class EnqueteDTO
    {
        public string Descricao { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public string NomeCondominio { get; set; }

        public string LogoDoCondominio { get; set; }

        public string NomeFuncionario { get; set; }

        public IEnumerable<string> Alternativas { get; set; }

        public IEnumerable<string> ListaDeEmails { get; set; }
        

        public EnqueteDTO
            (string descricao, string dataInicio, string dataFim, 
             string nomeCondominio, string logoDoCondominio, 
             string nomeFuncionario, IEnumerable<string> alternativas, 
             IEnumerable<string> listaDeEmails)
        {
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            NomeCondominio = nomeCondominio;
            LogoDoCondominio = logoDoCondominio;
            NomeFuncionario = nomeFuncionario;
            ListaDeEmails = listaDeEmails;
            Alternativas = alternativas;
        }
    }
}
