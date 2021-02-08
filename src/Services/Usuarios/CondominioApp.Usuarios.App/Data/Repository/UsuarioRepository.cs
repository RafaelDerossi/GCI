using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;
using CondominioApp.Usuarios.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioApp.Usuarios.App.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContextDB _context;

        public UsuarioRepository(UsuarioContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Usuario> ObterPorId(Guid Id)
        {
            return await _context.Usuarios.Where(u => u.Id == Id && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _context.Usuarios.Where(u => !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> Obter(Expression<Func<Usuario, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Usuarios.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Usuarios.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.Usuarios.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.Usuarios.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }


        public void Adicionar(Usuario entity)
        {
            _context.Usuarios.Add(entity);
        }

        public void Atualizar(Usuario entity)
        {
            _context.Usuarios.Update(entity);
        }

        public void Apagar(Func<Usuario, bool> predicate)
        {
            _context.Usuarios.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public bool AtualizacaoNegada(Usuario Usuario)
        {
            return _context.Usuarios.Any(a => a.Email.Endereco.Trim() == Usuario.Email.Endereco.Trim() &&
                                                     !a.Lixeira &&
                                                     a.Id != Usuario.Id);
        }

        public bool ExistentePeloEmail(Usuario Usuario)
        {
            return _context.Usuarios.Any(u => u.Email.Endereco == Usuario.Email.Endereco &&
                                              !u.Lixeira);
        }





        public async Task<Veiculo> ObterVeiculoPorId(Guid Id)
        {
            return await _context.Veiculos
                    .Include(u=>u.VeiculoCondominios)
                    .Where(u => u.Id == Id && !u.Lixeira)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculo(Expression<Func<Veiculo, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Veiculos.AsNoTracking().Where(expression).Include(x=>x.VeiculoCondominios)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Veiculos.AsNoTracking().Where(expression).Include(x => x.VeiculoCondominios)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.Veiculos.AsNoTracking().Where(expression).Include(x => x.VeiculoCondominios)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.Veiculos.AsNoTracking().Where(expression).Include(x => x.VeiculoCondominios)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<Veiculo> ObterVeiculoPorPlaca(string placa)
        {
            return await _context.Veiculos.Include(x => x.VeiculoCondominios).FirstOrDefaultAsync(v => v.Placa == placa);
        }

       

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
        }

        public void AtualizarVeiculo(Veiculo entity)
        {
            _context.Veiculos.Update(entity);
        }

        public void AdicionarVeiculoCondominio(VeiculoCondominio veiculo)
        {
            _context.VeiculosCondominios.Add(veiculo);
        }

        public void RemoverVeiculoCondominio(VeiculoCondominio unidade)
        {
            _context.VeiculosCondominios.Remove(unidade);
        }



        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
