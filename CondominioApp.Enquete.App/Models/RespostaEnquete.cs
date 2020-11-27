using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.Models
{
   public class RespostaEnquete : Entity
    {
        public Guid UnidadeId { get; set; }

        public string Unidade { get; set; }

        public string Bloco { get; set; }

        public Guid UsuarioId { get; set; }

        public string UsuarioNome { get; set; }

        public string TipoDeUsuario { get; set; }

        public Guid AlternativaId { get; set; }
       
               

        public RespostaEnquete() {}

        public RespostaEnquete(Guid unidadeId, string unidade, string bloco, Guid usuarioId, 
            string usuarioNome, string tipoDeUsuario, Guid alternativaId)
        {
            UnidadeId = unidadeId;
            Unidade = unidade;
            Bloco = bloco;
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            TipoDeUsuario = tipoDeUsuario;
            AlternativaId = alternativaId;
        }

        
        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetUnidade(string unidade) => Unidade = unidade;

        public void SetBloco(string bloco) => Bloco = bloco;

        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;

        public void SetUsuarioNome(string usuarioNome) => UsuarioNome = usuarioNome;

        public void SetTipoDeUsuario(string tipoDeUsuario) => TipoDeUsuario = tipoDeUsuario;

        public void SetAlternativaId(Guid alternativaId) => AlternativaId = alternativaId;
       
    }
}
