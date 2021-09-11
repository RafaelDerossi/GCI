﻿using CondominioApp.Core.Data;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Infra.Data.Repository
{
    public class ReservaAreaComumRepository : IReservaAreaComumRepository
    {
        private readonly ReservaAreaComumContextDB _context;
       
        public ReservaAreaComumRepository(ReservaAreaComumContextDB context)
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

        public void AtualizarReserva(Reserva entity)
        {
            _context.Reservas.Update(entity);
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

        public async Task<AreaComum> ObterPorId(Guid id)
        {
            var reservas = _context.Reservas.Where(r => r.AreaComumId == id &&
                                                   r.DataDeCadastro > DateTime.Today.AddMonths(-6) && 
                                                   (r.Status == StatusReserva.PROCESSANDO ||
                                                    r.Status == StatusReserva.APROVADA ||
                                                    r.Status == StatusReserva.NA_FILA ||
                                                    r.Status == StatusReserva.AGUARDANDO_APROVACAO) &&
                                                   !r.Lixeira).ToList();
            if (reservas == null)
                reservas = new List<Reserva>();

            var areaComum = await _context.AreasComuns
                .AsNoTracking()
                .Include(a => a.Periodos)
                .FirstOrDefaultAsync(a => a.Id == id && !a.Lixeira);

            if (areaComum != null)
            {
                areaComum.SetReservas(reservas);
                return areaComum;
            }

            return null;
        }

        public async Task<Reserva> ObterReservaPorId(Guid Id)
        {
            return await _context.Reservas
                .FirstOrDefaultAsync(a => a.Id == Id && !a.Lixeira);
        }

        public async Task<Guid> Obter_AreaComumId_Por_ReservaId(Guid reservaId)
        {
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(a => a.Id == reservaId);

            return reserva.AreaComumId;
        }

        public async Task<IEnumerable<AreaComum>> ObterTodos()
        {
            return await _context.AreasComuns.Where(u => !u.Lixeira).Include(a => a.Periodos).ToListAsync();
        }


        public async Task<int> ObterQtdDeReservasProcessando()
        {
            return await _context.Reservas.Where(c => c.Status == StatusReserva.PROCESSANDO && !c.Lixeira).CountAsync();
        }

        public async Task<int> ObterQtdDeReservasAguardandoAprovacaoAteHoje()
        {
            var dataHj = DataHoraDeBrasilia.Get().Date;

            return await _context.Reservas.Where(c => c.Status == StatusReserva.AGUARDANDO_APROVACAO && 
                                                      c.DataDeRealizacao <= dataHj &&
                                                     !c.Lixeira).CountAsync();
        }

        public async Task<int> ObterQtdDeReservasNaFilaAteHoje()
        {
            var dataHj = DataHoraDeBrasilia.Get().Date;
            return await _context.Reservas.Where(c => c.Status == StatusReserva.NA_FILA &&
                                                      c.DataDeRealizacao <= dataHj &&
                                                     !c.Lixeira).CountAsync();
        }

        public async Task<Reserva> ObterPrimeiraNaFilaParaSerProcessada()
        {
            return await _context.Reservas.Where(r => r.Status == StatusReserva.PROCESSANDO && !r.Lixeira)
                                          .OrderByDescending(r => r.DataDeCadastro)
                                          .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reserva>> ObterReservasAguardandoAprovacaoAteHoje()
        {
            var dataHj = DataHoraDeBrasilia.Get().Date;

            return await _context.Reservas.Where(c => c.Status == StatusReserva.AGUARDANDO_APROVACAO &&
                                                      c.DataDeRealizacao <= dataHj &&
                                                     !c.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> ObterReservasNaFilaAteHoje()
        {
            var dataHj = DataHoraDeBrasilia.Get().Date;

            return await _context.Reservas.Where(c => c.Status == StatusReserva.NA_FILA &&
                                                      c.DataDeRealizacao <= dataHj &&
                                                     !c.Lixeira).ToListAsync();
        }






        public void AdicionarFotoDaAreaComum(FotoDaAreaComum entity)
        {
            _context.FotosDaAreaComum.Add(entity);
        }

        public void ApagarFotoDaAreaComum(Func<FotoDaAreaComum, bool> predicate)
        {
            _context.FotosDaAreaComum.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void RemoverFotoDaAreaComum(FotoDaAreaComum entity)
        {
            _context.FotosDaAreaComum.Remove(entity);
        }


        public async Task<FotoDaAreaComum> ObterFotoDaAreaComumPorId(Guid fotoId)
        {
            return await _context.FotosDaAreaComum.FirstOrDefaultAsync(r => r.Id == fotoId && !r.Lixeira);            
        }

        public async Task<IEnumerable<FotoDaAreaComum>> ObterFotosDaAreaComum(Guid areaComumId)
        {
            return await _context.FotosDaAreaComum.Where(r => r.AreaComumId == areaComumId && !r.Lixeira).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}