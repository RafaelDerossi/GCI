using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class AdicionaPastaRaizViewModel
    {        
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Guid CondominioId { get; set; }

        public bool Publica { get; set; }
        
    }
}
