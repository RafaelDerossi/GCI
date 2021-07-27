using System.Text.RegularExpressions;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Utils;

namespace CondominioApp.Principal.Domain.ValueObjects
{
    public class Telefone
    {
        public const int NumeroMaximo = 15;
        public string Numero { get; private set; }       

        protected Telefone() { }

        public Telefone(string numeroTelephone)
        {
            setNumero(numeroTelephone);            
        }

        private void setNumero(string telNumber)
        {
            if (string.IsNullOrEmpty(telNumber)) return;

            telNumber = telNumber.Trim();
            telNumber = telNumber.ApenasNumeros(telNumber);
            Numero = telNumber;
        }      

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
