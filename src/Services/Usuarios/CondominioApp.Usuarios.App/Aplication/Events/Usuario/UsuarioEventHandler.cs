using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioEventHandler :
        INotificationHandler<MoradorCadastradoEvent>
    {
        private IMoradorQueryRepository _moradorQueryRepository;

        public UsuarioEventHandler(IMoradorQueryRepository moradorQueryRepository)
        {
            _moradorQueryRepository = moradorQueryRepository;
        }

        public async Task Handle(MoradorCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var moradorFlat = new MoradorFlat
                (notification.UsuarioId, notification.UnidadeId, notification.CondominioId, notification.Proprietario, 
                notification.Principal, notification.Nome, notification.Sobrenome, notification.Rg, notification.Cpf,
                notification.Cel, notification.Telefone, notification.Email, notification.Foto, notification.TpUsuario,
                notification.Ativo, notification.DataNascimento, notification.);

            _moradorQueryRepository.Adicionar(moradorFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }
    }
}
