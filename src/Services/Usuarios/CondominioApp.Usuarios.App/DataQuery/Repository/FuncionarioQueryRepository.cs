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
    public class FuncionarioQueryRepository : IFuncionarioQueryRepository
    {
        private readonly UsuarioQueryContextDB _context;

        public FuncionarioQueryRepository(UsuarioQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public async Task<FuncionarioFlat> ObterPorId(Guid Id)
        {
            return await _context.FuncionariosFlat.Where(u => u.Id == Id && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FuncionarioFlat>> ObterTodos()
        {
            return await _context.FuncionariosFlat.Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<FuncionarioFlat>> Obter(Expression<Func<FuncionarioFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.FuncionariosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.FuncionariosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.FuncionariosFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.FuncionariosFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public void Adicionar(FuncionarioFlat entity)
        {
            _context.FuncionariosFlat.Add(entity);
        }

        public void Atualizar(FuncionarioFlat entity)
        {
            _context.FuncionariosFlat.Update(entity);
        }

        public void Apagar(Func<FuncionarioFlat, bool> predicate)
        {
            _context.FuncionariosFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

   
      
        public void Remover(FuncionarioFlat entity)
        {
            _context.FuncionariosFlat.Remove(entity);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
