using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.ViewModels
{
   public class AdicionaVisitaPorteiroViewModel
    {      
        public string Observacao { get; set; }        

        public Guid VisitanteId { get; set; }
        public string NomeVisitante { get; set; }
        public TipoDeDocumento TipoDoDocumento { get; set; }
        public string Documento { get; set; }       
        public string EmailVisitante { get; set; }
        public string FotoVisitante { get; set; }
        public IFormFile ArquivoFotoVisitante { get; set; }
        public TipoDeVisitante TipoDeVisitante { get; set; }
        public string NomeEmpresaVisitante { get; set; }
       
        public Guid UnidadeId { get; set; }        

        public bool TemVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string CorVeiculo { get; set; }

        public Guid MoradorId { get; set; }       

    }
}
