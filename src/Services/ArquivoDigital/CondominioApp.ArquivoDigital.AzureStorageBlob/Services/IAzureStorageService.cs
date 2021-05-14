using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.AzureStorageBlob.Services
{
    public interface IAzureStorageService
    {
        Task<RetornoDoSubirArquivo> SubirArquivo(Stream stream, string nomeDoArquivo);

        bool VerificaTipoDoArquivoPermitido(string nomeDoArquivo);
       
    }
}
