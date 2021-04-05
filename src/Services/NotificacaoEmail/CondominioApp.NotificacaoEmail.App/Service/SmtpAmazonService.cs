using System.Net;
using System.Net.Mail;

namespace CondominioApp.NotificacaoEmail.App.Service
{
    public class SmtpAmazonService : SmtpClient
    {
        public SmtpAmazonService()
            : base("email-smtp.us-west-2.amazonaws.com", 587)
        {
            Credentials = new NetworkCredential("AKIASOWCVT3OMEKPJJXI", "BBTEJTSgReKNV4v7TzwWnWpTcJ6Thqa4jwtdG7YtfJQY");
            EnableSsl = true;
        }
    }
}