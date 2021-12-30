using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GCI.Core.DomainObjects;

namespace GCI.Core.Data
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        IQueryable<TDocument> AsQueryable();

        IEnumerable<TDocument> ObterPor(
            Expression<Func<TDocument, bool>> filterExpression);

        Task<IEnumerable<TDocument>> ObterPorAsync(Expression<Func<TDocument, bool>> filterExpression);

        IEnumerable<TProjected> FiltroPor<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);

        TDocument ObterDocumento(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> ObterDocumentoAsync(Expression<Func<TDocument, bool>> filterExpression);

        TDocument ObterPorId(string id);

        Task<TDocument> ObterPorIdAsync(string id);

        void Adicionar(TDocument document);

        Task AdicionarAsync(TDocument document);

        void AdicionarVarios(ICollection<TDocument> documents);

        Task AdicionarVariosAsync(ICollection<TDocument> documents);

        void Atualizar(TDocument document);

        Task AtualizarAsync(TDocument document);

        void Remover(Expression<Func<TDocument, bool>> filterExpression);

        Task RemoverAsync(Expression<Func<TDocument, bool>> filterExpression);

        void RemoverPorId(string id);

        Task RemoverPorIdAsync(string id);

        void RemoverVarios(Expression<Func<TDocument, bool>> filterExpression);

        Task RemoverVariosAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}