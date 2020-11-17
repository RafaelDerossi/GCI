using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Principal.Domain
{
    public class Grupo : Entity
    {
        public const int Max = 200;

        public string Descricao { get; private set; }

        public Guid CondominioId { get; private set; }

        public Condominio Condominio { get; private set; }


        /// <summary>
        /// Construtores
        /// </summary>
        protected Grupo()
        {
        }

        public Grupo(string descricao, Guid condominioId)
        {
            this.Descricao = descricao;
            this.CondominioId = condominioId;
        }


        ///Metodos       

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;


    }
}
