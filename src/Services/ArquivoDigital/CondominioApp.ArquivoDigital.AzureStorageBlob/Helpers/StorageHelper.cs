using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;



namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Helpers
{
    public class StorageHelper
    {
        public readonly static string PathStorage = @"https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads\";

        public static async Task<string> UploadFileToStorage(Stream fileStream, string fileName,
            IAzureStorage storage)
        {
            var storageCredentials = new StorageCredentials(storage.AccountName, storage.AccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(storage.Container);
            fileName = string.Concat(@"Uploads\", fileName);
            var blockBlob = container.GetBlockBlobReference(fileName);

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
