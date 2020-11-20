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
    public class ItemDeVendaRepository : IItemDeVendaRepository
    {
        public const int QtdMax = 50;
        
        private readonly MarketplaceContext _ContextoBanco;

        public ItemDeVendaRepository(MarketplaceContext ContextoBanco)
        {
            _ContextoBanco = ContextoBanco;
        }

        public IUnitOfWorks UnitOfWork => _ContextoBanco;

        public void Adicionar(ItemDeVenda entity)
        {
            _ContextoBanco.ItensDeVenda.Add(entity);
        }

        public void Apagar(Func<ItemDeVenda, bool> predicate)
        {
            _ContextoBanco.ItensDeVenda.Where(predicate).ToList()
                           .ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(ItemDeVenda entity)
        {
            _ContextoBanco.ItensDeVenda.Update(entity);
        }

        public async Task<IEnumerable<ItemDeVenda>> Obter(Expression<Func<ItemDeVenda, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _ContextoBanco.ItensDeVenda
                                        .Include(x => x.Vendedor)
                                        .Include(p => p.Produto).ThenInclude(p => p.Fotos)
                                        .AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _ContextoBanco.ItensDeVenda
                                        .Include(x => x.Vendedor)
                                        .Include(p => p.Produto).ThenInclude(p => p.Fotos)
                                        .AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
            }

            if (take > 0)
                return await _ContextoBanco.ItensDeVenda
                                        .Include(x => x.Vendedor)
                                        .Include(p => p.Produto).ThenInclude(p => p.Fotos)
                                        .AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _ContextoBanco.ItensDeVenda
                                    .Include(x => x.Vendedor)
                                    .Include(p => p.Produto).ThenInclude(p => p.Fotos)
                                    .AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
        }

        public async Task<ItemDeVenda> ObterPorId(Guid Id)
        {
            return await _ContextoBanco.ItensDeVenda.FindAsync(Id);
        }

        public async Task<IEnumerable<ItemDeVenda>> ObterTodos()
        {
            return await _ContextoBanco.ItensDeVenda.ToListAsync();
        }

        public ItemDeVenda ObterItemDeVendaAleatorio()
        {
            DateTime Hoje = DateTime.Now.Date;

            return _ContextoBanco.ItensDeVenda.Include(x => x.Vendedor).Include(p => p.Produto).ThenInclude(f => f.Fotos)
                                            .Where(x => !x.Lixeira &&
                                                    x.DataDeInicio <= Hoje &&
                                                    x.DataDeFim >= Hoje)
                                            .OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();
        }

        public bool VerificarExistenciaDoItemDeVenda(Guid ProdutoId, Guid CondominioId)
        {
            DateTime Hoje = DateTime.Now.Date;

            return _ContextoBanco.ItensDeVenda.Any(x => x.ProdutoId == ProdutoId &&
                                                    x.CondominioId == CondominioId &&
                                                    x.DataDeInicio <= Hoje &&
                                                    x.DataDeFim >= Hoje &&
                                                    !x.Lixeira);
        }

        public async Task<IEnumerable<Lead>> ObterTodosOsLeads()
        {
            return await _ContextoBanco.Leads.ToListAsync();
        }

        public async Task<IEnumerable<Lead>> ObterLeads(Expression<Func<Lead, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _ContextoBanco.Leads
                                        .Include(p => p.ItemDeVenda).ThenInclude(p => p.Produto)
                                        .AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _ContextoBanco.Leads
                                        .Include(p => p.ItemDeVenda).ThenInclude(p => p.Produto)
                                        .AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
            }

            if (take > 0)
                return await _ContextoBanco.Leads
                                        .Include(p => p.ItemDeVenda).ThenInclude(p => p.Produto)
                                        .AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _ContextoBanco.Leads
                                    .Include(p => p.ItemDeVenda).ThenInclude(p => p.Produto)
                                    .AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).Take(QtdMax).ToListAsync();
        }

        public async Task<Lead> ObterLeadPorId(Guid Id)
        {
            return await _ContextoBanco.Leads.FindAsync(Id);
        }

        public void AdicionarLead(Lead Lead)
        {
            _ContextoBanco.Leads.Add(Lead);
        }

        public async Task<IEnumerable<ItemDeVenda>> ObterItensDoParceiro(Guid ParceiroId)
        {
            return await _ContextoBanco.ItensDeVenda.Where(x => x.ParceiroId == ParceiroId && x.Lixeira).ToListAsync();
        }

        public void Dispose()
        {
            _ContextoBanco?.Dispose();
        }

    }
}
