using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Models
{
   public class SubPastaViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public bool Lixeira { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Guid CondominioId { get; set; }

        public bool Publica { get; set; }

        public bool PastaDoSistema { get; set; }        

        public Guid PastaMaeId { get; set; }        

    }
}
