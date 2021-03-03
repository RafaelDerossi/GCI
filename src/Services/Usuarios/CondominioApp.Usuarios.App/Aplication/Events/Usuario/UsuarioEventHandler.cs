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
        private IUsuarioRepository _usuarioRepository;
        private IMoradorQueryRepository _moradorQueryRepository;
        private IFuncionarioQueryRepository _funcionarioQueryRepository;

        public UsuarioEventHandler(IUsuarioRepository usuarioRepository, IMoradorQueryRepository moradorQueryRepository, IFuncionarioQueryRepository funcionarioQueryRepository)
        {
            _usuarioRepository = usuarioRepository;
            _moradorQueryRepository = moradorQueryRepository;
            _funcionarioQueryRepository = funcionarioQueryRepository;
        }
               

        public async Task Handle(MoradorCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(notification.UsuarioId);

            var moradorFlat = new MoradorFlat
                (notification.Id, notification.UsuarioId, notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade,
                notification.GrupoUnidade, notification.CondominioId, notification.NomeCondominio, notification.Proprietario, 
                notification.Principal, usuario.Nome, usuario.Sobrenome, usuario.Rg, usuario.Cpf.Numero,
                usuario.Cel.Numero, usuario.Telefone.Numero, usuario.Email.Endereco, usuario.Foto.NomeDoArquivo,
                usuario.TpUsuario.ToString(), usuario.DataNascimento, usuario.Endereco.logradouro,
                usuario.Endereco.complemento, usuario.Endereco.numero, usuario.Endereco.cep,
                usuario.Endereco.bairro, usuario.Endereco.cidade, usuario.Endereco.estado);

            _moradorQueryRepository.Adicionar(moradorFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }

        public async Task Handle(FuncionarioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(notification.UsuarioId);

            var funcionarioFlat = new FuncionarioFlat
                (notification.Id, notification.UsuarioId, notification.CondominioId, notification.NomeCondominio,
                 notification.Atribuicao, notification.Funcao, usuario.SindicoProfissional,
                 notification.Permissao.ToString(), usuario.Nome, usuario.Sobrenome, usuario.Rg, usuario.Cpf.Numero,
                 usuario.Cel.Numero, usuario.Telefone.Numero, usuario.Email.Endereco,
                 usuario.Foto.NomeDoArquivo, usuario.TpUsuario.ToString(), usuario.DataNascimento,
                 usuario.Endereco.logradouro, usuario.Endereco.complemento, usuario.Endereco.numero,
                 usuario.Endereco.cep, usuario.Endereco.bairro, usuario.Endereco.cidade,
                 usuario.Endereco.estado);

            _funcionarioQueryRepository.Adicionar(funcionarioFlat);

            await PersistirDados(_moradorQueryRepository.UnitOfWork);
        }



        public void Dispose()
        {
            _moradorQueryRepository.Dispose();
        }
    }
}
