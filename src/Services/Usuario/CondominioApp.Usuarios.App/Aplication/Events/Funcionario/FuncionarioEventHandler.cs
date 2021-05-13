using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class FuncionarioEventHandler : EventHandler,        
        INotificationHandler<FuncionarioAdicionadoEvent>,
        INotificationHandler<FuncionarioAtualizadoEvent>,
        INotificationHandler<FuncionarioAtivadoEvent>,
        INotificationHandler<FuncionarioDesativadoEvent>,
        System.IDisposable
    {
        private readonly IUsuarioRepository _usuarioRepository;        
        private readonly IFuncionarioQueryRepository _funcionarioQueryRepository;

        public FuncionarioEventHandler(IUsuarioRepository usuarioRepository, IFuncionarioQueryRepository funcionarioQueryRepository)
        {
            _usuarioRepository = usuarioRepository;            
            _funcionarioQueryRepository = funcionarioQueryRepository;
        }
               

        public async Task Handle(FuncionarioAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(notification.UsuarioId);
            
            var funcionarioFlat = new FuncionarioFlat
                (notification.Id, notification.UsuarioId, notification.CondominioId, notification.NomeCondominio,
                 notification.Atribuicao, notification.Funcao, usuario.SindicoProfissional,
                 notification.Permissao, usuario.Nome, usuario.Sobrenome, usuario.Rg, usuario.ObterCPF(),
                 usuario.ObterCelular(), usuario.ObterTelefone(), usuario.ObterEmail(), usuario.ObterFoto(), usuario.DataNascimento,
                 usuario.ObterLogradouro(), usuario.ObterComplemento(), usuario.ObterNumero(), usuario.ObterCep(),
                 usuario.ObterBairro(), usuario.ObterCidade(), usuario.ObterEstado());

            _funcionarioQueryRepository.Adicionar(funcionarioFlat);

            await PersistirDados(_funcionarioQueryRepository.UnitOfWork);
        }

        public async Task Handle(FuncionarioAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            var funcionarioFlat =await _funcionarioQueryRepository.ObterPorId(notification.Id);

            funcionarioFlat.SetAtribuicao(notification.Atribuicao);
            funcionarioFlat.SetFuncao(notification.Funcao);
            funcionarioFlat.SetPermissao(notification.Permissao);

            _funcionarioQueryRepository.Atualizar(funcionarioFlat);

            await PersistirDados(_funcionarioQueryRepository.UnitOfWork);
        }

        public async Task Handle(FuncionarioAtivadoEvent notification, CancellationToken cancellationToken)
        {
            var funcionarioFlat = await _funcionarioQueryRepository.ObterPorId(notification.Id);

            funcionarioFlat.Ativar();            

            _funcionarioQueryRepository.Atualizar(funcionarioFlat);

            await PersistirDados(_funcionarioQueryRepository.UnitOfWork);
        }

        public async Task Handle(FuncionarioDesativadoEvent notification, CancellationToken cancellationToken)
        {
            var funcionarioFlat = await _funcionarioQueryRepository.ObterPorId(notification.Id);

            funcionarioFlat.Desativar();

            _funcionarioQueryRepository.Atualizar(funcionarioFlat);

            await PersistirDados(_funcionarioQueryRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _funcionarioQueryRepository.Dispose();
        }
    }
}
