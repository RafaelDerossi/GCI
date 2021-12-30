using GCI.Core.ValueObjects;
using System;
using GCI.Core.Messages.CommonMessages;

namespace GCI.Acoes.Aplication.Commands
{
    public abstract class ClienteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }        

        public Email Email { get; protected set; }

        public string Aldeia { get; protected set; }


        public void SetEmail(string email)
        {
            try
            {
                Email = new Email(email);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
    }
}
