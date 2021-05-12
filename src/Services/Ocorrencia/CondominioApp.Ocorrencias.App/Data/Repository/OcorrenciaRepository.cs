using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Ocorrencias.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Ocorrencias.App.Data.Repository
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly OcorrenciaContextDB _context;

        public OcorrenciaRepository(OcorrenciaContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;


        #region Ocorrencia
        public async Task<Ocorrencia> ObterPorId(Guid Id)
        {
            return await _context.Ocorrencias
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<Ocorrencia>> ObterTodos()
        {
            return await _context.Ocorrencias
                .Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Ocorrencia>> Obter(Expression<Func<Ocorrencia, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Ocorrencias
                        .AsNoTracking()
                        .Where(expression)
                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Ocorrencias
                    .AsNoTracking()
                    .Where(expression)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync();
            }

            if (take > 0)
                return await _context.Ocorrencias
                    .AsNoTracking()
                    .Where(expression)
                    .OrderBy(x => x.DataDeCadastro)
                    .Take(take)
                    .ToListAsync();

            return await _context.Ocorrencias
                .AsNoTracking()
                .Where(expression)
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync();
        }



        public void Adicionar(Ocorrencia entity)
        {
            _context.Ocorrencias.Add(entity);
        }

        public void Atualizar(Ocorrencia entity)
        {
            _context.Ocorrencias.Update(entity);
        }

        public void Apagar(Func<Ocorrencia, bool> predicate)
        {
            _context.Ocorrencias.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        #endregion


        #region Resposta

        public async Task<RespostaOcorrencia> ObterRespostaPorId(Guid Id)
        {
            return await _context.RespostasOcorrencias
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<RespostaOcorrencia>> ObterRespostasPorOcorrencia(Guid ocorrenciaId)
        {
            return await _context.RespostasOcorrencias
                        .AsNoTracking()
                        .Where(r=>r.OcorrenciaId == ocorrenciaId &&
                                  !r.Lixeira)
                        .OrderByDescending(x => x.DataDeCadastro)
                        .ToListAsync();            
        }

        public void AdicionarResposta(RespostaOcorrencia entity)
        {
            _context.RespostasOcorrencias.Add(entity);
        }

        public void AtualizarResposta(RespostaOcorrencia entity)
        {
            _context.RespostasOcorrencias.Update(entity);
        }

        public void ApagarResposta(Func<RespostaOcorrencia, bool> predicate)
        {
            _context.RespostasOcorrencias.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        #endregion




        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
