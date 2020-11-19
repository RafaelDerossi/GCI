using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace CondominioApp.Identidade.Api.Email
{
    public class EmailRecuperarSenha : ServicoDeEmail
    {
        private string _Assunto = "Recuperar senha - Conect Studio";
        private string caminhoUrl = string.Empty;
        private IdentityUser _Usuario;

        public EmailRecuperarSenha(IdentityUser Usuario, string token, string LinkDeRedirecionamento)
        {
            _Usuario = Usuario;

            caminhoUrl = $"{LinkDeRedirecionamento}/{HttpUtility.UrlEncode(token)}/{Usuario.Email}";

            var conteudo = SubstituirValores();

            ConstruirEmail(_Assunto, conteudo);
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(_Usuario.Email);
            await Task.Run(() => base.Send(_Email));
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\EmailEsqueciSenha.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", _Usuario.UserName);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_urlDeRedirecionamento_", $"{caminhoUrl}");

            return conteudoDoHtmlDoEmail;
        }
    }
}
