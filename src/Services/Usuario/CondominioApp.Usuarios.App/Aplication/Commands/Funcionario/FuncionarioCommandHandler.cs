using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Usuario;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class FuncionarioCommandHandler : CommandHandler,                
        IRequestHandler<AdicionarFuncionarioCommand, ValidationResult>,
        IRequestHandler<AtualizarFuncionarioCommand, ValidationResult>,
        IRequestHandler<AtivarFuncionarioCommand, ValidationResult>,
        IRequestHandler<DesativarFuncionarioCommand, ValidationResult>,
        IDisposable
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public FuncionarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

       
        public async Task<ValidationResult> Handle(AdicionarFuncionarioCommand request, CancellationToken cancellationToken)
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
               new FuncionarioAdicionadoEvent(
                   funcionarioNovo.Id, funcionarioNovo.UsuarioId, funcionarioNovo.CondominioId, request.NomeCondominio,
                   funcionarioNovo.Atribuicao, funcionarioNovo.Funcao, funcionarioNovo.Permissao));
            
            funcionarioNovo.AdicionarEvento
                   (new EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent(usuario.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(AtualizarFuncionarioCommand request, CancellationToken cancellationToken)
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
               new FuncionarioAtualizadoEvent(
                   funcionario.Id, funcionario.Atribuicao, funcionario.Funcao, funcionario.Permissao));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(AtivarFuncionarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var funcionario = await _usuarioRepository.ObterFuncionarioPorId(request.Id);
            if (funcionario == null)
            {
                AdicionarErro("Funcionário não encontrado.");
                return ValidationResult;
            }

            funcionario.Ativar();
            
            _usuarioRepository.AtualizarFuncionario(funcionario);

            //Evento
            funcionario.AdicionarEvento(
               new FuncionarioAtivadoEvent(funcionario.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(DesativarFuncionarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var funcionario = await _usuarioRepository.ObterFuncionarioPorId(request.Id);
            if (funcionario == null)
            {
                AdicionarErro("Funcionário não encontrado.");
                return ValidationResult;
            }

            funcionario.Desativar();

            _usuarioRepository.AtualizarFuncionario(funcionario);

            //Evento
            funcionario.AdicionarEvento(
               new FuncionarioDesativadoEvent(funcionario.Id));

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