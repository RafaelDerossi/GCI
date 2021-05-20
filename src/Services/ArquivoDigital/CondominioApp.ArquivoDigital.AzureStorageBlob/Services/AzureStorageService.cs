using CondominioApp.ArquivoDigital.AzureStorageBlob.Helpers;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using System.IO;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;

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

        public async Task<ValidationResult> SubirArquivo(IFormFile arquivo, string nomeDoArquivo, string pasta)
        {
            var caminhoDoArquivo = ObterCaminhoDoArquivo(nomeDoArquivo, pasta);                        
            try
            {
               await StorageHelper.UploadFileToStorage(arquivo, caminhoDoArquivo, _storage);
            }
            catch (System.Exception ex)
            {
                AdicionarErros(ex.Message);
            }           

            return ValidationResult;
        }

        public bool VerificaTipoDoArquivoPermitido(string nomeDoArquivo)
        {
            return StorageHelper.VerificaTipoDoArquivoPermitido(nomeDoArquivo);
        }

        private void AdicionarErros(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        private string ObterCaminhoDoArquivo(string nomeDoArquivo, string pasta)
        {
            return $"{pasta}/{nomeDoArquivo}";
        }
    }
}
