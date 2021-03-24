using System;

namespace CondominioApp.Ocorrencias.App.ViewModels
{
    public class EditaOcorrenciaViewModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string FotoNome { get; set; }

        public string FotoNomeOriginal { get; set; }

        public bool Publica { get; set; }

       
        
    }
}
