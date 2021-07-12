using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Core.Helpers
{
    public static class StoragePaths
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
    }
}