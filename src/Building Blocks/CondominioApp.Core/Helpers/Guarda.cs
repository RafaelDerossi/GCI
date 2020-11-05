using CondominioApp.Core.DomainObjects;

namespace CondominioApp.Core.Helpers
{
    public static class Guarda
    {
        public static void ValidarTamanho(string value, int maxLenght)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > maxLenght)
                    throw new DomainException("Tamanho da string excedido!");
            }
        }

        public static void ValidarTamanhoDaSenha(string value, int minLength, int maxLenght)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length < minLength || value.Length > maxLenght)
                    throw new DomainException("Tamanho da string não atente o padrão de senha (mínimo 5 de dígitos e máximo de 8)!");
            }
            else
            {
                throw new DomainException("Valor não pode ser vazio!");
            }
        }
    }
}
