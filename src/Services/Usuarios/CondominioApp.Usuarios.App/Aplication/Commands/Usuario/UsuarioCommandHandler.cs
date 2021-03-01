using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<CadastrarUsuarioCommand, ValidationResult>,
        IRequestHandler<EditarMoradorCommand, ValidationResult>,
        IRequestHandler<CadastrarResponsavelDaLojaCommand, ValidationResult>,
        IDisposable
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);

            if (usuario == null)
               return await AdicionarUsuario(request);

            if (usuario.TpUsuario == TipoDeUsuario.MORADOR)
                return await AdicionarMorador(request);

            if (usuario.TpUsuario == TipoDeUsuario.FUNCIONARIO)
                return await AdicionarFuncionario(request);


            AdicionarErro("Usuário já cadastrado.");
            return ValidationResult;
        }
        

        public async Task<ValidationResult> Handle(EditarMoradorCommand request, CancellationToken cancellationToken)

        {
            if (!request.EstaValido()) return request.ValidationResult;

            var Morador = _usuarioRepository.ObterPorId(request.UsuarioId).Result;

            Morador.SetNome(request.Nome);
            Morador.SetSobrenome(request.Sobrenome);
            Morador.SetRg(request.Rg);
            Morador.SetCpf(request.Cpf);
            Morador.SetCelular(request.Cel);
            Morador.SetEmail(request.Email);
            Morador.SetFoto(request.Foto);
            Morador.SetTipoDeUsuario(request.TpUsuario);            
            Morador.SetDataNascimento(request.DataNascimento);

            _usuarioRepository.Atualizar(Morador);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CadastrarResponsavelDaLojaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var Lojista = UsuarioFactory(request);

            Lojista.SetEntidadeId(request.UsuarioId);

            _usuarioRepository.Adicionar(Lojista);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }


        
        
       

        private async Task<ValidationResult> AdicionarUsuario(UsuarioCommand request)
        {
            var usuario = UsuarioFactory(request);

            usuario.SetEntidadeId(request.UsuarioId);

            _usuarioRepository.Adicionar(usuario);

            var retornoPersisteUsuario = await PersistirDados(_usuarioRepository.UnitOfWork);

            if (!retornoPersisteUsuario.IsValid)
                return retornoPersisteUsuario;



            if (usuario.TpUsuario == TipoDeUsuario.MORADOR)
                return await PersistirMorador(request);


            if (usuario.TpUsuario == TipoDeUsuario.FUNCIONARIO)
                return await PersistirFuncionario(request);


            return retornoPersisteUsuario;
        }
        private Usuario UsuarioFactory(UsuarioCommand request)
        {
            var usuario = new Usuario(request.Nome, request.Sobrenome, request.Rg,
                 request.Cel, request.Email, request.Foto, request.TpUsuario, request.DataNascimento, request.Cpf);

            return usuario;
        }


        private async Task<ValidationResult> AdicionarMorador(UsuarioCommand request)
        {
            var morador = _usuarioRepository.ObterMoradorPorUsuarioIdEUnidadeId(request.UsuarioId, request.UnidadeId);
            if (morador == null)
            {
                return await PersistirMorador(request);
            }
            
            AdicionarErro("Morador já cadastrado.");
            return ValidationResult;            
        }       
        private async Task<ValidationResult> PersistirMorador(UsuarioCommand request)
        {
            var moradorNovo = MoradorFactory(request);
            _usuarioRepository.AdicionarMorador(moradorNovo);
            var retorno = await PersistirDados(_usuarioRepository.UnitOfWork);
            return retorno;
        }
        private Morador MoradorFactory(UsuarioCommand request)
        {
            var morador = new Morador
                (request.UsuarioId, request.UnidadeId, request.CondominioId, request.Proprietario, request.Principal);

            return morador;
        }


        private async Task<ValidationResult> AdicionarFuncionario(UsuarioCommand request)
        {
            var funcionario = _usuarioRepository.ObterFuncionarioPorUsuarioIdECondominioId(request.UsuarioId, request.CondominioId);
            if (funcionario == null)
            {
                return await PersistirFuncionario(request);
            }
            AdicionarErro("Funcionário já cadastrado.");
            return ValidationResult;            
        }        
        private async Task<ValidationResult> PersistirFuncionario(UsuarioCommand request)
        {
            var funcionarioNovo = FuncionarioFactory(request);
            _usuarioRepository.AdicionarFuncionario(funcionarioNovo);
            var retorno = await PersistirDados(_usuarioRepository.UnitOfWork);
            return retorno;
        }
        private Funcionario FuncionarioFactory(UsuarioCommand request)
        {
            var funcionario = new Funcionario
                (request.UsuarioId, request.CondominioId, request.Atribuicao, request.Funcao, request.Permissao);

            return funcionario;
        }


        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

    }
}