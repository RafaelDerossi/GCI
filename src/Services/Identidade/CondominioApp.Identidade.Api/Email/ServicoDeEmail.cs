using System.Net.Mail;
using System.Threading.Tasks;

namespace CondominioApp.Identidade.Api.Email
{
    public abstract class ServicoDeEmail : SmtpAmazonService
    {
        public readonly MailMessage _Email;

        public abstract string SubstituirValores();

        public abstract Task EnviarEmail();

        public void ConstruirEmail(string Assunto, string ConteudoDoEmail)
        {
            _Email.From = new MailAddress("info@conect.studio", "Conect Studio");
            _Email.Subject = Assunto;
            _Email.IsBodyHtml = true;
            _Email.Body = ConteudoDoEmail;
        }

        public ServicoDeEmail() => _Email = new MailMessage();
    }
}