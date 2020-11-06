using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == Id);
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

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
