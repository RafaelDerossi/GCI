using System.Threading;
using System.Threading.Tasks;
using CondominioAppPreCadastro.App.EmailServices;
using MediatR;

namespace CondominioAppPreCadastro.App.Aplication.Events
{
    public class LeadEventHandler : INotificationHandler<LeadCadastradoEvent>
    {
        public async Task Handle(LeadCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var DisparadorDeEmailCliente = new DisparadorDeEmails(new EmailConfirmacaoDeCadastro(notification.Lead.Email.Endereco,notification.Lead.Nome));

            await DisparadorDeEmailCliente.Disparar();


            var DisparadorDeEmailDaEmpresa = new DisparadorDeEmails(new EmailPreCadastroEmpresa(notification.Lead));

            await DisparadorDeEmailDaEmpresa.Disparar();
        }
    }
}