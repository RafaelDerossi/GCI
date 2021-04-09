using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Usuario;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<CadastrarUsuarioCommand, ValidationResult>,
        IRequestHandler<EditarUsuarioCommand, ValidationResult>,
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

            if (request.EnviarEmailDeConfirmacao)
                usuario.AdicionarEvento
                    (new EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent(usuario.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);
            if (usuario == null)
            {
                AdicionarErro("Usuário não encontrado.");
                return ValidationResult;
            }

            usuario.SetNome(request.Nome);
            usuario.SetSobrenome(request.Sobrenome);
            usuario.SetRg(request.Rg);
            usuario.SetCpf(request.Cpf);
            usuario.SetCelular(request.Cel);
            usuario.SetTelefone(request.Telefone);
            usuario.SetEmail(request.Email);
            usuario.SetFoto(request.Foto);
            usuario.SetDataNascimento(request.DataNascimento);
            usuario.SetEndereco(request.Endereco);            

            _usuarioRepository.Atualizar(usuario);

            //Evento
            usuario.AdicionarEvento(
                new UsuarioEditadoEvent(
                    usuario.Id, usuario.Nome, usuario.Sobrenome, usuario.Email, usuario.Rg,
                    usuario.Cpf, usuario.Cel, usuario.Foto, usuario.Endereco, usuario.DataNascimento));

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
                 request.DataNascimento, request.Cpf, request.Telefone, request.Endereco,
                 request.SindicoProfissional);

            return usuario;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

    }
}