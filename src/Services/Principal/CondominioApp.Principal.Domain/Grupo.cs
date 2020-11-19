using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

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


        public ValidationResult AdicionarUnidade(Unidade unidade)
        {
            
            if (_Unidades.Any(u => u.Numero == unidade.Numero && u.Andar == unidade.Andar &&
                                   u.GrupoId == unidade.GrupoId && u.CondominioId == unidade.CondominioId))
            {
                AdicionarErrosDaEntidade("Já existe uma unidade com este número e andar neste bloco!");
                return ValidationResult;
            }

            _Unidades.Add(unidade);

            return ValidationResult;
        }

        public void AlterarUnidade(Unidade unidade)
        {
            _Unidades.RemoveAll(u => u.Id == unidade.Id);
            _Unidades.Add(unidade);

        }
    }
}
