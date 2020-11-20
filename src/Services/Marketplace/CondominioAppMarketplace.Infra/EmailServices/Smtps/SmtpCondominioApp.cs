using System.Net;
using System.Net.Mail;

namespace CondominioAppMarketplace.Infra.EmailServices.Smtps
{
    public class SmtpCondominioApp : SmtpClient
    {
        public SmtpCondominioApp()
            : base("MAIL.condominioapp.com", 8889)
        {
            Credentials = new NetworkCredential("info@condominioapp.com", "techdog$2016");
        }
    }
}
