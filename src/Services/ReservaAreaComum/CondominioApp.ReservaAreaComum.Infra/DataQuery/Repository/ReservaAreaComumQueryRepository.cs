using CondominioApp.Core.Data;
using CondominioApp.Principal.Infra.DataQuery;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Infra.Data.Repository
{
    public class ReservaAreaComumQueryRepository : IReservaAreaComumQueryRepository
    {
        private readonly ReservaAreaComumQueryContextDB _context;
       
        public ReservaAreaComumQueryRepository(ReservaAreaComumQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(ReservaFlat entity)
        {
            _context.ReservasFlat.Add(entity);       
        }

        public void Apagar(Func<ReservaFlat, bool> predicate)
        {
            _context.ReservasFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(ReservaFlat entity)
        {
            _context.ReservasFlat.Update(entity);
        }

       
        public async Task<IEnumerable<ReservaFlat>> Obter(Expression<Func<ReservaFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.ReservasFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.ReservasFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.ReservasFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.ReservasFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }


        public async Task<ReservaFlat> ObterPorId(Guid Id)
        {
            return await _context.ReservasFlat                
                .FirstOrDefaultAsync(a => a.Id == Id);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<ReservaFlat>> ObterTodos()
        {
            return await _context.ReservasFlat.ToListAsync();
        }
    }
}
