using CondominioApp.Automacao.App.ValueObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using System;
using System.Security.Cryptography;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public abstract class CondominioCredencialCommand : Command
    {
        public Guid Id { get; protected set; }

        public Email Email { get; protected set; }

        public string Senha { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public TipoApiAutomacao TipoApiAutomacao { get; set; }


        public void SetSenha(string senha)
        {            
            Senha = Criptograph.Encrypt(senha);
        }

        public void SetCondominioId(Guid condominioId)
        {
            CondominioId = condominioId;
        }

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

        public void SetTipoApiAutomcao(TipoApiAutomacao tipoApiAutomacao)
        {
            TipoApiAutomacao = tipoApiAutomacao;
        }
    }
}
