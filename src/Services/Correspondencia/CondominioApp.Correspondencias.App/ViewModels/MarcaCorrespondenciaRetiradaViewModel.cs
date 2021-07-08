using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class MarcaCorrespondenciaRetiradaViewModel
    {
        public Guid CorrespondenciaId { get; set; }

        public string NomeRetirante { get; set; }

        public Guid FuncionarioId { get; set; }       

        public string Observacao { get; set; }

        public IFormFile ArquivoFotoDoRetirante { get; set; }
    }
}
