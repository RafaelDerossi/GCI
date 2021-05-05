using CondominioApp.Core.Data;
using CondominioApp.Core.Enumeradores;
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
                    return await _context.AreasComunsFlat
                                         .AsNoTracking()
                                         .Where(expression)
                                         .Include(a=>a.Periodos)
                                         .OrderByDescending(x => x.Nome)
                                         .Take(take)
                                         .ToListAsync();

                return await _context.AreasComunsFlat
                                     .AsNoTracking()
                                     .Where(expression)
                                     .Include(a => a.Periodos)
                                     .OrderByDescending(x => x.Nome)
                                     .ToListAsync();
            }

            if (take > 0)
                return await _context.AreasComunsFlat
                                     .AsNoTracking()
                                     .Where(expression)
                                     .Include(a => a.Periodos)
                                     .OrderBy(x => x.Nome)
                                     .Take(take)
                                     .ToListAsync();

            return await _context.AreasComunsFlat
                                 .AsNoTracking()
                                 .Where(expression)
                                 .Include(a => a.Periodos)
                                 .OrderBy(x => x.Nome)
                                 .ToListAsync();
        }

        public async Task<AreaComumFlat> ObterPorId(Guid Id)
        {
            return await _context.AreasComunsFlat
                .Include(a => a.Periodos)
                .FirstOrDefaultAsync(a => a.Id == Id && !a.Lixeira);
        }

        public async Task<IEnumerable<AreaComumFlat>> ObterTodos()
        {
            return await _context.AreasComunsFlat
                                 .Include(a => a.Periodos)
                                 .Where(a => !a.Lixeira)
                                 .OrderBy(x => x.Nome)
                                 .ToListAsync();
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
            IEnumerable<ReservaFlat> reservas = new List<ReservaFlat>();

            if (take > 0)
                reservas = await _context.ReservasFlat
                                        .AsNoTracking()
                                        .Where(expression)                                        
                                        .Take(take)
                                        .ToListAsync();
            else
                reservas = await _context.ReservasFlat
                                        .AsNoTracking()
                                        .Where(expression)                
                                        .ToListAsync();


            if (OrderByDesc)
            {
                reservas = reservas
                 .OrderByDescending(r => r.DataDeRealizacao)
                 .ThenByDescending(r => r.ObterHoraInicio)
                 .ThenByDescending(r => r.DataDeCadastro)
                 .ToList();

                return reservas;
            }


            reservas = reservas
                    .OrderBy(r => r.DataDeRealizacao)
                    .ThenBy(r => r.ObterHoraInicio)
                    .ThenBy(r => r.DataDeCadastro)
                    .ToList();

            return reservas;
        }
        
        public async Task<ReservaFlat> ObterReservaPorId(Guid Id)
        {
            return await _context.ReservasFlat                
                .FirstOrDefaultAsync(a => a.Id == Id && !a.Lixeira);
        }

        public async Task<int> ObterQtdDeReservasProcessando()
        {
            return await _context.ReservasFlat.Where(c => c.Status == StatusReserva.PROCESSANDO && !c.Lixeira).CountAsync();
        }

        public async Task<ReservaFlat> ObterPrimeiraNaFilaParaSerProcessada()
        {
            return await _context.ReservasFlat.Where(r => r.Status == StatusReserva.PROCESSANDO && !r.Lixeira)
                                          .OrderByDescending(r => r.DataDeCadastro)
                                          .FirstOrDefaultAsync();
        }



        public void AdicionarPeriodo(PeriodoFlat entity)
        {
            _context.PeriodosFlat.Add(entity);
        }

        public void RemoverPeriodo(PeriodoFlat entity)
        {
            _context.PeriodosFlat.Remove(entity);
        }

        public void AtualizarPeriodo(PeriodoFlat entity)
        {
            _context.PeriodosFlat.Update(entity);
        }

        public async Task<PeriodoFlat> ObterPeriodoPorId(Guid Id)
        {
            return await _context.PeriodosFlat
                .FirstOrDefaultAsync(a => a.Id == Id && !a.Lixeira);
        }


        public void AdicionarHistoricoReserva(HistoricoReservaFlat entity)
        {
            _context.HistoricosReservasFlat.Add(entity);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
        
    }
}
