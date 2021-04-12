using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class RespostaOcorrenciaDTO
    {
        public string Titulo { get; set; }        

        public string DescricaoDaOcorrencia { get; set; }

        public string Resposta { get; set; }

        public string NomeSindico { get; set; }        

        public string DataDaResposta { get; set; }

        public string Foto { get; set; }

        public string NomeCondominio { get; set; }

        public string LogoDoCondominio { get; set; }

        public IEnumerable<string> ListaDeEmails { get; set; }

        public RespostaOcorrenciaDTO
            (string titulo, string descricaoDaOcorrencia, string resposta, 
             string nomeSindico, string dataDaResposta,
             string foto, string nomeCondominio, string logoDoCondominio,
             IEnumerable<string> listaDeEmails)
        {
            Titulo = titulo;
            DescricaoDaOcorrencia = descricaoDaOcorrencia;
            Resposta = resposta;
            NomeSindico = nomeSindico;
            DataDaResposta = dataDaResposta;
            Foto = foto;
            NomeCondominio = nomeCondominio;
            LogoDoCondominio = logoDoCondominio;
            ListaDeEmails = listaDeEmails;
        }
    }
}
