using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Usuarios.App.Data.Repository
{
    public class VeiculoQueryRepository : IVeiculoQueryRepository
    {
        private readonly UsuarioQueryContextDB _context;

        public VeiculoQueryRepository(UsuarioQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public async Task<VeiculoFlat> ObterPorId(Guid Id)
        {
            return await _context.VeiculosFlat.Where(u => u.Id == Id && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<VeiculoFlat>> ObterPorVeiculoId(Guid veiculoId)
        {
            return await _context.VeiculosFlat.Where(u => u.VeiculoId == veiculoId && !u.Lixeira).ToListAsync();
        }

        public async Task<VeiculoFlat> ObterPorVeiculoCondominioId(Guid veiculoCondominioId)
        {
            return await _context.VeiculosFlat.Where(u => u.Id == veiculoCondominioId && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<VeiculoFlat>> ObterTodos()
        {
            return await _context.VeiculosFlat.Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<VeiculoFlat>> Obter(Expression<Func<VeiculoFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.VeiculosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.VeiculosFlat.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.VeiculosFlat.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.VeiculosFlat.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public void Adicionar(VeiculoFlat entity)
        {
            _context.VeiculosFlat.Add(entity);
        }

        public void Atualizar(VeiculoFlat entity)
        {
            _context.VeiculosFlat.Update(entity);
        }

        public void Apagar(Func<VeiculoFlat, bool> predicate)
        {
            _context.VeiculosFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

   
        public async Task<VeiculoFlat> ObterVeiculoPorPlaca(string placa)
        {
            return await _context.VeiculosFlat.FirstOrDefaultAsync(v => v.Placa == placa);
        }

        public void Remover(VeiculoFlat veiculo)
        {
            _context.VeiculosFlat.Remove(veiculo);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
