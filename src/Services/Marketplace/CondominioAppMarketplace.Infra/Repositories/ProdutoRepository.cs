using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Interfaces;
using CondominioAppMarketplace.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CondominioAppMarketplace.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public const int QtdMax = 20;

        private readonly MarketplaceContext _ContextoBanco;

        public ProdutoRepository(MarketplaceContext ContextoBanco)
        {
            _ContextoBanco = ContextoBanco;
        }

        public IUnitOfWorks UnitOfWork => _ContextoBanco;

        public void Adicionar(Produto entity)
        {
            _ContextoBanco.Produtos.Add(entity);
        }

        public void Apagar(Func<Produto, bool> predicate)
        {
            _ContextoBanco.Produtos.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(Produto entity)
        {
            _ContextoBanco.Produtos.Update(entity);
        }

        public async Task<IEnumerable<Produto>> Obter(Expression<Func<Produto, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _ContextoBanco.Produtos
                                        .Include(f => f.Fotos)
                                        .AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _ContextoBanco.Produtos
                                        .Include(f => f.Fotos)
                                        .AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
            }

            if (take > 0)
                return await _ContextoBanco.Produtos
                                        .Include(f => f.Fotos)
                                        .AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _ContextoBanco.Produtos
                                    .Include(f => f.Fotos)
                                    .AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid Id)
        {
            return await _ContextoBanco.Produtos.Include(p => p.Fotos).FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _ContextoBanco.Produtos.ToListAsync();
        }


        public void AdicionarFoto(FotoDoProduto foto)
        {
            _ContextoBanco.FotosDosProdutos.Add(foto);
        }
        public void RemoverFoto(FotoDoProduto foto)
        {
            _ContextoBanco.FotosDosProdutos.Remove(foto);
        }

        public void Dispose()
        {
            _ContextoBanco?.Dispose();
        }
    }
}
