using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioAppPreCadastro.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioAppPreCadastro.App.Data.Repository
{
    public class LeadRepository : ILeadRepository
    {
        private readonly PreCadastroContextDB _context;

        public LeadRepository(PreCadastroContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;
        
        public async Task<Lead> ObterPorId(Guid Id)
        {
            return await _context.Leads.Include(c => c.Condominios)
                .FirstOrDefaultAsync(l => l.Id == Id);
        }

        public async Task<IEnumerable<Lead>> ObterTodos()
        {
            return await _context.Leads.AsNoTracking()
                        .Include(c => c.Condominios).Where(l => !l.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Lead>> Obter(Expression<Func<Lead, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Leads.Include(c => c.Condominios).AsNoTracking().Where(expression)
                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Leads.Include(c => c.Condominios).AsNoTracking().Where(expression)
                    .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.Leads.Include(c => c.Condominios).AsNoTracking().Where(expression)
                    .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.Leads.Include(c => c.Condominios).AsNoTracking().Where(expression)
                .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public void Adicionar(Lead entity)
        {
            _context.Leads.Add(entity);
        }

        public void Atualizar(Lead entity)
        {
            _context.Update(entity);
        }

        public void Apagar(Func<Lead, bool> predicate)
        {
            _context.Leads.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<Condominio> ObterCondominioPorId(Guid Id)
        {
            return await _context.Condominios.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}