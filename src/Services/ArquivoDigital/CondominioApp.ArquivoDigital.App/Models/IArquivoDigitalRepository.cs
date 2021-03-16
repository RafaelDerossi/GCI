using CondominioApp.Core.Data;
using System;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public interface IArquivoDigitalRepository : IRepository<Pasta>
    {
        Task<Arquivo> ObterArquivoPorId(Guid id);


        void AdicionarArquivo(Arquivo entity);

        void AtualizarArquivo(Arquivo entity);

        void ApagarArquivo(Func<Arquivo, bool> predicate);
    }
}