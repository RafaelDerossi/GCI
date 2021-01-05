using CondominioApp.Core.Data;
using CondominioApp.Principal.Infra.DataQuery;
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


      

        public void Adicionar(AreaComumFlat entity)
        {
            _context.AreasComunsFlat.Add(entity);
        }

        public void Atualizar(AreaComumFlat entity)
        {
            _context.AreasComunsFlat.Update(entity);
        }

        public void Apagar(Func<AreaComumFlat, bool> predicate)
        {
            _context.AreasComunsFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }



        public async Task<IEnumerable<AreaComumFlat>> Obter(Expression<Func<AreaComumFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.AreasComunsFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.AreasComunsFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.AreasComunsFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.AreasComunsFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<AreaComumFlat> ObterPorId(Guid Id)
        {
            return await _context.AreasComunsFlat
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<AreaComumFlat>> ObterTodos()
        {
            return await _context.AreasComunsFlat.ToListAsync();
        }

     


        public void AdicionarReserva(ReservaFlat entity)
        {
            _context.ReservasFlat.Add(entity);       
        }

        public void ApagarReserva(Func<ReservaFlat, bool> predicate)
        {
            _context.ReservasFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void AtualizarReserva(ReservaFlat entity)
        {
            _context.ReservasFlat.Update(entity);
        }

       
        public async Task<IEnumerable<ReservaFlat>> ObterReserva(Expression<Func<ReservaFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
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
        
        public async Task<ReservaFlat> ObterReservaPorId(Guid Id)
        {
            return await _context.ReservasFlat                
                .FirstOrDefaultAsync(a => a.Id == Id);
        }



        public void AdicionarPeriodo(PeriodoFlat entity)
        {
            _context.PeriodosFlat.Add(entity);
        }

        public void ApagarPeriodo(Func<PeriodoFlat, bool> predicate)
        {
            _context.PeriodosFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void AtualizarPeriodo(PeriodoFlat entity)
        {
            _context.PeriodosFlat.Update(entity);
        }

        public async Task<PeriodoFlat> ObterPeriodoPorId(Guid Id)
        {
            return await _context.PeriodosFlat
                .FirstOrDefaultAsync(a => a.Id == Id);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
        
    }
}
