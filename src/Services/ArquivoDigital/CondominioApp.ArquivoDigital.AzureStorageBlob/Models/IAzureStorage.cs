
namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Models
{
    public interface IAzureStorage
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string QueueName { get; set; }
        public string Container { get; set; }
        public string ThumbnailContainer { get; set; }

    }
}
