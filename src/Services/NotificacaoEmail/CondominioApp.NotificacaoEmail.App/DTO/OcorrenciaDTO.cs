using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class OcorrenciaDTO
    {
        public string Titulo { get; set; }        

        public string Descricao { get; set; }

        public string NomeMorador { get; set; }

        public string UnidadeDescricao { get; set; }

        public string StatusPrivacidade { get; set; }

        public string StatusOcorrencia { get; set; }

        public string DataDeCadastro { get; set; }

        public string Foto { get; set; }

        public string NomeCondominio { get; set; }

        public string LogoDoCondominio { get; set; }

        public IEnumerable<string> ListaDeEmails { get; set; }

        public OcorrenciaDTO
            (string titulo, string descricao, string nomeMorador,
             string unidadeDescricao, string statusPrivacidade, string statusOcorrencia,
             string dataDeCadastro, string foto, string nomeCondominio, string logoDoCondominio,
             IEnumerable<string> listaDeEmails)
        {
            Titulo = titulo;
            Descricao = descricao;
            NomeMorador = nomeMorador;
            UnidadeDescricao = unidadeDescricao;
            StatusPrivacidade = statusPrivacidade;
            StatusOcorrencia = statusOcorrencia;
            DataDeCadastro = dataDeCadastro;
            Foto = foto;
            NomeCondominio = nomeCondominio;
            LogoDoCondominio = logoDoCondominio;
            ListaDeEmails = listaDeEmails;
        }
    }
}
