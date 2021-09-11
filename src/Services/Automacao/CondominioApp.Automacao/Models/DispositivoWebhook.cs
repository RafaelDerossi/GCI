using CondominioApp.Core.DomainObjects;
using CondominioApp.Principal.Domain.ValueObjects;
using System;

namespace CondominioApp.Automacao.Models
{
    public class DispositivoWebhook : Entity
    {
        public const int Max = 200;

        public string Nome { get; private set; }

        public Url UrlLigar { get; private set; }

        public Url UrlDesligar { get; private set; }

        public Guid CondominioId { get; private set; }

        public bool Ligado { get; private set; }

        public bool PulseLigado { get; private set; }

        public string TempoDoPulse { get; private set; }

        public DispositivoWebhook()
        {
        }

        public DispositivoWebhook(string nome, Url urlLigar, Url urlDesligar, Guid condominioId)
        {
            Nome = nome;
            UrlLigar = urlLigar;
            UrlDesligar = urlDesligar;
            CondominioId = condominioId;
        }

        public void SetNome(string nome) => Nome = nome;

        public void SetUrlLigar(Url url) => UrlLigar = url;

        public void SetUrlDesligar(Url url) => UrlDesligar = url;

        public void SetCondominioId(Guid condominioId)
        {            
            CondominioId = condominioId;         
        }

        public void Ligar() => Ligado = true;

        public void Desligar() => Ligado = false;

        public void LigarPulse(string tempo)
        {
            PulseLigado = true;
            TempoDoPulse = tempo;
        }

        public void DesligarPulse()
        {
            PulseLigado = false;
            TempoDoPulse = "";
        }
    }
}
