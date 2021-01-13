using CondominioApp.Core.Data;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Infra.DataQuery.Repository
{
    public class VisitanteQueryRepository : IVisitanteQueryRepository
    {
        private readonly PortariaQueryContextDB _context;
       
        public VisitanteQueryRepository(PortariaQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;




        public void Adicionar(VisitanteFlat entity)
        {
            _context.VisitantesFlat.Add(entity);       
        }

        public void Apagar(Func<VisitanteFlat, bool> predicate)
        {
            _context.VisitantesFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(VisitanteFlat entity)
        {
            _context.VisitantesFlat.Update(entity);
        }



        public void AdicionarVisita(VisitaFlat entity)
        {
            _context.VisitasFlat.Add(entity);
        }

        public void RemoverVisita(VisitaFlat entity)
        {
            _context.VisitasFlat.Remove(entity);
        }

        public void AtualizarVisita(VisitaFlat entity)
        {
            _context.VisitasFlat.Update(entity);
        }




        public async Task<IEnumerable<VisitanteFlat>> Obter(Expression<Func<VisitanteFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.VisitantesFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.VisitantesFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.VisitantesFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.VisitantesFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<VisitanteFlat> ObterPorId(Guid Id)
        {
            return await _context.VisitantesFlat
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<VisitaFlat> ObterVisitaPorId(Guid Id)
        {
            return await _context.VisitasFlat
                .FirstOrDefaultAsync(a => a.Id == Id);
        }
                
        public async Task<IEnumerable<VisitanteFlat>> ObterTodos()
        {
            return await _context.VisitantesFlat.Where(u => !u.Lixeira).ToListAsync();
        }

        

        public void Dispose()
        {
            _context?.Dispose();
        }
        
    }
}
