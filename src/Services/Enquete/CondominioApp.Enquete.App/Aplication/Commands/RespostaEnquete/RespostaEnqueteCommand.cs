using CondominioApp.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
    public abstract class RespostaEnqueteCommand : Command
    {
        public Guid Id { get; set; }

        public Guid UnidadeId { get; set; }

        public string Unidade { get; set; }

        public string Bloco { get; set; }

        public Guid UsuarioId { get; set; }

        public string UsuarioNome { get; set; }

        public string TipoDeUsuario { get; set; }

        public Guid AlternativaId { get; set; }

    }
}
