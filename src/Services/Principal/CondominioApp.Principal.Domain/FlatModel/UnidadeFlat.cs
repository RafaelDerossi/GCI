using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class UnidadeFlat
    {
        public Guid Id { get; private set; }

        public string UnidadeCodigo { get; private set; }

        public string UnidadeNumero { get; private set; }

        public string UnidadeAndar { get; private set; }

        public int UnidadeVagas { get; private set; }

        public string UnidadeTelefone { get; private set; }

        public string UnidadeRamal { get; private set; }

        public string UnidadeComplemento { get; private set; }

        public Guid GrupoId { get; private set; }

        public string GrupoDescricao { get; private set; }

        public Guid CondominioId { get; private set; }

        public string CondominioCnpj { get; private set; }

        public string CondominioNome { get; private set; }

        public string CondominioLogoMarca { get; private set; }

        protected UnidadeFlat() { }

        public UnidadeFlat(Guid id, string unidadeCodigo, string unidadeNumero, string unidadeAndar,
            int unidadeVagas, string unidadeTelefone, string unidadeRamal, string unidadeComplemento,
            Guid grupoId, string grupoDescricao, Guid condominioId, string condominioCnpj, string condominioNome,
            string condominioLogoMarca)
        {
            Id = id;
            UnidadeCodigo = unidadeCodigo;
            UnidadeNumero = unidadeNumero;
            UnidadeAndar = unidadeAndar;
            UnidadeVagas = unidadeVagas;
            UnidadeTelefone = unidadeTelefone;
            UnidadeRamal = unidadeRamal;
            UnidadeComplemento = unidadeComplemento;
            GrupoId = grupoId;
            GrupoDescricao = grupoDescricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioLogoMarca = condominioLogoMarca;
        }
    }
}
