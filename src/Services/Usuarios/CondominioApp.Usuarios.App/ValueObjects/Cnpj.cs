using System;
using System.Text.RegularExpressions;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;

namespace CondominioApp.Usuarios.App.ValueObjects
{
    public class Cnpj
    {
        public const int Maxlength = 18;
        public string numero { get; private set; }

        protected Cnpj() { }

        public Cnpj(string pCnpj)
        {
            setNumero(pCnpj);
        }

        private void setNumero(string cnpjStr)
        {
            Guarda.ValidarTamanhoMaximo(cnpjStr, Maxlength);

            if (!string.IsNullOrEmpty(cnpjStr))
            {
                Regex regex = new Regex(@"(^(\d{2}.\d{3}.\d{3}/\d{4}.\d{2})|(\d{14})$)");

                var match = regex.Match(cnpjStr);

                if (match.Success)
                {
                    string nCnpj = cnpjStr.Replace(".", "").Replace("/", "").Replace("-", "");
                    if (IsCnpj(nCnpj))
                        numero = nCnpj;
                    else
                        throw new DomainException("Número de CNPJ inválido");
                }
                else
                    throw new DomainException("Número de CNPJ não formatado");
            }
            else
            {
                throw new DomainException("Número de CNPJ não pode ser vazio!");
            }
        }

        public string NumeroFormatado
        {
            get
            {
                if (string.IsNullOrEmpty(numero)) return "";

                return Convert.ToUInt64(numero).ToString(@"00\.000\.000\/0000\-00");
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