using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class ReservaDTO
    {
        public string Titulo { get; set; }

        public string AreaComumNome { get; set; }

        public string DataRealizacao { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFim { get; set; }

        public string NomeMorador { get; set; }

        public string UnidadeDescricao { get; set; }

        public string Valor { get; set; }

        public string Observacao { get; set; }

        public string Justificativa { get; set; }

        public string DataDeCadastro { get; set; }        

        public string NomeCondominio { get; set; }

        public string LogoDoCondominio { get; set; }

        public IEnumerable<string> ListaDeEmails { get; set; }

        public ReservaDTO
            (string titulo, string areaComumNome, string dataRealizacao, string horaInicio,
             string horaFim, string nomeMorador, string unidadeDescricao, string valor,
             string observacao, string justificativa, string dataDeCadastro, string nomeCondominio,
             string logoDoCondominio, IEnumerable<string> listaDeEmails)
        {
            Titulo = titulo;
            AreaComumNome = areaComumNome;
            DataRealizacao = dataRealizacao;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            NomeMorador = nomeMorador;
            UnidadeDescricao = unidadeDescricao;
            Valor = valor;
            Observacao = observacao;
            Justificativa = justificativa;
            DataDeCadastro = dataDeCadastro;
            NomeCondominio = nomeCondominio;
            LogoDoCondominio = logoDoCondominio;
            ListaDeEmails = listaDeEmails;
        }
    }
}
