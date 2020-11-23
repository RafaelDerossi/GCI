using System.Net;
using System.Net.Mail;

namespace CondominioAppMarketplace.Infra.EmailServices.Smtps
{
    public class SmtpSendBlue : SmtpClient
    {
        public SmtpSendBlue()
            : base("smtp-relay.sendinblue.com", 587)
        {
            Credentials = new NetworkCredential("portaltechdog@gmail.com", "Ys05HpFrPJyMt1dW");
        }
    }
}
