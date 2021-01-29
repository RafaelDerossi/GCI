using System;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
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

            
            if (veiculo.EstaCadastradoNaUnidade(request.UsuarioId, request.UnidadeId))
            {
                AdicionarErro("Veículo ja esta cadastrado nesta unidade.");
                return ValidationResult;
            }
            
            if (veiculo.EstaCadastradoNoCondominio(request.UsuarioId, request.CondominioId))
            {
                AdicionarErro("Veículo ja esta cadastrado neste condomínio.");
                return ValidationResult;
            }    
            
            if (veiculo.PertenceAoMesmoUsuario(request.UsuarioId))
                return await AdicionarUnidadeVeiculo(veiculo, request, usuario.NomeCompleto);

            return await EditarVeiculoComTrocaDeUsuario(veiculo, request, usuario);
        }



        

        private async Task<ValidationResult> CadastrarVeiculo(VeiculoCommand request, string nomeUsuario)
        {
            var veiculo = VeiculoFactory(request);

            var unidadeVeiculo = new UnidadeVeiculo(veiculo.Id, request.UnidadeId, request.CondominioId);
            var result = veiculo.AdicionarUnidade(unidadeVeiculo);
            if (!result.IsValid)
                return result;

            _usuarioRepository.AdicionarVeiculo(veiculo);

            AdicionarEventoUnidadeVeiculoCadastrada(
                veiculo, nomeUsuario, request.UnidadeId, request.CondominioId, unidadeVeiculo);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        private async Task<ValidationResult> AdicionarUnidadeVeiculo(Veiculo veiculo, VeiculoCommand request, string nomeUsuario)
        {
            var unidadeVeiculo = new UnidadeVeiculo(veiculo.Id, request.UnidadeId, request.CondominioId);
            var result = veiculo.AdicionarUnidade(unidadeVeiculo);
            if (!result.IsValid)
                return result;

            _usuarioRepository.AdicionarUnidadeVeiculo(unidadeVeiculo);

            AdicionarEventoUnidadeVeiculoCadastrada(
                veiculo, nomeUsuario, request.UnidadeId, request.CondominioId, unidadeVeiculo);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        private async Task<ValidationResult> EditarVeiculoComTrocaDeUsuario(Veiculo veiculo, VeiculoCommand request, Usuario usuario)
        {
            veiculo.SetUsuarioId(request.UsuarioId);
            veiculo.SetVeiculo(request.Placa, request.Modelo, request.Cor);

            //Retirar da lixeira
            veiculo.RestaurarDaLixeira();

            //Exclui todas as UnidadesVeiculo
            foreach (UnidadeVeiculo unidade in veiculo.Unidades)
            {
                _usuarioRepository.RemoverUnidadeVeiculo(unidade);
            }
            veiculo.RemoverTodasAsUnidade();

            //Adiciona uma nova UnidadeVeiculo
            var unidadeVeiculo = new UnidadeVeiculo(veiculo.Id, request.UnidadeId, request.CondominioId);
            var result = veiculo.AdicionarUnidade(unidadeVeiculo);
            if (!result.IsValid)
                return result;

            _usuarioRepository.AdicionarUnidadeVeiculo(unidadeVeiculo);
            _usuarioRepository.AtualizarVeiculo(veiculo);

            AdicionarEventoVeiculoEditadoComTrocaDeUsuario(
                veiculo, usuario.NomeCompleto, request.UnidadeId, request.CondominioId, unidadeVeiculo);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }



        private Veiculo VeiculoFactory(VeiculoCommand request)
        {
            return new Veiculo(request.Placa, request.Modelo, request.Cor, request.UsuarioId);
        }

        private void AdicionarEventoUnidadeVeiculoCadastrada
            (Veiculo veiculo, string nomeUsuario, Guid unidadeId, Guid condominioId, UnidadeVeiculo unidade)
        {
            veiculo.AdicionarEvento(new UnidadeVeiculoCadastradaIntegrationEvent
                (unidade.Id, veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor, veiculo.UsuarioId,
                 nomeUsuario, unidadeId, condominioId));
        }
        
        private void AdicionarEventoVeiculoEditadoComTrocaDeUsuario
            (Veiculo veiculo, string nomeUsuario, Guid unidadeId, Guid condominioId, UnidadeVeiculo unidade)
        {
            veiculo.AdicionarEvento(new VeiculoEditadoComTrocaDeUsuarioIntegrationEvent
                (unidade.Id, veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor, veiculo.UsuarioId,
                nomeUsuario, unidadeId, condominioId));
        }


        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}