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
    }
}
