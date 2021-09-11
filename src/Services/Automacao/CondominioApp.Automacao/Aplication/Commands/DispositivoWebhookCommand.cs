using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public abstract class DispositivoWebhookCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public Url UrlLigar { get; protected set; }

        public Url UrlDesligar { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public bool PulseLigado { get; protected set; }

        public string TempoDoPulse { get; protected set; }


        public void SetNome(string nome) => Nome = nome;

        public void SetUrlLigarDesligar(string urlLigar, string urlDesligar)
        {
            try
            {
                UrlLigar = new Url(urlLigar);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }

            if (PulseLigado)
            {
                SetUrlDesligar(urlLigar);
            }
            else
            {
                SetUrlDesligar(urlDesligar);
            }


        }

        private void SetUrlDesligar(string url)
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
