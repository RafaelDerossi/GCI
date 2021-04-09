using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class CadastraPastaViewModel
    {        
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Guid CondominioId { get; set; }

        public bool Publica { get; set; }        

    }
}
