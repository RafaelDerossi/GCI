using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Identidade.Api.Models
{
    public class FuncionarioRegistroViewModel : UsuarioRegistro
    {
        public Permissao Permissao { get; set; }

        public string Atribuicao { get; set; }

        public string Funcao { get; set; }

        public bool SindicoProfissional { get; set; }        

        public Guid CondominioId { get; set; }        

    }
}
