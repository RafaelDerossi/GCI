using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class VeiculoCommandHandler : CommandHandler, 
        IRequestHandler<CadastrarVeiculoCommand, ValidationResult>,
        IRequestHandler<EditarVeiculoCommand, ValidationResult>,
        IRequestHandler<RemoverVeiculoCommand, ValidationResult>,
        IDisposable
    {
        private IUsuarioRepository _usuarioRepository;

        public VeiculoCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarVeiculoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);
            if (usuario == null)
            {
                AdicionarErro("Usuário não encontrado.");
                return ValidationResult;
            }            

            var veiculo = await _usuarioRepository.ObterVeiculoPorPlaca(request.Placa);

            if (veiculo == null)
                return await CadastrarVeiculo(request, usuario.NomeCompleto);

            

            if (veiculo.EstaCadastrado(request.UsuarioId, request.UnidadeId, request.CondominioId))
            {
                AdicionarErro("Veículo ja esta cadastrado.");
                return ValidationResult;
            }
            

            if (veiculo.EstaCadastradoNoCondominio(request.CondominioId))
                return await EditarUsuarioDoVeiculoNoCondominio(veiculo, request, usuario);

            
            return await CadastrarVeiculoEmCondominio(veiculo, request, usuario.NomeCompleto);

        }

        public async Task<ValidationResult> Handle(EditarVeiculoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var veiculo = await _usuarioRepository.ObterVeiculoPorId(request.Id);
            if (veiculo == null)
            {
                AdicionarErro("Veículo não encontrado.");
                return ValidationResult;
            }

            var veiculoPelaPlaca = await _usuarioRepository.ObterVeiculoPorPlaca(request.Placa);

            if (veiculoPelaPlaca != null && veiculo.Id != veiculoPelaPlaca.Id)
            {
                AdicionarErro("Placa já consta no sistema.");
                return ValidationResult;
            }

            veiculo.SetVeiculo(request.Placa, request.Modelo, request.Cor);

            veiculo.AdicionarEvento(new VeiculoEditadoEvent(veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor));

            _usuarioRepository.AtualizarVeiculo(veiculo);
            
            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(RemoverVeiculoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var veiculo = await _usuarioRepository.ObterVeiculoPorId(request.Id);
            if (veiculo == null)
            {
                AdicionarErro("Veículo não encontrado.");
                return ValidationResult;
            }

            //Exclui todos os VeiculoCondominio do Condominio
            var veiculoCondominiosDoCondominio =
                veiculo.VeiculoCondominios.Where(v => v.CondominioId == request.CondominioId);
            foreach (VeiculoCondominio vC in veiculoCondominiosDoCondominio)
            {
                _usuarioRepository.RemoverVeiculoCondominio(vC);
            }
            veiculo.RemoverTodosOsVeiculoCondominioPorCondominio(request.CondominioId);

            if (veiculo.VeiculoCondominios.Count() == 0)
                veiculo.EnviarParaLixeira();

            _usuarioRepository.AtualizarVeiculo(veiculo);

            veiculo.AdicionarEvento(new VeiculoRemovidoEvent(request.Id, request.CondominioId));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }



        private async Task<ValidationResult> CadastrarVeiculo(VeiculoCommand request, string nomeUsuario)
        {
            var veiculo = VeiculoFactory(request);

            var veiculoCondominio = new VeiculoCondominio(veiculo.Id, request.UnidadeId, request.CondominioId, request.UsuarioId);
            var result = veiculo.AdicionarVeiculoCondominio(veiculoCondominio);
            if (!result.IsValid)
                return result;

            _usuarioRepository.AdicionarVeiculo(veiculo);

            AdicionarEventoVeiculoCadastrado(veiculo, request, nomeUsuario, veiculoCondominio);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        private async Task<ValidationResult> EditarUsuarioDoVeiculoNoCondominio(Veiculo veiculo, VeiculoCommand request, Usuario usuario)
        {            

            //Retirar da lixeira
            veiculo.RestaurarDaLixeira();

            //Exclui todos os VeiculoCondominio do Condominio
            var veiculoCondominiosDoCondominio =
                veiculo.VeiculoCondominios.Where(v => v.CondominioId == request.CondominioId);
            foreach (VeiculoCondominio vC in veiculoCondominiosDoCondominio)
            {
                _usuarioRepository.RemoverVeiculoCondominio(vC);
            }
            veiculo.RemoverTodosOsVeiculoCondominioPorCondominio(request.CondominioId);

            //Adiciona um novo VeiculoCondominio
            var veiculoCondominio =
                new VeiculoCondominio(veiculo.Id, request.UnidadeId, request.CondominioId, request.UsuarioId);
            
            var result = veiculo.AdicionarVeiculoCondominio(veiculoCondominio);
            if (!result.IsValid)
                return result;

            _usuarioRepository.AdicionarVeiculoCondominio(veiculoCondominio);
            _usuarioRepository.AtualizarVeiculo(veiculo);

            AdicionarEventoUsuarioDoVeiculoNoCondominioEditado(veiculo, request, usuario.NomeCompleto, veiculoCondominio);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        private async Task<ValidationResult> CadastrarVeiculoEmCondominio(Veiculo veiculo, VeiculoCommand request, string nomeUsuario)
        {
            //Retirar da lixeira
            veiculo.RestaurarDaLixeira();           

            //Adiciona um novo VeiculoCondominio
            var veiculoCondominio =
                new VeiculoCondominio(veiculo.Id, request.UnidadeId, request.CondominioId, request.UsuarioId);

            var result = veiculo.AdicionarVeiculoCondominio(veiculoCondominio);
            if (!result.IsValid)
                return result;

            _usuarioRepository.AdicionarVeiculoCondominio(veiculoCondominio);
            _usuarioRepository.AtualizarVeiculo(veiculo);

            AdicionarEventoVeiculoCadastrado(veiculo, request, nomeUsuario, veiculoCondominio);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }
        




        private Veiculo VeiculoFactory(VeiculoCommand request)
        {
            return new Veiculo(request.Placa, request.Modelo, request.Cor);
        }

        private void AdicionarEventoVeiculoCadastrado
            (Veiculo veiculo, VeiculoCommand request, string nomeUsuario, VeiculoCondominio veiculoCondominio)
        {
            veiculo.AdicionarEvento(new VeiculoCadastradoEvent
                (veiculoCondominio.Id, veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor,
                 veiculoCondominio.UsuarioId, nomeUsuario, request.UnidadeId,
                 request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, request.CondominioId,
                 request.NomeCondominio));
        }
        
        private void AdicionarEventoUsuarioDoVeiculoNoCondominioEditado
            (Veiculo veiculo, VeiculoCommand request, string nomeUsuario, VeiculoCondominio veiculoCondominio)
        {
            veiculo.AdicionarEvento(new UsuarioDoVeiculoNoCondominioEditadoEvent
                (veiculoCondominio.Id, veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor,
                 veiculoCondominio.UsuarioId, nomeUsuario, request.UnidadeId,
                 request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, request.CondominioId,
                 request.NomeCondominio));
        }



        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}