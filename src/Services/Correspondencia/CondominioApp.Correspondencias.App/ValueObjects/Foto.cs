using System;
using System.IO;
using System.Linq;
using CondominioApp.Core.DomainObjects;

namespace CondominioApp.Correspondencias.App.ValueObjects
{
    public class Foto
    {
        public const int NomeFotoMaximo = 200;
        public string NomeOriginal { get; private set; }
        public string NomeDoArquivo { get; private set; }

        protected Foto() { }

        public Foto(string nomeOriginal)
        {
            SetNomeOriginal(nomeOriginal);
            SetNomeDoArquivo();
        }

        public void SetNomeOriginal(string nomeOriginal)
        {
            if (string.IsNullOrEmpty(nomeOriginal))
            {
                NomeOriginal = "SemFoto.png";
                return;
            }

            NomeOriginal = nomeOriginal;
        }

        public void SetNomeDoArquivo()
        {
            string[] ListaDeExtensoes = { ".jpg", ".jpeg", ".png", ".gif" };

            if (NomeOriginal == "SemFoto.png")
            {
                NomeDoArquivo = "SemFoto.png";
                return;
            }

            string Extensao = Path.GetExtension(NomeOriginal);

            if (ListaDeExtensoes.ToList().All(x => x != Extensao)) throw new DomainException("Tipo de arquivo inválido!");

            NomeDoArquivo = $"{Guid.NewGuid()}{Extensao}";
        }
    }
}