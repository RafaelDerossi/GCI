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
    public class FuncionarioCommandHandler : CommandHandler,                
        IRequestHandler<CadastrarFuncionarioCommand, ValidationResult>,
        IRequestHandler<EditarFuncionarioCommand, ValidationResult>,
        IDisposable
    {
        private IUsuarioRepository _usuarioRepository;

        public FuncionarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
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

        public async Task<ValidationResult> Handle(EditarFuncionarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var funcionario = await _usuarioRepository.ObterFuncionarioPorId(request.Id);
            if (funcionario == null)
            {
                AdicionarErro("Funcionário não encontrado.");
                return ValidationResult;
            }

            funcionario.SetAtribuicao(request.Atribuicao);
            funcionario.SetFuncao(request.Funcao);
            funcionario.SetPermissao(request.Permissao);

            _usuarioRepository.AtualizarFuncionario(funcionario);

            //Evento
            funcionario.AdicionarEvento(
               new FuncionarioEditadoEvent(
                   funcionario.Id, funcionario.Atribuicao, funcionario.Funcao, funcionario.Permissao));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        private Funcionario FuncionarioFactory(FuncionarioCommand request)
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