
using Microsoft.AspNetCore.Http;

namespace CondominioApp.Comunicados.App.ViewModels
{
    public class AdicionaAnexoComunicadoViewModel
    {
        public string NomeOriginal { get; set; }

        public IFormFile Arquivo { get; set; }

    }
}
