using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Threading.Tasks;


namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Models
{
    public class AzureStorage : IAzureStorage
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string QueueName { get; set; }
        public string Container { get; set; }
        public string ThumbnailContainer { get; set; }

        public AzureStorage()
        {
            AccountName = "condominioappstorage";
            AccountKey = "+ox/Ueo0Udr1ad6354A9SZ0rDqau1ZkxzUL9hIHWgyte7Xxo/8Z3Wp9pkwGKSX24tsoZjm0OlHD2SOLtyNHrPg==";            
            Container = "condominioapp";
            ThumbnailContainer = "thumb";
        }


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

    }
}
