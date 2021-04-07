using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class ComunicadoDTO
    {
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataDeRealizacao { get; set; }        

        public string NomeFuncionario { get; set; }       

        public CategoriaComunicado Categoria { get; set; }

        public bool TemAnexos { get; set; }        


        public CondominioDTO Condominio { get; set; }

        public IEnumerable<ArquivoDTO> Anexos { get; set; }

        public IEnumerable<string> ListaDeEmails { get; set; }

        public ComunicadoDTO
            (Guid id, DateTime dataDeCadastro, string titulo, string descricao, DateTime? dataDeRealizacao,
             string nomeFuncionario, CategoriaComunicado categoria, bool temAnexos,
             CondominioDTO condominio, IEnumerable<ArquivoDTO> anexos,
             IEnumerable<string> listaDeEmails)
        {
            Id = id;
            DataDeCadastro = dataDeCadastro;
            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            NomeFuncionario = nomeFuncionario;
            Categoria = categoria;
            TemAnexos = temAnexos;
            Condominio = condominio;
            Anexos = anexos;
            ListaDeEmails = listaDeEmails;
        }
    }
}
