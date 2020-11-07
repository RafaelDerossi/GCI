using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<CadastrarMoradorCommand,ValidationResult>, IDisposable
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var Morador = new Usuario(request.Nome,request.Sobrenome,request.Rg,request.Cel,request.Email,request.Foto,request.TpUsuario,
                request.Permissao,request.DataNascimento,request.Cpf);

            _usuarioRepository.Adicionar(Morador);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}