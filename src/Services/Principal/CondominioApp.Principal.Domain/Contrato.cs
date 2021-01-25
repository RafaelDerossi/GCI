using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Principal.Domain
{
    public class Contrato : Entity
    {
        public const int Max = 200;

        public Guid CondominioId { get; private set; }

        public DateTime DataAssinatura { get; private set; }

        public TipoDePlano Tipo { get; private set; }

        public string Link { get; private set; }

        public bool Ativo { get; private set; }

       
        /// <summary>
        /// Construtores
        /// </summary>
        protected Contrato()
        {
        }

        public Contrato(Guid condominioId, DateTime dataAssinatura, TipoDePlano tipo, string link, bool ativo)
        {
            CondominioId = condominioId;
            DataAssinatura = dataAssinatura;
            Tipo = tipo;
            Link = link;
            Ativo = ativo;
        }



        ///Metodos Set

        public void SetCondominioId(Guid id) => CondominioId = id;

        public void SetDataAssinatura(DateTime data) => DataAssinatura = data;

        public void SetDescricao(TipoDePlano tipo) => Tipo = tipo;

        public void SetFoto(string link) => Link = link;

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

    }
}
