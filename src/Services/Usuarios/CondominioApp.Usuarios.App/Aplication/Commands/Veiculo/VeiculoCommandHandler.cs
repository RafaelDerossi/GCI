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



        

        private async Task<ValidationResult> CadastrarVeiculo(VeiculoCommand request, string nomeUsuario)
        {
            var veiculo = VeiculoFactory(request);

            var veiculoCondominio = new VeiculoCondominio(veiculo.Id, request.UnidadeId, request.CondominioId, request.UsuarioId);
            var result = veiculo.AdicionarVeiculoCondominio(veiculoCondominio);
            if (!result.IsValid)
                return result;

            _usuarioRepository.AdicionarVeiculo(veiculo);

            AdicionarEventoVeiculoCadastrado(veiculo, nomeUsuario, request.UnidadeId, request.CondominioId, veiculoCondominio);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        private async Task<ValidationResult> EditarUsuarioDoVeiculoNoCondominio(Veiculo veiculo, VeiculoCommand request, Usuario usuario)
        {
            //Retirar da lixeira
            veiculo.RestaurarDaLixeira();

            //Exclui todos os VeiculoCondominio do Condominio
            var veiculoCondominiosDoCondominio =
                veiculo.VeiculoCondominios.Where(uvu => uvu.CondominioId == request.CondominioId);
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

            AdicionarEventoUsuarioDoVeiculoNoCondominioEditado(
                veiculo, usuario.NomeCompleto, request.UnidadeId, request.CondominioId, veiculoCondominio);

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

            AdicionarEventoVeiculoCadastrado(veiculo, nomeUsuario, request.UnidadeId, request.CondominioId, veiculoCondominio);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        




        private Veiculo VeiculoFactory(VeiculoCommand request)
        {
            return new Veiculo(request.Placa, request.Modelo, request.Cor);
        }

        private void AdicionarEventoVeiculoCadastrado
            (Veiculo veiculo, string nomeUsuario, Guid unidadeId, Guid condominioId, VeiculoCondominio veiculoCondominio)
        {
            veiculo.AdicionarEvento(new VeiculoCadastradoEvent
                (veiculoCondominio.Id, veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor,
                veiculoCondominio.UsuarioId, nomeUsuario, unidadeId, condominioId));
        }
        
        private void AdicionarEventoUsuarioDoVeiculoNoCondominioEditado
            (Veiculo veiculo, string nomeUsuario, Guid unidadeId, Guid condominioId, VeiculoCondominio veiculoCondominio)
        {
            veiculo.AdicionarEvento(new VeiculoEditadoComTrocaDeUsuarioEvent
                (veiculoCondominio.Id, veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor,
                veiculoCondominio.UsuarioId, nomeUsuario, unidadeId, condominioId));
        }

        

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}