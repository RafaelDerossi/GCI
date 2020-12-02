using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Correspondencias.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Correspondencias.App.Data.Repository
{
    public class CorrespondenciaRepository : ICorrespondenciaRepository
    {
        private readonly CorrespondenciaContextDB _context;

        public CorrespondenciaRepository(CorrespondenciaContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Correspondencia> ObterPorId(Guid Id)
        {
            return await _context.Correspondencias                    
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<IEnumerable<Correspondencia>> ObterTodos()
        {
            return await _context.Correspondencias
                .Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Correspondencia>> Obter(Expression<Func<Correspondencia, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Correspondencias
                        .AsNoTracking()  
                        .Where(expression)
                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Correspondencias
                    .AsNoTracking()
                    .Where(expression)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync();
            }

            if (take > 0)
                return await _context.Correspondencias
                    .AsNoTracking()
                    .Where(expression)                    
                    .OrderBy(x => x.DataDeCadastro)
                    .Take(take)
                    .ToListAsync();

            return await _context.Correspondencias
                .AsNoTracking()
                .Where(expression)                
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync();
        }

       
        public void Adicionar(Correspondencia entity)
        {
            _context.Correspondencias.Add(entity);
        }

        public void Atualizar(Correspondencia entity)
        {
            _context.Correspondencias.Update(entity);
        }

        public void Apagar(Func<Correspondencia, bool> predicate)
        {
            _context.Correspondencias.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }



        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
