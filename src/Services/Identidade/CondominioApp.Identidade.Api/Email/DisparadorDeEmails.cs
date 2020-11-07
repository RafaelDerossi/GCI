using System.Threading.Tasks;

namespace CondominioApp.Identidade.Api.Email
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
