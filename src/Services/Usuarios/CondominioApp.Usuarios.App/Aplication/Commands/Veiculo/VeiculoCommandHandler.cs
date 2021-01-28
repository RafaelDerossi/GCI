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

            //Busca o veiculo no BD pela placa
            var veiculo = await _usuarioRepository.ObterVeiculoPorPlaca(request.Placa);

            //Se nao encontrar, Cadastra
            if (veiculo == null) 
            {
                veiculo = VeiculoFactory(request);

                _usuarioRepository.AdicionarVeiculo(veiculo);

                veiculo.AdicionarEvento(new VeiculoCadastradoIntegrationEvent(
                    veiculo.Id, veiculo.Placa, veiculo.Modelo, veiculo.Cor, veiculo.UsuarioId, usuario.NomeCompleto, request.UnidadeId));

                return await PersistirDados(_usuarioRepository.UnitOfWork);
            }

           //
            

            veiculo.AdicionarEvento(new VeiculoCadastradoIntegrationEvent(veiculo.Id,veiculo.Placa,veiculo.Modelo,veiculo.Cor,veiculo.UsuarioId,, request.UnidadeId));

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }  
        

        //public async Task<ValidationResult> Handle(EditarMoradorCommand request, CancellationToken cancellationToken)

        //{
        //    if (!request.EstaValido()) return request.ValidationResult;

        //    var Morador = _usuarioRepository.ObterPorId(request.UsuarioId).Result;

        //    Morador.SetNome(request.Nome);
        //    Morador.SetSobrenome(request.Sobrenome);
        //    Morador.SetRg(request.Rg);
        //    Morador.SetCpf(request.Cpf);
        //    Morador.SetCelular(request.Cel);
        //    Morador.SetEmail(request.Email);
        //    Morador.SetFoto(request.Foto);
        //    Morador.SetTipoDeUsuario(request.TpUsuario);
        //    Morador.SetPermissao(request.Permissao);
        //    Morador.SetDataNascimento(request.DataNascimento);

        //    _usuarioRepository.Atualizar(Morador);

        //    return await PersistirDados(_usuarioRepository.UnitOfWork);
        //}

        

        private Veiculo VeiculoFactory(VeiculoCommand request)
        {
            return new Veiculo(request.Placa, request.Modelo, request.Cor, request.UsuarioId);
        }
        
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}