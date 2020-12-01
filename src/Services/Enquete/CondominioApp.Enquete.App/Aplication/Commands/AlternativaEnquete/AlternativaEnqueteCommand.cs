using CondominioApp.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
    public abstract class AlternativaEnqueteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid EnqueteId { get; protected set; }
       
    }
}
