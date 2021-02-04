using CondominioApp.Automacao.App.ValueObjects;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;

namespace CondominioApp.Automacao.Models
{
   public class CondominioCredencial : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public Guid CondominioId { get; private set; }

        public TipoApiAutomacao TipoApiAutomacao { get; set; }

        public CondominioCredencial()
        {
        }

        public CondominioCredencial(Email email, string senha, Guid condominioId, TipoApiAutomacao tipoApiAutomacao)
        {
            Email = email;
            Senha = senha;
            CondominioId = condominioId;
            TipoApiAutomacao = tipoApiAutomacao;
        }

        public void SetCredencial(Email email, string senha, TipoApiAutomacao tipoApiAutomacao)
        {
            Email = email;
            Senha = senha;            
            TipoApiAutomacao = tipoApiAutomacao;
        }

        public void SetCondominioId(Guid condominioId)
        {            
            CondominioId = condominioId;         
        }


        public string SenhaDescriptografa
        {
            get
            {
                return Criptograph.Decrypt(Senha);
            }            
        }

    }
}
