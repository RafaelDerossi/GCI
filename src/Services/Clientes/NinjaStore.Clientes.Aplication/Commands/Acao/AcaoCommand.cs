using GCI.Core.ValueObjects;
using System;
using GCI.Core.Messages.CommonMessages;

namespace GCI.Acoes.Aplication.Commands
{
    public abstract class AcaoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Codigo { get; protected set; }                

        public string RazaoSocial { get; protected set; }
        
    }
}
