using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Principal.Infra.DataQuery;
using CondominioApp.Principal.Domain.FlatModel;

namespace CondominioApp.Principal.Infra.Data.Repository
{
    public class CondominioQueryRepository : ICondominioQueryRepository
    {
        private readonly PrincipalQueryContextDB _context;

        public CondominioQueryRepository(PrincipalQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;


        #region Condominio
        
        public void Adicionar(CondominioFlat entity)
        {
            _context.CondominiosFlat.Add(entity);
        }

        public void Apagar(Func<CondominioFlat, bool> predicate)
        {
            _context.CondominiosFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(CondominioFlat entity)
        {
            _context.CondominiosFlat.Update(entity);
        }

       

        public async Task<IEnumerable<CondominioFlat>> Obter(Expression<Func<CondominioFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.CondominiosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.CondominiosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.CondominiosFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.CondominiosFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<CondominioFlat> ObterPorId(Guid Id)
        {
            return await _context.CondominiosFlat
                 .AsNoTracking()
                 .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<IEnumerable<CondominioFlat>> ObterTodos()
        {
            return await _context.CondominiosFlat.AsNoTracking().Where(u => !u.Lixeira).ToListAsync();
        }

        #endregion


        #region Grupo
        public void AdicionarGrupo(GrupoFlat entity)
        {
            _context.GruposFlat.Add(entity);
        }

        public void AtualizarGrupo(GrupoFlat entity)
        {
            _context.GruposFlat.Update(entity);
        }

        public async Task<GrupoFlat> ObterGrupoPorId(Guid Id)
        {
            return await _context.GruposFlat
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId)
        {
            return await _context.GruposFlat.AsNoTracking().Where(u => u.CondominioId == condominioId).ToListAsync();
        }

        #endregion


        #region Unidade
        public void AdicionarUnidade(UnidadeFlat entity)
        {
            _context.UnidadesFlat.Add(entity);
        }

        public void AtualizarUnidade(UnidadeFlat entity)
        {
            _context.UnidadesFlat.Update(entity);
        }

        public async Task<UnidadeFlat> ObterUnidadePorId(Guid Id)
        {
            return await _context.UnidadesFlat
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorGrupo(Guid grupoId)
        {
            return await _context.UnidadesFlat
                .AsNoTracking()
                .Where(u => u.GrupoId == grupoId).ToListAsync();
        }

        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorCondominio(Guid condominioId)
        {
            return await _context.UnidadesFlat
                .AsNoTracking()
                .Where(u => u.CondominioId == condominioId).ToListAsync();
        }

        #endregion




        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
