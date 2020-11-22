using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<CadastrarMoradorCommand, ValidationResult>,
        IRequestHandler<EditarMoradorCommand, ValidationResult>,
        IDisposable
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var Morador = MoradorFactory(request);

            if (!ValidationResult.IsValid) return ValidationResult;

            Morador.SetEntidadeId(request.UsuarioId);

            _usuarioRepository.Adicionar(Morador);

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
            Morador.SetPermissao(request.Permissao);
            Morador.SetDataNascimento(request.DataNascimento);

            _usuarioRepository.Adicionar(Morador);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }


        private Usuario MoradorFactory(CadastrarMoradorCommand request)
        {
            var morador = new Usuario(request.Nome, request.Sobrenome, request.Rg,
                 request.Cel, request.Email, request.Foto,request.TpUsuario, request.Permissao, request.DataNascimento, request.Cpf);

            return morador;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}