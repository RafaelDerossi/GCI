using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Infra.Data.Repository
{
    public class AreaComumRepository : IAreaComumRepository
    {
        private readonly ReservaAreaComumContextDB _context;
       
        public AreaComumRepository(ReservaAreaComumContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(AreaComum entity)
        {
            _context.AreasComuns.Add(entity);       
        }

        public void Apagar(Func<AreaComum, bool> predicate)
        {
            _context.AreasComuns.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(AreaComum entity)
        {
            _context.AreasComuns.Update(entity);
        }

        public void AdicionarPeriodo(Periodo entity)
        {
            _context.Periodos.Add(entity);
        }

        public void RemoverPeriodo(Periodo entity)
        {
            _context.Periodos.Remove(entity);
        }
       
        public void AdicionarReserva(Reserva entity)
        {
            _context.Reservas.Add(entity);
        }
       


        public async Task<IEnumerable<AreaComum>> Obter(Expression<Func<AreaComum, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.AreasComuns.AsNoTracking().Include(a => a.Periodos).Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.AreasComuns.AsNoTracking().Include(a => a.Periodos).Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.AreasComuns.AsNoTracking().Include(a => a.Periodos).Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.AreasComuns.AsNoTracking().Include(a => a.Periodos).Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<AreaComum> ObterPorId(Guid Id)
        {
            return await _context.AreasComuns
                .Include(a => a.Periodos)
                .Include(a => a.Reservas)
                .FirstOrDefaultAsync(a => a.Id == Id);
        }


        public async Task<IEnumerable<AreaComum>> ObterTodos()
        {
            return await _context.AreasComuns.Where(u => !u.Lixeira).Include(a => a.Periodos).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
