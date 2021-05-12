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
    public class PrincipalQueryRepository : IPrincipalQueryRepository
    {
        private readonly PrincipalQueryContextDB _queryContext;      

        public PrincipalQueryRepository(PrincipalQueryContextDB queryContext)
        {
            _queryContext = queryContext;            
        }

        public IUnitOfWorks UnitOfWork => _queryContext;


        #region Condominio
        
        public void Adicionar(CondominioFlat entity)
        {
            _queryContext.CondominiosFlat.Add(entity);
        }

        public void Apagar(Func<CondominioFlat, bool> predicate)
        {
            _queryContext.CondominiosFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(CondominioFlat entity)
        {
            _queryContext.CondominiosFlat.Update(entity);
        }

       

        public async Task<IEnumerable<CondominioFlat>> Obter(Expression<Func<CondominioFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _queryContext.CondominiosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _queryContext.CondominiosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _queryContext.CondominiosFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _queryContext.CondominiosFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<CondominioFlat> ObterPorId(Guid Id)
        {
            return await _queryContext.CondominiosFlat
                 .AsNoTracking()
                 .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<CondominioFlat>> ObterTodos()
        {
            return await _queryContext.CondominiosFlat.AsNoTracking().Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<CondominioFlat> ObterPorContratoId(Guid contratoId)
        {
            return await _queryContext.CondominiosFlat
                 .AsNoTracking()
                 .FirstOrDefaultAsync(u => u.ContratoId == contratoId && !u.Lixeira);
        }

        #endregion


        #region Grupo
        public void AdicionarGrupo(GrupoFlat entity)
        {
            _queryContext.GruposFlat.Add(entity);
        }

        public void AtualizarGrupo(GrupoFlat entity)
        {
            _queryContext.GruposFlat.Update(entity);
        }

        public void ApagarGrupo(Func<GrupoFlat, bool> predicate)
        {
            _queryContext.GruposFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }


        public async Task<GrupoFlat> ObterGrupoPorId(Guid Id)
        {
            return await _queryContext.GruposFlat
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId)
        {
            return await _queryContext.GruposFlat.AsNoTracking().Where(u => u.CondominioId == condominioId && !u.Lixeira).ToListAsync();
        }

        #endregion


        #region Unidade
        public void AdicionarUnidade(UnidadeFlat entity)
        {
            _queryContext.UnidadesFlat.Add(entity);
        }

        public void AtualizarUnidade(UnidadeFlat entity)
        {
            _queryContext.UnidadesFlat.Update(entity);
        }

        public void ApagarUnidade(Func<UnidadeFlat, bool> predicate)
        {
            _queryContext.UnidadesFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }



        public async Task<UnidadeFlat> ObterUnidadePorId(Guid Id)
        {
            return await _queryContext.UnidadesFlat
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<UnidadeFlat> ObterUnidadePorCodigo(string codigo)
        {
            return await _queryContext.UnidadesFlat
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Codigo == codigo && !u.Lixeira);
        }

        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorGrupo(Guid grupoId)
        {
            return await _queryContext.UnidadesFlat
                .AsNoTracking()
                .Where(u => u.GrupoId == grupoId && !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorCondominio(Guid condominioId)
        {
            return await _queryContext.UnidadesFlat
                .AsNoTracking()
                .Where(u => u.CondominioId == condominioId && !u.Lixeira).ToListAsync();
        }

        #endregion


    
        public void Dispose()
        {
            _queryContext?.Dispose();
        }       
    }
}
