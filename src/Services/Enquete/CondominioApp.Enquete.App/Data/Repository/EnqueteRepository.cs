using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Enquetes.App.Data;
using CondominioApp.Enquetes.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Enquetes.App.Data.Repository
{
    public class EnqueteRepository : IEnqueteRepository
    {
        private readonly EnqueteContextDB _context;

        public EnqueteRepository(EnqueteContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Enquete> ObterPorId(Guid Id)
        {
            return await _context.Enquetes
                .Include(e => e.Alternativas)
                    .ThenInclude(it => it.Respostas)
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<IEnumerable<Enquete>> ObterTodos()
        {
            return await _context.Enquetes
                .Include(e => e.Alternativas)
                    .ThenInclude(it => it.Respostas)
                .Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Enquete>> Obter(Expression<Func<Enquete, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Enquetes
                        .AsNoTracking()                       
                        .Include(e => e.Alternativas)
                            .ThenInclude(it => it.Respostas)
                         .Where(expression)
                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Enquetes
                    .AsNoTracking()                    
                    .Include(e => e.Alternativas)
                        .ThenInclude(it => it.Respostas)
                    .Where(expression)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync();
            }

            if (take > 0)
                return await _context.Enquetes
                    .AsNoTracking()
                    .Include(e => e.Alternativas)
                        .ThenInclude(it => it.Respostas)
                    .Where(expression)                    
                    .OrderBy(x => x.DataDeCadastro)
                    .Take(take)
                    .ToListAsync();

            return await _context.Enquetes
                .AsNoTracking()
                .Include(e => e.Alternativas)
                    .ThenInclude(it => it.Respostas)
                .Where(expression)                
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync();
        }

       
        public void Adicionar(Enquete entity)
        {
            _context.Enquetes.Add(entity);
        }

        public void Atualizar(Enquete entity)
        {
            _context.Enquetes.Update(entity);
        }

        public void Apagar(Func<Enquete, bool> predicate)
        {
            _context.Enquetes.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }



        public async Task<AlternativaEnquete> ObterAlternativaPorId(Guid Id)
        {
            return await _context.AlternativasEnquete
                .Include(a=>a.Respostas)
                .FirstOrDefaultAsync(u => u.Id == Id);
        }


        public void AdicionarResposta(RespostaEnquete entity)
        {
            _context.RespostasEnquete.Add(entity);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
