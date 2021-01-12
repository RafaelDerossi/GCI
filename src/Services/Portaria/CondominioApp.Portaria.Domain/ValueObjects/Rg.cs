using System;
using System.Text.RegularExpressions;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Utils;

namespace CondominioApp.Portaria.ValueObjects
{
    public class Rg
    {
        public const int Maxlength = 10;
        public string Numero { get; private set; }

        protected Rg() { }

        public Rg(string pRg)
        {
            SetNumero(pRg);
        }

        private void SetNumero(string rgStr)
        {
            if (string.IsNullOrEmpty(rgStr)) return;

            Guarda.ValidarTamanho(rgStr, Maxlength);
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
