using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Services
{
    public interface IAzureStorageService
    {
        Task<RetornoDoSubirArquivo> SubirArquivo(IFormFile arquivo, string nomeDoArquivo);

        bool VerificaTipoDoArquivoPermitido(string nomeDoArquivo);
       
    }
}
