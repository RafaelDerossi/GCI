
using CondominioApp.ReservaAreaComum.Domain;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.ViewModels
{
   public class FotoDaAreaViewModel
    {
        public Guid FotoId { get; set; }

        public Guid AreaComumId { get; set; }

        public string NomeDoArquivo { get; set; }

        public string NomeOriginalDoArquivo { get; set; }

        public string Url { get; set; }

        public FotoDaAreaViewModel()
        {
        }
       
        public FotoDaAreaViewModel(FotoDaAreaComum fotoDaAreaComum)
        {
            FotoId = fotoDaAreaComum.Id;
            AreaComumId = fotoDaAreaComum.AreaComumId;
            NomeDoArquivo = fotoDaAreaComum.Foto.NomeDoArquivo;
            NomeOriginalDoArquivo = fotoDaAreaComum.Foto.NomeOriginal;
            Url = fotoDaAreaComum.FotoUrl;
        }
    }
}
