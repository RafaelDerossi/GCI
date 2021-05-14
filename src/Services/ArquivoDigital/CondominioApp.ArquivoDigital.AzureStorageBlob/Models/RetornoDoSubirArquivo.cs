
using FluentValidation.Results;

namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Models
{
    public class RetornoDoSubirArquivo
    {
        public string Url { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
