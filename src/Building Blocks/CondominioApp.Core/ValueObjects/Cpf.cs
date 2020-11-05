using System;
using System.Text.RegularExpressions;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Utils;

namespace CondominioApp.Core.ValueObjects
{
    public class Cpf
    {
        public const int Maxlength = 14;
        public string Numero { get; private set; }

        protected Cpf() { }

        public Cpf(string pCpf)
        {
            setNumero(pCpf);
        }

        private void setNumero(string cpfStr)
        {
            if (string.IsNullOrEmpty(cpfStr)) return;

            Guarda.ValidarTamanho(cpfStr, Maxlength);

            Regex regex = new Regex(@"^((\d{3}).(\d{3}).(\d{3})-(\d{2}))*$");
            Match match = regex.Match(cpfStr);

            if (match.Success)
            {
                cpfStr = cpfStr.ApenasNumeros(cpfStr);

                if (IsCpf(cpfStr))
                    Numero = cpfStr;
                else
                    throw new DomainException("Número de CPF inválido");
            }
            else
                throw new DomainException("Número de CPF não formatado");

        }

        public string ObterNumeroFormatado()
        {
            string nCpfStr = "";
            int ct = 0;
            int ctInterno = 0;
            if (!string.IsNullOrEmpty(Numero))
            {
                foreach (var digito in Numero)
                {
                    ct++;
                    nCpfStr += digito;
                    if (ct == 3)
                    {
                        ctInterno++;
                        if (ctInterno > 2)
                            nCpfStr += "-";
                        else
                            nCpfStr += ".";
                        ct = 0;
                    }
                }

                return nCpfStr;
            }
            return Numero;
        }

        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public override bool Equals(object obj)
        {
            var cpf = (Cpf)obj;

            return Numero == cpf.Numero;
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
