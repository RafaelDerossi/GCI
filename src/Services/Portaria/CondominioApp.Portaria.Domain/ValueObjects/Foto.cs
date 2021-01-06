using System.IO;
using System.Linq;
using CondominioApp.Core.DomainObjects;

namespace CondominioApp.Portaria.ValueObjects
{
    public class Foto
    {
        public const int NomeFotoMaximo = 200;
        public string NomeOriginal { get; private set; }
        public string NomeDoArquivo { get; private set; }

        protected Foto() { }

        public Foto(string nomeOriginal, string nomeDoArquivo)
        {
            SetNomeOriginal(nomeOriginal);
            setNomeDoArquivo(nomeDoArquivo);
        }

        public void SetNomeOriginal(string nomeOriginal)
        {
            if (string.IsNullOrEmpty(nomeOriginal))
            {
                NomeOriginal = "https://i.imgur.com/gxXxUm7.png";
                return;
            }

            NomeOriginal = nomeOriginal;
        }

        public void setNomeDoArquivo(string nomeDoArquivo)
        {
            string[] ListaDeExtensoes = { ".jpg", ".jpeg", ".png", ".gif" };

            if (string.IsNullOrEmpty(nomeDoArquivo))
            {
                NomeDoArquivo = "https://i.imgur.com/gxXxUm7.png";
                return;
            }

            string Extensao = Path.GetExtension(nomeDoArquivo);

            if (ListaDeExtensoes.ToList().All(x => x != Extensao)) throw new DomainException("Tipo de arquivo inválido!");

            NomeDoArquivo = nomeDoArquivo;
        }
    }
}