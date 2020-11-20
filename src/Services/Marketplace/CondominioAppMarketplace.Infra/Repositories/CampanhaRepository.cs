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
    public class CampanhaRepository : ICampanhaRepository
    {
        private readonly MarketplaceContext _ContextoBanco;

        public CampanhaRepository(MarketplaceContext ContextoBanco)
        {
            _ContextoBanco = ContextoBanco;
        }

        public IUnitOfWorks UnitOfWork => _ContextoBanco;

        public void Adicionar(Campanha entity)
        {
            _ContextoBanco.Campanhas.Add(entity);
        }

        public void Apagar(Func<Campanha, bool> predicate)
        {
            _ContextoBanco.Campanhas.Where(predicate).ToList()
                            .ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(Campanha entity)
        {
            _ContextoBanco.Campanhas.Update(entity);
        }

        public async Task<IEnumerable<Campanha>> Obter(Expression<Func<Campanha, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _ContextoBanco.Campanhas.Include(i => i.ItemDeVenda).ThenInclude(p => p.Produto)
                                        .AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();

                return await _ContextoBanco.Campanhas.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _ContextoBanco.Campanhas.Include(i => i.ItemDeVenda).ThenInclude(p => p.Produto)
                                        .AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).ToListAsync();

            return await _ContextoBanco.Campanhas.Include(i => i.ItemDeVenda).ThenInclude(p => p.Produto)
                                    .AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<Campanha> ObterPorId(Guid Id)
        {
            return await _ContextoBanco.Campanhas.FindAsync(Id);
        }

        public async Task<IEnumerable<Campanha>> ObterTodos()
        {
            return await _ContextoBanco.Campanhas.ToListAsync();
        }

        public bool VerificaExistenciaDaCampanha(Guid ItemDeVendaId)
        {
            DateTime Hoje = DateTime.Now.Date;

            return _ContextoBanco.Campanhas.Any(x => x.ItemDeVendaId == ItemDeVendaId &&
                                                x.DataDeInicio <= Hoje &&
                                                x.DataDeFim >= Hoje &&
                                                !x.Lixeira);
        }

        public void Dispose()
        {
            _ContextoBanco?.Dispose();
        }

    }
}
