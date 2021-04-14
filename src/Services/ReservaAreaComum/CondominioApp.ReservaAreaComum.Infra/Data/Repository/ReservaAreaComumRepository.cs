using CondominioApp.Core.Data;
using CondominioApp.Core.Enumeradores;
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

            var aC = await _context.AreasComuns
                .AsNoTracking()
                .Include(a => a.Periodos)
                .FirstOrDefaultAsync(a => a.Id == id && !a.Lixeira);
            if (aC != null)
            {
                var areaComum = new AreaComum(aC.Nome, aC.Descricao, aC.TermoDeUso, aC.CondominioId,
                    aC.NomeCondominio, aC.Capacidade, aC.DiasPermitidos, aC.AntecedenciaMaximaEmMeses,
                    aC.AntecedenciaMaximaEmDias, aC.AntecedenciaMinimaEmDias, aC.AntecedenciaMinimaParaCancelamentoEmDias,
                    aC.RequerAprovacaoDeReserva, aC.TemHorariosEspecificos, aC.TempoDeIntervaloEntreReservas, aC.Ativa,
                    aC.TempoDeDuracaoDeReserva, aC.NumeroLimiteDeReservaPorUnidade, aC.PermiteReservaSobreposta,
                    aC.NumeroLimiteDeReservaSobreposta, aC.NumeroLimiteDeReservaSobrepostaPorUnidade,
                    aC.TempoDeIntervaloEntreReservasPorUnidade, aC.Periodos.ToList(), reservas.ToList());
                    areaComum.SetEntidadeId(aC.Id);
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

        public async Task<Reserva> ObterPrimeiraNaFilaParaSerProcessada()
        {
            return await _context.Reservas.Where(r => r.Status == StatusReserva.PROCESSANDO && !r.Lixeira)
                                          .OrderByDescending(r => r.DataDeCadastro)
                                          .FirstOrDefaultAsync();
        }

        

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
