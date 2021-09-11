using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class AtualizaLogoCondominioViewModel
    {

        public Guid Id { get; set; }

        public IFormFile ArquivoLogo { get; set; }        
    }
}
