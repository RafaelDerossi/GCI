using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class MobileCommandHandler : CommandHandler,
        IRequestHandler<RegistrarMoradorMobileCommand, ValidationResult>,
        IRequestHandler<RegistrarFuncionarioMobileCommand, ValidationResult>,
        IDisposable 
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public MobileCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarMoradorMobileCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var morador = await _usuarioRepository.ObterMoradorPorId(request.MoradorFuncionarioId);
            if (morador==null)
            {
                AdicionarErro("Morador não encontrado!");
                return ValidationResult;
            }

            var mobiles = _usuarioRepository.ObterMobilePorMoradorIdFuncionarioId(request.MoradorFuncionarioId).Result;
            if (mobiles == null || !mobiles.Any(m => m.MobileId == request.MobileId))
            {
                var cadastrarDTO = new CadastrarMobileDTO
                (request.DeviceKey, request.MobileId, request.Modelo, request.Plataforma, request.Versao,
                request.MoradorFuncionarioId);

                return await CadastrarMobile(cadastrarDTO);
            }

            var mobileBD = mobiles.Where(m => m.MobileId == request.MobileId).FirstOrDefault();

            var editarDTO = new EditarMobileDTO
                (request.DeviceKey, request.MobileId, request.Modelo, request.Plataforma,
                 request.Versao, request.MoradorFuncionarioId, mobileBD);

            return await EditarMobile(editarDTO);

        }
       
        public async Task<ValidationResult> Handle(RegistrarFuncionarioMobileCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var funcionario = await _usuarioRepository.ObterFuncionarioPorId(request.MoradorFuncionarioId);
            if (funcionario == null)
            {
                AdicionarErro("Funcionário não encontrado!");
                return ValidationResult;
            }

            var mobiles = await _usuarioRepository.ObterMobile(m => m.MoradorIdFuncionadioId == request.MoradorFuncionarioId);
            if (!mobiles.Any(m => m.MobileId == request.MobileId))
            {
                var cadastrarDTO = new CadastrarMobileDTO
                (request.DeviceKey, request.MobileId, request.Modelo, request.Plataforma, request.Versao,
                request.MoradorFuncionarioId);

                return await CadastrarMobile(cadastrarDTO);
            }

            var mobileBD = mobiles.Where(m => m.MobileId == request.MobileId).FirstOrDefault();

            var editarDTO = new EditarMobileDTO
                (request.DeviceKey, request.MobileId, request.Modelo, request.Plataforma,
                 request.Versao, request.MoradorFuncionarioId, mobileBD);

            return await EditarMobile(editarDTO);

        }



        private async Task<ValidationResult> CadastrarMobile(CadastrarMobileDTO dto)
        {
            var mobile = new Mobile(dto.DeviceKey, dto.MobileId, dto.Modelo,
                dto.Plataforma, dto.Versao, dto.MoradorFuncionarioId);

            _usuarioRepository.AdicionarMobile(mobile);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }        

        private async Task<ValidationResult> EditarMobile(EditarMobileDTO dto)
        {
            dto.Mobile.SetDeviceKey(dto.DeviceKey);
            dto.Mobile.SetMobileId(dto.MobileId);
            dto.Mobile.SetModelo(dto.Modelo);
            dto.Mobile.SetPlataforma(dto.Plataforma);
            dto.Mobile.SetVersao(dto.Versao);
            dto.Mobile.SetMoradorIdFuncionarioId(dto.MoradorFuncionarioId);            

            _usuarioRepository.AtualizarMobile(dto.Mobile);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}