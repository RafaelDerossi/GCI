using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<CadastrarUsuarioCommand, ValidationResult>,
        IRequestHandler<CadastrarMoradorCommand, ValidationResult>,
        IRequestHandler<CadastrarFuncionarioCommand, ValidationResult>,
        IRequestHandler<EditarMoradorCommand, ValidationResult>,
        IRequestHandler<CadastrarResponsavelDaLojaCommand, ValidationResult>,
        IRequestHandler<ExcluirUsuarioCommand, ValidationResult>,
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
            if (usuario != null)
            {
                AdicionarErro("Usuário já cadastrado.");
                return ValidationResult;
            }

            usuario = UsuarioFactory(request);

            usuario.SetEntidadeId(request.UsuarioId);

            _usuarioRepository.Adicionar(usuario);

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(CadastrarMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;


            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);            
            if (usuario == null)
            {
                AdicionarErro("Usuário não encontrado.");
                return ValidationResult;
            }

            var morador = await _usuarioRepository.ObterMoradorPorUsuarioIdEUnidadeId(request.UsuarioId, request.UnidadeId);
            if (morador != null)
            {
                AdicionarErro("Morador já cadastrado.");
                return ValidationResult;
            }

            var moradorNovo = MoradorFactory(request);

            _usuarioRepository.AdicionarMorador(moradorNovo);

            //Evento
            moradorNovo.AdicionarEvento(
                new MoradorCadastradoEvent(
                    moradorNovo.Id, moradorNovo.UsuarioId, moradorNovo.CondominioId, request.NomeCondominio,
                    moradorNovo.UnidadeId, request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade,
                    moradorNovo.Proprietario, moradorNovo.Principal));

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CadastrarFuncionarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);
            if (usuario == null)
            {
                AdicionarErro("Usuário não encontrado.");
                return ValidationResult;
            }

            var funcionario = await _usuarioRepository.ObterFuncionarioPorUsuarioIdECondominioId(request.UsuarioId, request.CondominioId);
            if (funcionario != null)
            {
                AdicionarErro("Funcionário já cadastrado.");
                return ValidationResult;
            }

            var funcionarioNovo = FuncionarioFactory(request);

            _usuarioRepository.AdicionarFuncionario(funcionarioNovo);

            //Evento
            funcionarioNovo.AdicionarEvento(
               new FuncionarioCadastradoEvent(
                   funcionarioNovo.Id, funcionarioNovo.UsuarioId, funcionarioNovo.CondominioId, request.NomeCondominio,
                   funcionarioNovo.Atribuicao, funcionarioNovo.Funcao, funcionarioNovo.Permissao));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

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

        public async Task<ValidationResult> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);
            if (usuario == null)
            {
                AdicionarErro("Usuário não encontrado.");
                return ValidationResult;
            }

            _usuarioRepository.Excluir(usuario);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }





        private Usuario UsuarioFactory(UsuarioCommand request)
        {
            var usuario = new Usuario
                (request.Nome, request.Sobrenome, request.Rg, request.Cel, request.Email, request.Foto, 
                request.TpUsuario, request.DataNascimento, request.Cpf, request.Telefone, request.Endereco,
                request.SindicoProfissional);

            return usuario;
        }
      
        private Morador MoradorFactory(UsuarioCommand request)
        {
            var morador = new Morador
                (request.UsuarioId, request.UnidadeId, request.CondominioId, request.Proprietario, request.Principal);

            return morador;
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