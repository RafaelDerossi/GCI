using System;
using System.Text.RegularExpressions;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;

namespace CondominioApp.Principal.Domain.ValueObjects
{
    public class Cnpj
    {
        public const int Maxlength = 14;       

        public string Numero { get; private set; }

        protected Cnpj() { }

        public Cnpj(string pCnpj)
        {
            SetNumero(pCnpj);
        }

        private void SetNumero(string cnpjStr)
        {
            if (string.IsNullOrEmpty(cnpjStr))
            {
                Numero = "";
                return;
            }

            Guarda.ValidarTamanhoMaximo(cnpjStr, Maxlength, "CNPJ");            
            
            if (IsCnpj(cnpjStr))
                Numero = cnpjStr;
            else
                throw new DomainException("Número de CNPJ inválido");
        }

        public string NumeroFormatado
        {
            get
            {
                if (string.IsNullOrEmpty(Numero)) return "";

                return Convert.ToUInt64(Numero).ToString(@"00\.000\.000\/0000\-00");
            }
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }      

    }
}