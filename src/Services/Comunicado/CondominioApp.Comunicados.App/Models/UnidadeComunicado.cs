using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Comunicados.App.Models
{
   public class UnidadeComunicado : Entity
    {
        public Guid UnidadeId { get; private set; }
        public string Numero { get; private set; }
        public string Andar { get; private set; }              
        public Guid GrupoId { get; private set; }
        public string DescricaoGrupo { get; private set; }

        public Guid ComunicadoId { get; set; }
        public Comunicado Comunicado { get; set; }

        /// <summary>
        /// Construtores
        /// </summary>
        protected UnidadeComunicado()
        {
        }

        public UnidadeComunicado(Guid unidadeId, string numero, string andar, Guid grupoId, string descricaoGrupo)
        {
            UnidadeId = unidadeId;
            Numero = numero;
            Andar = andar;            
            GrupoId = grupoId;
            DescricaoGrupo = descricaoGrupo;
        }


        /// <summary>
        /// Metodos       
        /// </summary>

        public void SetNumero(string numero) => Numero = numero;

        public void SetAndar(string andar) => Andar = andar;

        public void SetDescricaoGrupo(string descricaoGrupo) => DescricaoGrupo = descricaoGrupo;

        
    }
}
