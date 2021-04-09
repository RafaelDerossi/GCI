using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.App.Service
{
    public class DisparadorDeEmails
    {
        private readonly ServicoDeEmail _serviceDeEmail;

        public DisparadorDeEmails(ServicoDeEmail serviceDeEmail)
        {
            _serviceDeEmail = serviceDeEmail;
        }

        public async Task Disparar()
        {
            await _serviceDeEmail.EnviarEmail();
        }
    }
}
