﻿using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.ViewModels
{
   public class EditaVisitanteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }       
        public string Documento { get; set; }       
        public string Email { get; set; }
        public string Foto { get; set; }
        public string NomeOriginalFoto { get; set; }
       
        public bool VisitantePermanente { get; set; }       
        public TipoDeVisitante TipoDeVisitante { get; set; }
        public string NomeEmpresa { get; set; }

        public bool TemVeiculo { get; set; }       
    }
}
