using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace CondominioApp.Principal.Domain
{
    public class Grupo : Entity
    {
        public const int Max = 200;

        public string Descricao { get; private set; }

        public Guid CondominioId { get; private set; }

        public Condominio Condominio { get; private set; }


        private readonly List<Unidade> _Unidades;
        public IReadOnlyCollection<Unidade> Unidades => _Unidades;

        /// <summary>
        /// Construtores
        /// </summary>
        protected Grupo()
        {
            _Unidades = new List<Unidade>();
        }

        public Grupo(string descricao, Guid condominioId)
        {
            _Unidades = new List<Unidade>();
            this.Descricao = descricao;
            this.CondominioId = condominioId;
        }


        ///Metodos       

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;


        public void AdicionarUnidade(Unidade unidade)
        {
            _Unidades.Add(unidade);
        }
        public void AlterarUnidade(Unidade unidade)
        {
            _Unidades.RemoveAll(u => u.Id == unidade.Id);
            _Unidades.Add(unidade);

        }
    }
}
