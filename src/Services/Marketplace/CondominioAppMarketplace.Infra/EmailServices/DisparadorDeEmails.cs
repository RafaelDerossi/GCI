using System.Threading.Tasks;

namespace CondominioAppMarketplace.Infra.EmailServices
{
    public class DisparadorDeEmails
    {
        private readonly IServicoDeEmail _serviceDeEmail;

        public DisparadorDeEmails(IServicoDeEmail serviceDeEmail)
        {
            _serviceDeEmail = serviceDeEmail;
        }

        public async Task Disparar()
        {
            await _serviceDeEmail.EnviarEmail();
        }
    }
}
