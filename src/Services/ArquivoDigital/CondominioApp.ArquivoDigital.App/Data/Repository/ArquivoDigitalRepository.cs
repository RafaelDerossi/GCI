using CondominioApp.ArquivoDigital.App.Data;
using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Infra.Data.Repository
{
    public class ArquivoDigitalRepository : IArquivoDigitalRepository
    {
        private readonly ArquivoDigitalContextDB _context;
       
        public ArquivoDigitalRepository(ArquivoDigitalContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;


        #region Pasta
        
        public async Task<Pasta> ObterPorId(Guid id)
        {
          return await _context.Pastas
                .Include(p=>p.Arquivos)
                .Where(p => p.Id == id && !p.Lixeira)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pasta>> Obter(Expression<Func<Pasta, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Pastas
                          .AsNoTracking()
                          .Include(e => e.Arquivos)
                          .Where(expression)
                          .OrderByDescending(x => x.Titulo)
                          .Take(take)
                          .ToListAsync();

                return await _context.Pastas
                    .AsNoTracking()
                    .Include(e => e.Arquivos)                    
                    .Where(expression)
                    .OrderByDescending(x => x.Titulo)
                    .ToListAsync();
            }

            if (take > 0)
                return await _context.Pastas
                    .AsNoTracking()
                    .Include(e => e.Arquivos)
                    .Where(expression)
                    .OrderBy(x => x.Titulo)
                    .Take(take)
                    .ToListAsync();

            return await _context.Pastas
                .AsNoTracking()
                .Include(e => e.Arquivos)                
                .Where(expression)
                .OrderBy(x => x.Titulo)
                .ToListAsync();
        }       

        public async Task<IEnumerable<Pasta>> ObterTodos()
        {
            return await _context.Pastas
                .Include(p => p.Arquivos)
                .Where(p => !p.Lixeira)
                .ToListAsync();
        }


        public void Adicionar(Pasta entity)
        {
            _context.Pastas.Add(entity);       
        }

        public void Atualizar(Pasta entity)
        {
            _context.Pastas.Update(entity);
        }

        public void Apagar(Func<Pasta, bool> predicate)
        {
            _context.Pastas.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        #endregion


        #region Arquivo
        public async Task<Arquivo> ObterArquivoPorId(Guid id)
        {
            return await _context.Arquivos                  
                  .Where(p => p.Id == id && !p.Lixeira)
                  .FirstOrDefaultAsync();
        }


        public void AdicionarArquivo(Arquivo entity)
        {
            _context.Arquivos.Add(entity);
        }

        public void AtualizarArquivo(Arquivo entity)
        {
            _context.Arquivos.Update(entity);
        }

        public void ApagarArquivo(Func<Arquivo, bool> predicate)
        {
            _context.Arquivos.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        #endregion


        public void Dispose()
        {
            _context?.Dispose();
        }

      
    }
}
