using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailEnquete : ServicoDeEmail
    {     
        private string _assunto = "Nova Enquete";
        private EnqueteDTO _enquete;        
        private string _logoCondominioApp = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

        public EmailEnquete(EnqueteDTO enquete)
        {
            _enquete = enquete;           

            var conteudo = SubstituirValores();

            ConstruirEmail(_assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Enquete\\novaEnquete.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            if (string.IsNullOrEmpty(_enquete.LogoDoCondominio) || _enquete.LogoDoCondominio == "https://i.imgur.com/gxXxUm7.png")
                _enquete.LogoDoCondominio = _logoCondominioApp;

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_titulo_", _assunto);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_nomeCondominio_", _enquete.NomeCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_previaDaEnquete_", _enquete.Descricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_dataPublicacao_", _enquete.DataInicio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_dataLimite_", _enquete.DataFim);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominio_", _enquete.LogoDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominioApp_", _logoCondominioApp);            

            return conteudoDoHtmlDoEmail;
        }
    
        public override async Task EnviarEmail()
        {
            if (_enquete.ListaDeEmails.Count() == 0)
                return;

            foreach (var email in _enquete.ListaDeEmails)
            {
                _Email.Bcc.Add(email);                
            }      
            
            await Task.Run(() => base.Send(_Email));
        }
    }
}