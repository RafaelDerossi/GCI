using CondominioApp.ArquivoDigital.AzureStorageBlob.Helpers;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using System.IO;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly IAzureStorage _storage;
        private ValidationResult ValidationResult { get; set; }

        public AzureStorageService(IAzureStorage storage)
        {
            _storage = storage;
            ValidationResult = new ValidationResult();
        }

        public async Task<RetornoDoSubirArquivo> SubirArquivo(IFormFile arquivo, string nomeDoArquivo)
        {
            using var stream = arquivo.OpenReadStream();
            string url = "";
            try
            {
                url = await StorageHelper.UploadFileToStorage(stream, nomeDoArquivo, _storage);
            }
            catch (System.Exception ex)
            {
                AdicionarErros(ex.Message);
            }           

            return new RetornoDoSubirArquivo()
            {
                Url = url,
                ValidationResult = ValidationResult
            };
        }

        public bool VerificaTipoDoArquivoPermitido(string nomeDoArquivo)
        {
            return StorageHelper.VerificaTipoDoArquivoPermitido(nomeDoArquivo);
        }

        private void AdicionarErros(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
    }
}
