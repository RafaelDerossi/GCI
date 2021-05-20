﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;



namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Helpers
{
    public class StorageHelper
    {
        public static async Task<string> UploadFileToStorage(IFormFile arquivo, string fileName,
            IAzureStorage storage)
        {            
            var storageCredentials = new StorageCredentials(storage.AccountName, storage.AccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(storage.Container);
            fileName = string.Concat(@"Uploads\", fileName);
            var blockBlob = container.GetBlockBlobReference(fileName);
            blockBlob.Properties.ContentType = arquivo.ContentType;

            using var fileStream = arquivo.OpenReadStream();

            await blockBlob.UploadFromStreamAsync(fileStream);
         
            return blockBlob.SnapshotQualifiedStorageUri.PrimaryUri.ToString();
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
