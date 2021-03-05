using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class MobileCommandHandler : CommandHandler,
        IRequestHandler<CadastrarMobileCommand, ValidationResult>,
        IRequestHandler<EditarMobileCommand, ValidationResult>,
        IDisposable 
    {
        private IUsuarioRepository _usuarioRepository;

        public MobileCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarMobileCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var mobile = MobileFactory(request);            

            _usuarioRepository.AdicionarMobile(mobile);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }
        

        public async Task<ValidationResult> Handle(EditarMobileCommand request, CancellationToken cancellationToken)

        {
            if (!request.EstaValido()) return request.ValidationResult;

            var mobile = _usuarioRepository.ObterMobilePorId(request.Id).Result;

            mobile.SetDeviceKey(request.DeviceKey);
            mobile.SetMobileId(request.MobileId);
            mobile.SetModelo(request.Modelo);
            mobile.SetPlataforma(request.Plataforma);
            mobile.SetVersao(request.Versao);
            mobile.SetUsuarioId(request.UsuarioId);            

            _usuarioRepository.AtualizarMobile(mobile);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

     

        private Mobile MobileFactory(MobileCommand request)
        {
            var mobile = new Mobile(request.DeviceKey, request.MobileId, request.Modelo,
                 request.Plataforma, request.Versao, request.UsuarioId);

            return mobile;
        }
        
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}