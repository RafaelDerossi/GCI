﻿using System;
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



        #region Usuario      

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

        public void Remover(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
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

        #endregion


        #region Morador
        public async Task<Morador> ObterMoradorPorId(Guid id)
        {
            return await _context.Moradores.Where(u => u.Id == id && !u.Lixeira).FirstOrDefaultAsync();            
        }

        public async Task<Morador> ObterMoradorPorUsuarioIdEUnidadeId(Guid usuarioId, Guid unidadeId)
        {
            return await _context.Moradores.Where(u=>u.UsuarioId == usuarioId && u.UnidadeId == unidadeId && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Morador>> ObterMoradoresPorUsuarioId(Guid usuarioId)
        {
            return await _context.Moradores.Where(u => u.UsuarioId == usuarioId && !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Morador>> ObterMoradores(Expression<Func<Morador, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Moradores.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Moradores.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.Moradores.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.Moradores.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<int> ContaMoradorePorUsuarioIdEUnidadeId(Guid usuarioid, Guid unidadeId)
        {
            return await _context.Moradores.Where(u => u.UsuarioId == usuarioid && u.UnidadeId == unidadeId && !u.Lixeira).CountAsync();
        }

        public void AdicionarMorador(Morador morador)
        {
            _context.Moradores.Add(morador);
        }

        public void AtualizarMorador(Morador entity)
        {
            _context.Moradores.Update(entity);
        }

        public void ApagarMorador(Func<Morador, bool> predicate)
        {
            _context.Moradores.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void RemoverMorador(Morador entity)
        {
            _context.Moradores.Remove(entity);
        }

        #endregion


        #region Funcionario
        public async Task<Funcionario> ObterFuncionarioPorId(Guid id)
        {
            return await _context.Funcionarios.Where(u => u.Id == id && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<Funcionario> ObterFuncionarioPorUsuarioIdECondominioId(Guid usuarioId, Guid condominioId)
        {
            return await _context.Funcionarios.Where(u => u.UsuarioId == usuarioId && u.CondominioId == condominioId && !u.Lixeira).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Funcionario>> ObterFuncionariosPorUsuarioId(Guid usuarioId)
        {
            return await _context.Funcionarios.Where(u => u.UsuarioId == usuarioId && !u.Lixeira).ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> ObterFuncionario(Expression<Func<Funcionario, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Funcionarios.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Funcionarios.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.Funcionarios.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.Funcionarios.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public void AtualizarFuncionario(Funcionario entity)
        {
            _context.Funcionarios.Update(entity);
        }

        public void ApagarFuncionario(Func<Funcionario, bool> predicate)
        {
            _context.Funcionarios.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
        }

        #endregion


        #region Veiculo
        public async Task<Veiculo> ObterVeiculoPorId(Guid Id)
        {
            return await _context.Veiculos
                    .Include(u => u.VeiculoCondominios)
                    .Where(u => u.Id == Id && !u.Lixeira)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculo(Expression<Func<Veiculo, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Veiculos.AsNoTracking().Where(expression).Include(x => x.VeiculoCondominios)
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

        public async Task<VeiculoCondominio> ObterVeiculoCondominioPorId(Guid veiculoCondominioId)
        {
            return await _context.VeiculosCondominios.FirstOrDefaultAsync(v => v.Id == veiculoCondominioId);
        }


        public void AdicionarVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
        }

        public void AtualizarVeiculo(Veiculo entity)
        {
            _context.Veiculos.Update(entity);
        }

        public void AtualizarVeiculoCondominio(VeiculoCondominio entity)
        {
            _context.VeiculosCondominios.Update(entity);
        }

        public void AdicionarVeiculoCondominio(VeiculoCondominio veiculo)
        {
            _context.VeiculosCondominios.Add(veiculo);
        }

        public void ApagarVeiculo(Func<Veiculo, bool> predicate)
        {
            _context.Veiculos.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void RemoverVeiculoCondominio(VeiculoCondominio unidade)
        {
            _context.VeiculosCondominios.Remove(unidade);
        }
        #endregion


        #region Mobile
        public async Task<Mobile> ObterMobilePorId(Guid id)
        {
            return await _context.Mobiles.FindAsync(id);
        }

        public async Task<IEnumerable<Mobile>> ObterMobile(Expression<Func<Mobile, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Mobiles
                                         .AsNoTracking()
                                         .Where(expression)
                                         .OrderByDescending(x => x.DataDeCadastro)
                                         .Take(take)
                                         .ToListAsync();

                return await _context.Mobiles
                                     .AsNoTracking()
                                     .Where(expression)
                                     .OrderByDescending(x => x.DataDeCadastro)
                                     .ToListAsync();
            }

            if (take > 0)
                return await _context.Mobiles
                                     .AsNoTracking()
                                     .Where(expression)
                                     .OrderBy(x => x.DataDeCadastro)
                                     .Take(take)
                                     .ToListAsync();

            return await _context.Mobiles
                                 .AsNoTracking()
                                 .Where(expression)
                                 .OrderBy(x => x.DataDeCadastro)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Mobile>> ObterTodosOsMobiles()
        {
            return await _context.Mobiles
                                 .AsNoTracking()
                                 .OrderByDescending(x => x.DataDeCadastro)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Mobile>> ObterMobilePorMoradorIdFuncionarioId(Guid id)
        {
            return await _context.Mobiles
                                 .AsNoTracking()
                                 .Where(m => m.MoradorIdFuncionadioId == id)
                                 .OrderByDescending(x => x.DataDeCadastro)
                                 .ToListAsync();
        }

        
        public void AdicionarMobile(Mobile mobile)
        {
            _context.Mobiles.Add(mobile);
        }

        public void AtualizarMobile(Mobile mobile)
        {
            _context.Mobiles.Update(mobile);
        }
        #endregion

        


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
