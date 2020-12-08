using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Comunicados.App.Data.Repository
{
    public class ComunicadoRepository : IComunidadoRepository
    {
        private readonly ComunicadoContextDB _context;

        public ComunicadoRepository(ComunicadoContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Comunicado> ObterPorId(Guid Id)
        {
            return await _context.Comunicados                    
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<IEnumerable<Comunicado>> ObterTodos()
        {
            return await _context.Comunicados
                .Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Comunicado>> Obter(Expression<Func<Comunicado, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Comunicados
                        .AsNoTracking()  
                        .Where(expression)
                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.  Comunicados
                    .AsNoTracking()
                    .Where(expression)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync();
            }

            if (take > 0)
                return await _context.Comunicados
                    .AsNoTracking()
                    .Where(expression)                    
                    .OrderBy(x => x.DataDeCadastro)
                    .Take(take)
                    .ToListAsync();

            return await _context.Comunicados
                .AsNoTracking()
                .Where(expression)                
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync();
        }

       
        public void Adicionar(Comunicado entity)
        {
            _context.Comunicados.Add(entity);
        }

        public void Atualizar(Comunicado entity)
        {
            _context.Comunicados.Update(entity);
        }

        public void Apagar(Func<Comunicado, bool> predicate)
        {
            _context.Comunicados.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }



        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
