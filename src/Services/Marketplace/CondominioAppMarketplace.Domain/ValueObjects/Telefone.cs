using System.Text.RegularExpressions;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Utils;

namespace CondominioAppMarketplace.Domain.ValueObjects
{
    public class Telefone
    {
        public const int NumeroMaximo = 15;
        public string Numero { get; private set; }

        public bool WhatsApp { get; private set; }

        protected Telefone() { }

        public Telefone(string numeroTelephone, bool whatsApp = false)
        {
            setNumero(numeroTelephone);
            WhatsApp = whatsApp;
        }

        private void setNumero(string telNumber)
        {
            if (string.IsNullOrEmpty(telNumber)) return;

            telNumber = telNumber.Trim();
            Regex regex = new Regex(@"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$");
            Match match = regex.Match(telNumber);

            if (match.Success)
            {
                telNumber = telNumber.ApenasNumeros(telNumber);
                Numero = telNumber;
            }
            else
                throw new DomainException("Número de telefone inválido.");
        }

        public void NumeroEhWhatsApp() => WhatsApp = true;

        public void NumeroNaoEhWhatsApp() => WhatsApp = false;


        public string ObterNumeroFormatado
        {
            get
            {
                if (string.IsNullOrEmpty(Numero)) return Numero;

                if (Numero.Length == 11) return FormatarNumeroDeCelular();

                return FormatarNumeroDeTelefone();
            }
        }

        private string FormatarNumeroDeCelular()
        {
            int count = 0;
            string maskTelefone = "(";

            foreach (var item in Numero)
            {
                if (count == 2)
                    maskTelefone += ") ";

                if (count == 7)
                    maskTelefone += "-";

                maskTelefone += item;
                count++;
            }

            return maskTelefone;
        }

        private string FormatarNumeroDeTelefone()
        {
            int count = 0;
            string maskTelefone = "(";

            foreach (var item in Numero)
            {
                if (count == 2)
                    maskTelefone += ") ";

                if (count == 6)
                    maskTelefone += "-";

                maskTelefone += item;
                count++;
            }

            return maskTelefone;
        }
    }
}
