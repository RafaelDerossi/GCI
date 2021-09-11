using CondominioApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public interface IArquivoDigitalRepository : IRepository<Pasta>
    {
        Task<Pasta> ObterPorIdComConteudo(Guid id);
        
        Task<Arquivo> ObterArquivoPorId(Guid id);

        Task<IEnumerable<Arquivo>> ObterArquivo(Expression<Func<Arquivo, bool>> expression, bool OrderByDesc = false, int take = 0);

        void AdicionarArquivo(Arquivo entity);

        void AtualizarArquivo(Arquivo entity);

        void ApagarArquivo(Func<Arquivo, bool> predicate);
    }
}