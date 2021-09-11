using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Models
{
   public class ConteudoPastaViewModel
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

        public bool PastaRaiz { get; set; }

        public Guid PastaMaeId { get; set; }

        public CategoriaDaPastaDeSistema CategoriaDaPastaDeSistema { get; private set; }


        public List<ArquivoViewModel> Arquivos { get; set; }

        public List<SubPastaViewModel> Subpastas { get; set; }

    }
}
