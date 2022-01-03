using Microsoft.EntityFrameworkCore;
using GCI.Core.Data;
using GCI.Acoes.Domain;
using GCI.Acoes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GCI.Acoes.Infra.Data.Repository
{
    public class AcaoRepository : IAcaoRepository
    {
        private readonly AcaoContextDB _context;
       
        public AcaoRepository(AcaoContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(Acao entity)
        {
            _context.Acoes.Add(entity);
        }

        public void Atualizar(Acao entity)
        {
            _context.Acoes.Update(entity);
        }

        public void Apagar(Func<Acao, bool> predicate)
        {
            _context.Acoes.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<Acao> ObterPorId(Guid Id)
        {
            return await _context.Acoes
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<Acao>> Obter(Expression<Func<Acao, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Acoes
                                            .AsNoTracking()
                                            .Where(expression)
                                            .OrderByDescending(x => x.DataDeCadastro)
                                            .Take(take)
                                            .ToListAsync();

                return await _context.Acoes
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro)
                                        .ToListAsync();
            }

            if (take > 0)
                return await _context.Acoes
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderBy(x => x.DataDeCadastro)
                                        .Take(take)
                                        .ToListAsync();

            return await _context.Acoes
                                    .AsNoTracking()
                                    .Where(expression)
                                    .OrderBy(x => x.DataDeCadastro)
                                    .ToListAsync();
        }

        public async Task<bool> VerificaCodigoJaCadastrado(string codigo)
        {
            return await _context.Acoes
                .Where(u => u.Codigo == codigo && !u.Lixeira).CountAsync() > 0;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
