using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class RespostaEnqueteViewModel
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public Guid UnidadeId { get; set; }

        public string Unidade { get; set; }

        public string Bloco { get; set; }

        public Guid UsuarioId { get; set; }

        public string UsuarioNome { get; set; }

        public string TipoDeUsuario { get; set; }

        public Guid AlternativaId { get; set; }
    }
}
