using CondominioApp.Core.Data;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.Interfaces;
using CondominioApp.Portaria.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Infra.Data.Repository
{
    public class PortariaRepository : IPortariaRepository
    {
        private readonly PortariaContextDB _context;
       
        public PortariaRepository(PortariaContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;




        public void Adicionar(Visitante entity)
        {
          _context.Visitantes.Add(entity);         
        }

        public void Apagar(Func<Visitante, bool> predicate)
        {
            _context.Visitantes.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(Visitante entity)
        {
            _context.Visitantes.Update(entity);
        }



        public void AdicionarVisita(Visita entity)
        {
            _context.Visitas.Add(entity);
        }

        public void RemoverVisita(Visita entity)
        {
            _context.Visitas.Remove(entity);
        }

        public void AtualizarVisita(Visita entity)
        {
            _context.Visitas.Update(entity);
        }




        public async Task<IEnumerable<Visitante>> Obter(Expression<Func<Visitante, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Visitantes.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Visitantes.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.Visitantes.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.Visitantes.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<Visitante> ObterPorId(Guid Id)
        {
            return await _context.Visitantes                
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<Visitante> ObterPorIdAsNoTracking(Guid Id)
        {
            return await _context.Visitantes
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<Visita> ObterVisitaPorId(Guid Id)
        {
            return await _context.Visitas
                .FirstOrDefaultAsync(a => a.Id == Id);
        }
                
        public async Task<IEnumerable<Visitante>> ObterTodos()
        {
            return await _context.Visitantes.Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<bool> VisitanteJaCadastradoPorDocumento(string documento, Guid visitanteId)
        {
            return await _context.Visitantes
                .CountAsync(u => !u.Lixeira && u.Documento == documento && u.Id != visitanteId) > 0;
        }

      


        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
