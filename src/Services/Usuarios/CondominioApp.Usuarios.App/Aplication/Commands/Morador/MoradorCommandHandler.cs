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
    public class MoradorCommandHandler : CommandHandler,        
        IRequestHandler<CadastrarMoradorCommand, ValidationResult>,
        IRequestHandler<ExcluirMoradorCommand, ValidationResult>,
        IRequestHandler<MarcarComoUnidadePrincipalCommand, ValidationResult>,
        IRequestHandler<MarcarComoProprietarioCommand, ValidationResult>,
        IRequestHandler<DesmarcarComoProprietarioCommand, ValidationResult>,
        IDisposable
    {
        private IUsuarioRepository _usuarioRepository;

        public MoradorCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
           

        public async Task<ValidationResult> Handle(CadastrarMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;


            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);            
            if (usuario == null)
            {
                AdicionarErro("Usuário não encontrado.");
                return ValidationResult;
            }

            var morador = await _usuarioRepository.ObterMoradorPorUsuarioIdEUnidadeId(request.UsuarioId, request.UnidadeId);
            if (morador != null)
            {
                AdicionarErro("Morador já cadastrado.");
                return ValidationResult;
            }

            var moradorNovo = MoradorFactory(request);

            _usuarioRepository.AdicionarMorador(moradorNovo);

            //Evento
            moradorNovo.AdicionarEvento(
                new MoradorCadastradoEvent(
                    moradorNovo.Id, moradorNovo.UsuarioId, moradorNovo.CondominioId, request.NomeCondominio,
                    moradorNovo.UnidadeId, request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade,
                    moradorNovo.Proprietario, moradorNovo.Principal));

            moradorNovo.AdicionarEvento
                    (new EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent(moradorNovo.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ExcluirMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var morador = await _usuarioRepository.ObterMoradorPorId(request.Id);
            if (morador == null)
            {
                AdicionarErro("Morador não encontrado.");
                return ValidationResult;
            }            

            _usuarioRepository.ExcluirMorador(morador);

            //Evento
            morador.AdicionarEvento(new MoradorExcluidoEvent(morador.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(MarcarComoUnidadePrincipalCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var morador = await _usuarioRepository.ObterMoradorPorId(request.Id);
            if (morador == null)
            {
                AdicionarErro("Morador não encontrado.");
                return ValidationResult;
            }

            var moradores = await _usuarioRepository.ObterMoradores(m=>m.UsuarioId == morador.UsuarioId && m.Id != morador.Id);
            foreach (var item in moradores)
            {
                item.DesmarcarComoPrincipal();
                _usuarioRepository.AtualizarMorador(item);
            }

            morador.MarcarComoPrincipal();

            _usuarioRepository.AtualizarMorador(morador);

            //Evento
            morador.AdicionarEvento(new UnidadeMarcadaComoPrincipalEvent(morador.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(MarcarComoProprietarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var morador = await _usuarioRepository.ObterMoradorPorId(request.Id);
            if (morador == null)
            {
                AdicionarErro("Morador não encontrado.");
                return ValidationResult;
            }

            morador.MarcarComoProprietario();

            _usuarioRepository.AtualizarMorador(morador);

            //Evento
            morador.AdicionarEvento(new MarcadoComoProprietarioEvent(morador.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(DesmarcarComoProprietarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var morador = await _usuarioRepository.ObterMoradorPorId(request.Id);
            if (morador == null)
            {
                AdicionarErro("Morador não encontrado.");
                return ValidationResult;
            }

            morador.DesmarcarComoProprietario();

            _usuarioRepository.AtualizarMorador(morador);

            //Evento
            morador.AdicionarEvento(new DesmarcadoComoProprietarioEvent(morador.Id));

            return await PersistirDados(_usuarioRepository.UnitOfWork);

        }

      

              
        private Morador MoradorFactory(MoradorCommand request)
        {
            var morador = new Morador
                (request.UsuarioId, request.UnidadeId, request.CondominioId, request.Proprietario, request.Principal);

            return morador;
        }

        
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

    }
}