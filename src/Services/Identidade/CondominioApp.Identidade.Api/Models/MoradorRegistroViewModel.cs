using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Identidade.Api.Models
{
    public class MoradorRegistroViewModel : UsuarioRegistro
    {
        public string CodigoDaUnidade { get; set; }        

        public bool Proprietario { get; set; }

        public bool Principal { get; set; }

    }
}
