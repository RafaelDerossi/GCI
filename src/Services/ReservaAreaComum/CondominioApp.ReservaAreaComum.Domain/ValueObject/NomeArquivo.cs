using System;
using System.IO;
using System.Linq;
using CondominioApp.Core.DomainObjects;

namespace CondominioApp.ReservaAreaComum.Domain.ValueObjects
{
    public class NomeArquivo
    {
        public const int NomeArquivoMaximo = 200;
        public string NomeOriginal { get; private set; }
        public string NomeDoArquivo { get; private set; }
        public string ExtensaoDoArquivo { get; private set; }

        protected NomeArquivo() { }

        public NomeArquivo(string nomeOriginal, Guid arquivoId)
        {
            SetNomeOriginal(nomeOriginal);
            SetNomeDoArquivo(nomeOriginal, arquivoId);
        }

        public void SetNomeOriginal(string nomeOriginal)
        {
            if (string.IsNullOrEmpty(nomeOriginal))
            {
                ExtensaoDoArquivo = "";
                NomeOriginal = "";
                return;
            }

            string Extensao = Path.GetExtension(nomeOriginal);

            if (Extensao == null || Extensao == "") throw new DomainException("Tipo de arquivo inválido!");

            ExtensaoDoArquivo = Extensao.Replace(".", "");

            NomeOriginal = nomeOriginal;
        }

        public void SetNomeDoArquivo(string nomeArquivo, Guid arquivoId)
        {
            if (string.IsNullOrEmpty(nomeArquivo))
                NomeDoArquivo = "";
            
            NomeDoArquivo = $"{arquivoId}.{ExtensaoDoArquivo}";            
        }
    }
}