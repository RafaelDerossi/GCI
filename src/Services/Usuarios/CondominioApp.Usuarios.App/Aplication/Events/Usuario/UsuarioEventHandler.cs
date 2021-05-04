using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioEventHandler : EventHandler,
        INotificationHandler<UsuarioEditadoEvent>,
        System.IDisposable
    {
        private IMoradorQueryRepository _moradorRepository;
        private IFuncionarioQueryRepository _funcionarioRepository;

        public UsuarioEventHandler(IMoradorQueryRepository moradorRepository, IFuncionarioQueryRepository funcionarioRepository)
        {
            _moradorRepository = moradorRepository;
            _funcionarioRepository = funcionarioRepository;
        }
               

        public async Task Handle(UsuarioEditadoEvent notification, CancellationToken cancellationToken)
        {
            var moradores = await _moradorRepository.Obter(m=>m.UsuarioId == notification.UsuarioId);
            foreach (var item in moradores)
            {
                item.SetNome(notification.Nome);
                item.SetSobrenome(notification.Sobrenome);
                item.SetRg(notification.Rg);
                item.SetCpf(notification.Cpf);
                item.SetTelefone(notification.Telefone);
                item.SetCelular(notification.Cel);              
                item.SetFoto(notification.Foto);
                item.SetEndereco(notification.Endereco);

                _moradorRepository.Atualizar(item);
            }
            await PersistirDados(_moradorRepository.UnitOfWork);


            var funcionarios = await _funcionarioRepository.Obter(m => m.UsuarioId == notification.UsuarioId);
            foreach (var item in funcionarios)
            {
                item.SetNome(notification.Nome);
                item.SetSobrenome(notification.Sobrenome);
                item.SetRg(notification.Rg);
                item.SetCpf(notification.Cpf);
                item.SetTelefone(notification.Telefone);
                item.SetCelular(notification.Cel);
                item.SetEmail(notification.Email);
                item.SetFoto(notification.Foto);
                item.SetEndereco(notification.Endereco);

                _funcionarioRepository.Atualizar(item);
            }
            await PersistirDados(_funcionarioRepository.UnitOfWork);
            
        }
            

        public void Dispose()
        {
            _moradorRepository.Dispose();
        }
    }
}
