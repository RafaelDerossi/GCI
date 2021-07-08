using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
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

        public Guid CondominioId { get; set; }

        public string NomeArquivoFotoCorrespondencia { get; set; }

        public string UrlFoto
        {
            get
            {
                return StoragePaths.ObterUrlDeArquivo(CondominioId.ToString(), NomeArquivoFotoCorrespondencia);
            }
        }

        public IEnumerable<string> ListaDeEmails { get; set; }

        public CorrespondenciaDTO
            (string assunto, string titulo, string descricao,
             string logoDoCondominio, IEnumerable<string> listaDeEmails,
             Guid condominioId, string nomeArquivoFotoCorrespondencia)
        {
            Assunto = assunto;
            Titulo = titulo;
            Descricao = descricao;
            LogoDoCondominio = logoDoCondominio;
            ListaDeEmails = listaDeEmails;
            CondominioId = condominioId;
            NomeArquivoFotoCorrespondencia = nomeArquivoFotoCorrespondencia;
        }
    }
}
