using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Automacao.App.Models;
using CondominioApp.Automacao.Models;
using CondominioApp.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Automacao.App.Data.Repository
{
    public class CondominioCredencialRepository : ICondominioCredencialRepository
    {
        private readonly AutomacaoContextDB _context;

        public CondominioCredencialRepository(AutomacaoContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;



        public async Task<CondominioCredencial> ObterPorId(Guid Id)
        {
            return await _context.CondominiosCredenciais                 
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<CondominioCredencial>> ObterTodos()
        {
            return await _context.CondominiosCredenciais                
                .Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<CondominioCredencial>> Obter(Expression<Func<CondominioCredencial, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.CondominiosCredenciais                        
                        .AsNoTracking()  
                        .Where(expression)
                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.CondominiosCredenciais                    
                    .AsNoTracking()
                    .Where(expression)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync();
            }

            if (take > 0)
                return await _context.CondominiosCredenciais                    
                    .AsNoTracking()
                    .Where(expression)                    
                    .OrderBy(x => x.DataDeCadastro)
                    .Take(take)
                    .ToListAsync();

            return await _context.CondominiosCredenciais                
                .AsNoTracking()
                .Where(expression)                
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync();
        }
        
       


        public void Adicionar(CondominioCredencial entity)
        {
            _context.CondominiosCredenciais.Add(entity);
        }

        public void Atualizar(CondominioCredencial entity)
        {
            _context.CondominiosCredenciais.Update(entity);
        }

        public void Apagar(Func<CondominioCredencial, bool> predicate)
        {
            _context.CondominiosCredenciais.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }


       
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
