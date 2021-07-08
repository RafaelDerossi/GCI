using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public abstract class DispositivoWebhookCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; private set; }

        public Url UrlLigar { get; private set; }

        public Url UrlDesligar { get; private set; }

        public Guid CondominioId { get; private set; }


        public void SetNome(string nome) => Nome = nome;

        public void SetUrlLigar(string url)
        {
            try
            {
                UrlLigar = new Url(url);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }            
        }

        public void SetUrlDesligar(string url)
        {
            try
            {
                UrlDesligar = new Url(url);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetCondominioId(Guid condominioId)
        {
            CondominioId = condominioId;
        }

    }
}
