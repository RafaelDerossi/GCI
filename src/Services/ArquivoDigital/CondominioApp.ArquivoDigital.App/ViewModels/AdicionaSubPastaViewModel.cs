using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class AdicionaSubPastaViewModel
    {        
        public string Titulo { get; set; }

        public string Descricao { get; set; }        

        public bool Publica { get; set; }

        public Guid PastaMaeId { get; set; }
    }
}
