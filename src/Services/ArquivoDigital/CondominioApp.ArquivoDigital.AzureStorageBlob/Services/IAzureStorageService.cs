using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Services
{
    public interface IAzureStorageService
    {
        Task<ValidationResult> SubirArquivo(IFormFile arquivo, string nomeDoArquivo, Guid condominioId);

        bool VerificaTipoDoArquivoPermitido(string nomeDoArquivo);
       
    }
}
