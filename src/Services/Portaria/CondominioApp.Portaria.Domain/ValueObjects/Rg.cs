using System;
using CondominioApp.Core.Helpers;

namespace CondominioApp.Portaria.Domain.ValueObjects
{
    public class Rg
    {
        public const int Maxlength = 10;
        public const int Minlength = 4;

        public string Numero { get; private set; }

        protected Rg() { }

        public Rg(string pRg)
        {
            SetNumero(pRg);
        }

        private void SetNumero(string rgStr)
        {
            if (string.IsNullOrEmpty(rgStr))
            {
                Numero = rgStr;
                return;
            }

            Guarda.ValidarTamanhoMaximo(rgStr, Maxlength, "RG");
            Guarda.ValidarTamanhoMinimo(rgStr, Minlength, "RG");

            Numero = rgStr;
        }


        public override bool Equals(object obj)
        {
            var rg = (Rg)obj;

            return Numero == rg.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numero);
        }

        public override string ToString()
        {
            return Numero;
        }
    }
}
