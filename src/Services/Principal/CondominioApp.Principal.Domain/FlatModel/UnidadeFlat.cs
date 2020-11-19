using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class UnidadeFlat
    {
        public Guid Id { get; set; }
        public string UnidadeCodigo { get; set; }
        public string UnidadeNumero { get; set; }
        public string UnidadeAndar { get; set; }
        public int UnidadeVagas { get; set; }
        public string UnidadeTelefone { get; set; }
        public string UnidadeRamal { get; set; }
        public string unidadeComplemento { get; set; }
        public Guid GrupoId { get; set; }
        public string GrupoDescricao { get; set; }
        public Guid CondominioId { get; set; }
        public string CondominioCnpj { get; set; }
        public string CondominioNome { get; set; }
        public string CondominioLogoMarca { get; set; }

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
            this.unidadeComplemento = unidadeComplemento;
            GrupoId = grupoId;
            GrupoDescricao = grupoDescricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioLogoMarca = condominioLogoMarca;
        }
    }
}
