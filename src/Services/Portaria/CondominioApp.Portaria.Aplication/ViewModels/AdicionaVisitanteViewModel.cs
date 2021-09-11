﻿using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Portaria.Aplication.ViewModels
{
   public class AdicionaVisitanteViewModel
    {
        public string Nome { get; set; }
        public TipoDeDocumento TipoDoDocumento { get; set; }
        public string Documento { get; set; }       
        public string Email { get; set; }
        public IFormFile ArquivoFoto { get; set; }        
        public Guid UnidadeId { get; set; }
        public bool VisitantePermanente { get; set; }        
        public TipoDeVisitante TipoDeVisitante { get; set; }
        public string NomeEmpresa { get; set; }
        public bool TemVeiculo { get; set; }
        public Guid MoradorId { get; set; }       
    }
}