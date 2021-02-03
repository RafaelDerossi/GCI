using CondominioApp.Automacao.App.ValueObjects;
using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Automacao.Models
{
   public class CondominioCredencial : Entity, IAggregateRoot
    {
        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public Guid CondominioId { get; private set; }

        public CondominioCredencial()
        {
        }

        public CondominioCredencial(Email email, string senha, Guid condominioId)
        {
            Email = email;
            Senha = senha;
            CondominioId = condominioId;
        }

        public void SetCredencial(Email email, string senha, Guid condominioId)
        {
            Email = email;
            Senha = senha;
            CondominioId = condominioId;
        }
    }
}
