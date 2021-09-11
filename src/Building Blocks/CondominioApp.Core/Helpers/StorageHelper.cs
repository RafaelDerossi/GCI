using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;


namespace CondominioApp.Core.Helpers
{
    public static class StorageHelper
    {
        private readonly static string PathStorage = @"https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/";
        private readonly static string PathSemFoto = @"https://i.imgur.com/gxXxUm7.png";

        public static string ObterUrlDeArquivo(string pasta, string nomeDoArquivo)
        {
            if (nomeDoArquivo == "")
                return PathSemFoto;

            return $@"{PathStorage}{pasta}/{nomeDoArquivo}";
        }       

        public static string ObterNomeDoArquivo(IFormFile arquivo)
        {
            var nomeArquivo = "";
            if (arquivo != null)
            {
                nomeArquivo = arquivo.FileName;
            }
            return nomeArquivo;
        }


        public static bool VerificaTipoDoArquivoPermitido(string nomeDoArquivo)
        {
            var nome = nomeDoArquivo.Trim('\"');
            string[] permittedExtensions = new string[] { ".jpg", ".png", ".gif", ".jpeg", ".xlsx", ".pdf" };

            var ext = Path.GetExtension(nome).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                return false;

            return true;
        }

        public static double ConverterBytesEmMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}