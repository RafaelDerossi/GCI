using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorEventHandler : EventHandler,
        INotificationHandler<MoradorCadastradoEvent>,
        INotificationHandler<MoradorExcluidoEvent>,
        INotificationHandler<UnidadeMarcadaComoPrincipalEvent>,
        INotificationHandler<MarcadoComoProprietarioEvent>,
        INotificationHandler<DesmarcadoComoProprietarioEvent>,
        INotificationHandler<MoradorRemovidoEvent>,        
        System.IDisposable
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMoradorQueryRepository _moradorQueryRepository;      

        public MoradorEventHandler(IUsuarioRepository usuarioRepository, IMoradorQueryRepository moradorQueryRepository)
        {
            _usuarioRepository = usuarioRepository;
            _moradorQueryRepository = moradorQueryRepository;            
        }
               

        public async Task Handle(MoradorCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(notification.UsuarioId);

            var moradorFlat = new MoradorFlat
                (notification.Id, notification.UsuarioId, notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade,
                notification.GrupoUnidade, notification.CondominioId, notification.NomeCondominio, notification.Proprietario, 
                notification.Principal, usuario.Nome, usuario.Sobrenome, usuario.Rg, usuario.ObterCPF(),
                usuario.ObterCelular(), usuario.ObterTelefone(), usuario.ObterEmail(), usuario.ObterFoto(),
                usuario.DataNascimento, usuario.ObterLogradouro(), usuario.ObterComplemento(), usuario.ObterNumero(),
                usuario.ObterCep(), usuario.ObterBairro(), usuario.ObterCidade(), usuario.ObterEstado());

            _moradorQueryRepository.Adicionar(moradorFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }

        public async Task Handle(MoradorExcluidoEvent notification, CancellationToken cancellationToken)
        {
            var moradorFlat = await _moradorQueryRepository.ObterPorId(notification.Id);            
            if (moradorFlat != null)
            {
                _moradorQueryRepository.Excluir(moradorFlat);

                await PersistirDados(_moradorQueryRepository.UnitOfWork);
            }            
        }

        public async Task Handle(UnidadeMarcadaComoPrincipalEvent notification, CancellationToken cancellationToken)
        {
            var moradorFlat = await _moradorQueryRepository.ObterPorId(notification.Id);

            var moradoresFlat = await _moradorQueryRepository.Obter(m=>m.UsuarioId == moradorFlat.UsuarioId && m.Id != notification.Id);
            foreach (var item in moradoresFlat)
            {
                item.DesmarcarComoPrincipal();
                _moradorQueryRepository.Atualizar(item);
            }

            moradorFlat.MarcarComoPrincipal();

            _moradorQueryRepository.Atualizar(moradorFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }

        public async Task Handle(MarcadoComoProprietarioEvent notification, CancellationToken cancellationToken)
        {
            var moradorFlat = await _moradorQueryRepository.ObterPorId(notification.Id);

            moradorFlat.MarcarComoProprietario();

            _moradorQueryRepository.Atualizar(moradorFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }

        public async Task Handle(DesmarcadoComoProprietarioEvent notification, CancellationToken cancellationToken)
        {
            var moradorFlat = await _moradorQueryRepository.ObterPorId(notification.Id);

            moradorFlat.DesmarcarComoProprietario();

            _moradorQueryRepository.Atualizar(moradorFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }

        public async Task Handle(MoradorRemovidoEvent notification, CancellationToken cancellationToken)
        {
            var moradorFlat = await _moradorQueryRepository.ObterPorId(notification.Id);
            if (moradorFlat != null)
            {
                moradorFlat.EnviarParaLixeira();

                _moradorQueryRepository.Atualizar(moradorFlat);

                await PersistirDados(_moradorQueryRepository.UnitOfWork);
            }
        }


        public void Dispose()
        {
            _moradorQueryRepository.Dispose();
        }
    }
}
