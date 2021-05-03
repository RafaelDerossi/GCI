using CondominioApp.Core.DomainObjects;
using System.Text.RegularExpressions;

namespace CondominioApp.Usuarios.App.ValueObjects
{
    public class Cep
    {
        public string Numero { get; private set; }

        protected Cep() { }

        public Cep(string pCep)
        {
            setCep(pCep);
        }

        public void setCep(string cepNumero)
        {
            if (string.IsNullOrEmpty(cepNumero)) return;

            Regex regex = new Regex(@"^\d{5}-\d{3}$");
            Match match = regex.Match(cepNumero);

            if (!match.Success)
                throw new DomainException("Número de CEP não formatado");

            Numero = cepNumero.Trim().Replace("-", "");            
        }
    }
}