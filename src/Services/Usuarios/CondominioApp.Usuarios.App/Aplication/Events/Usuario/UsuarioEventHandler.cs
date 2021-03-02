using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioEventHandler : EventHandler,
        INotificationHandler<MoradorCadastradoEvent>,
        INotificationHandler<FuncionarioCadastradoEvent>,
        System.IDisposable
    {
        private IMoradorQueryRepository _moradorQueryRepository;
        private IFuncionarioQueryRepository _funcionarioQueryRepository;

        public UsuarioEventHandler(IMoradorQueryRepository moradorQueryRepository, IFuncionarioQueryRepository funcionarioQueryRepository)
        {
            _moradorQueryRepository = moradorQueryRepository;
            _funcionarioQueryRepository = funcionarioQueryRepository;
        }
               

        public async Task Handle(MoradorCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var moradorFlat = new MoradorFlat
                (notification.Id, notification.UsuarioId, notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade,
                notification.GrupoUnidade, notification.CondominioId, notification.NomeCondominio, notification.Proprietario, 
                notification.Principal, notification.Nome, notification.Sobrenome, notification.Rg, notification.Cpf.Numero,
                notification.Cel.Numero, notification.Telefone.Numero, notification.Email.Endereco, notification.Foto.NomeDoArquivo,
                notification.TpUsuario.ToString(), notification.DataNascimento, notification.Endereco.logradouro, 
                notification.Endereco.complemento, notification.Endereco.numero, notification.Endereco.cep,
                notification.Endereco.bairro, notification.Endereco.cidade, notification.Endereco.estado);

            _moradorQueryRepository.Adicionar(moradorFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }

        public async Task Handle(FuncionarioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var funcionarioFlat = new FuncionarioFlat
                (notification.Id, notification.UsuarioId, notification.CondominioId, notification.NomeCondominio,
                 notification.Nome, notification.Sobrenome, notification.Rg, notification.Cpf.Numero,
                 notification.Cel.Numero, notification.Telefone.Numero, notification.Email.Endereco,
                 notification.Foto.NomeDoArquivo, notification.TpUsuario.ToString(), notification.DataNascimento,
                 notification.Endereco.logradouro, notification.Endereco.complemento, notification.Endereco.numero,
                 notification.Endereco.cep, notification.Endereco.bairro, notification.Endereco.cidade,
                 notification.Endereco.estado);

            _funcionarioQueryRepository.Adicionar(funcionarioFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }



        public void Dispose()
        {
            _moradorQueryRepository.Dispose();
        }
    }
}
