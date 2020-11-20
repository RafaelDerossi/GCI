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
    public class ParceiroRepository : IParceiroRepository
    {
        public const int QtdMax = 20;

        private readonly MarketplaceContext _ContextoBanco;
        public ParceiroRepository(MarketplaceContext ContextoBanco)
        {
            _ContextoBanco = ContextoBanco;
        }
        public IUnitOfWorks UnitOfWork => _ContextoBanco;

        public void Adicionar(Parceiro entity)
        {
            _ContextoBanco.Parceiros.Add(entity);
        }

        public void Apagar(Func<Parceiro, bool> predicate)
        {
            _ContextoBanco.Parceiros.Where(predicate).ToList()
                            .ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(Parceiro entity)
        {
            _ContextoBanco.Parceiros.Update(entity);
        }

        public async Task<IEnumerable<Parceiro>> Obter(Expression<Func<Parceiro, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _ContextoBanco.Parceiros.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _ContextoBanco.Parceiros.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
            }

            if (take > 0)
                return await _ContextoBanco.Parceiros.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _ContextoBanco.Parceiros.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
        }

        public async Task<Parceiro> ObterPorId(Guid Id)
        {
            return await _ContextoBanco.Parceiros.Include(parceiro => parceiro.Vendedores)
                                       .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Parceiro>> ObterTodos()
        {
            return await _ContextoBanco.Parceiros.ToListAsync();
        }


        public async Task<IEnumerable<Vendedor>> ObterTodosOsVendedores()
        {
            return await _ContextoBanco.Vendedores.ToListAsync();
        }

        public async Task<IEnumerable<Vendedor>> ObterVendedores(Expression<Func<Vendedor, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _ContextoBanco.Vendedores
                                    .Include(p => p.Parceiro)
                                    .AsNoTracking().Where(expression)
                                    .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _ContextoBanco.Vendedores
                                    .Include(p => p.Parceiro)
                                    .AsNoTracking().Where(expression)
                                    .OrderByDescending(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
            }

            if (take > 0)
                return await _ContextoBanco.Vendedores
                                    .Include(p => p.Parceiro)
                                    .AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _ContextoBanco.Vendedores
                                    .Include(p => p.Parceiro)
                                    .AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
        }


        public async Task<Vendedor> ObterVendedorPorId(Guid Id)
        {
            return await _ContextoBanco.Vendedores.FindAsync(Id);
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            _ContextoBanco.Vendedores.Add(vendedor);
        }

        public void AtualizarVendedor(Vendedor vendedor)
        {
            _ContextoBanco.Vendedores.Update(vendedor);
        }

        public void Dispose()
        {
            _ContextoBanco?.Dispose();
        }

    }
}
