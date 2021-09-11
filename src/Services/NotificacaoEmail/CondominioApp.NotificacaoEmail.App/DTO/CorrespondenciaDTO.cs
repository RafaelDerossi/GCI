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

        public string RecebidoPor { get; private set; }

        public string Codigo { get; private set; }

        public string Tipo { get; private set; }

        public string Localizacao { get; private set; }

        public string Observacao { get; private set; }

        public string UrlFoto
        {
            get
            {
                return StorageHelper.ObterUrlDeArquivo(CondominioId.ToString(), NomeArquivoFotoCorrespondencia);
            }
        }

        public IEnumerable<string> ListaDeEmails { get; set; }

        public CorrespondenciaDTO
            (string assunto, string titulo, string descricao, string logoDoCondominio,
             Guid condominioId, string nomeArquivoFotoCorrespondencia, string recebidoPor,
             string codigo, string tipo, string localizacao, string observacao,
             IEnumerable<string> listaDeEmails)
        {
            Assunto = assunto;
            Titulo = titulo;
            Descricao = descricao;
            LogoDoCondominio = logoDoCondominio;
            CondominioId = condominioId;
            NomeArquivoFotoCorrespondencia = nomeArquivoFotoCorrespondencia;
            RecebidoPor = recebidoPor;
            Codigo = codigo;
            Tipo = tipo;
            Localizacao = localizacao;
            Observacao = observacao;
            ListaDeEmails = listaDeEmails;
        }
    }
}
