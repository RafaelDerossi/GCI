using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailCorrespondencia : ServicoDeEmail
    {                
        private readonly CorrespondenciaDTO _correspondencia;        
        private readonly string _logoCondominioApp = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

        public EmailCorrespondencia(CorrespondenciaDTO correspondencia)
        {
            _correspondencia = correspondencia;           

            var conteudo = SubstituirValores();

            ConstruirEmail(_correspondencia.Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Correspondencia\\correspondencia.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            if (string.IsNullOrEmpty(_correspondencia.LogoDoCondominio) || _correspondencia.LogoDoCondominio == "https://i.imgur.com/gxXxUm7.png")
                _correspondencia.LogoDoCondominio = _logoCondominioApp;

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_titulo_", _correspondencia.Titulo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_mensagem_", _correspondencia.Descricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominio_", _correspondencia.LogoDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominioApp_", _logoCondominioApp);            

            return conteudoDoHtmlDoEmail;
        }
    
        public override async Task EnviarEmail()
        {
            if (_correspondencia.ListaDeEmails.Count() == 0)
                return;

            foreach (var email in _correspondencia.ListaDeEmails)
            {
                _Email.Bcc.Add(email);                
            }      
            
            await Task.Run(() => base.Send(_Email));
        }
    }
}