using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Usuarios.App.Data.Repository
{
    public class MoradorQueryRepository : IMoradorQueryRepository
    {
        private readonly UsuarioQueryContextDB _context;

        public MoradorQueryRepository(UsuarioQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public async Task<MoradorFlat> ObterPorId(Guid Id)
        {
            return await _context.MoradoresFlat.Where(u => u.Id == Id && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MoradorFlat>> ObterTodos()
        {
            return await _context.MoradoresFlat.Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<MoradorFlat>> Obter(Expression<Func<MoradorFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.MoradoresFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.MoradoresFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.MoradoresFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.MoradoresFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public void Adicionar(MoradorFlat entity)
        {
            _context.MoradoresFlat.Add(entity);
        }

        public void Atualizar(MoradorFlat entity)
        {
            _context.MoradoresFlat.Update(entity);
        }

        public void Apagar(Func<MoradorFlat, bool> predicate)
        {
            _context.MoradoresFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

   
      
        public void Remover(MoradorFlat entity)
        {
            _context.MoradoresFlat.Remove(entity);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
