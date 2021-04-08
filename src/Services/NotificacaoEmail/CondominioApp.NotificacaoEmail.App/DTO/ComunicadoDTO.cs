using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class ComunicadoDTO
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }             

        public CategoriaComunicado Categoria { get; set; }

        public bool TemAnexos { get; set; }

        public Guid CondominioId { get; set; }

        public string LogoDoCondominio { get; set; }

        public IEnumerable<ArquivoDTO> Anexos { get; set; }

        public IEnumerable<string> ListaDeEmails { get; set; }

        public ComunicadoDTO
            (string titulo, string descricao, CategoriaComunicado categoria, 
             bool temAnexos, Guid condominioId, string logoDoCondominio,
             IEnumerable<ArquivoDTO> anexos, IEnumerable<string> listaDeEmails)
        {
            Titulo = titulo;
            Descricao = descricao;
            Categoria = categoria;
            TemAnexos = temAnexos;
            CondominioId = condominioId;
            LogoDoCondominio = logoDoCondominio;
            Anexos = anexos;
            ListaDeEmails = listaDeEmails;
        }
    }
}
