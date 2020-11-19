using System.Threading.Tasks;

namespace CondominioAppPreCadastro.App.EmailServices
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
