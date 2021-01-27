using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Principal.Aplication
{
    public class ContratoViewModel
    {
        public Guid Id { get; set; }

        public Guid CondominioId { get; set; }

        public DateTime DataAssinatura { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public string Link { get; set; }       

     

        /// <summary>
        /// Construtores
        /// </summary>
        protected ContratoViewModel()
        {
        }

        public ContratoViewModel
            (Guid id, Guid condominioId, DateTime dataAssinatura, TipoDePlano tipo, 
             string descricao, bool ativo, string link)
        {
            Id = id;
            CondominioId = condominioId;
            DataAssinatura = dataAssinatura;
            Tipo = tipo.ToString();
            Descricao = descricao;
            Ativo = ativo;
            Link = link;
        }
    }
}
