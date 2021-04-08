using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class CorrespondenciaDTO
    {
        public string Assunto { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }        

        public string LogoDoCondominio { get; set; }        

        public IEnumerable<string> ListaDeEmails { get; set; }

        public CorrespondenciaDTO
            (string assunto, string titulo, string descricao,
            string logoDoCondominio, IEnumerable<string> listaDeEmails)
        {
            Assunto = assunto;
            Titulo = titulo;
            Descricao = descricao;
            LogoDoCondominio = logoDoCondominio;
            ListaDeEmails = listaDeEmails;
        }
    }
}
