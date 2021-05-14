
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
    }
}
